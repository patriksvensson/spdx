namespace Spdx.Expressions;

internal sealed class Lexer
{
    private readonly TextBuffer _buffer;
    private readonly Queue<Token> _queue;
    private readonly SpdxLicenseParseOptions _options;

    public Token? Current { get; private set; }
    public Token? Previous { get; private set; }

    public Lexer(string expression, SpdxLicenseParseOptions options)
    {
        _buffer = new TextBuffer(expression);
        _queue = new Queue<Token>();
        _options = options;
    }

    public void MoveNext()
    {
        Previous = Current;

        if (Read(out var token))
        {
            Current = token;
        }
        else
        {
            Current = null;
        }
    }

    public bool MoveNext([NotNullWhen(true)] out Token? token)
    {
        Previous = Current;

        if (Read(out token))
        {
            Current = token;
            return true;
        }
        else
        {
            Current = null;
            return false;
        }
    }

    public Token? Peek()
    {
        var position = _buffer.Position;

        try
        {
            Read(out var result);
            return result;
        }
        finally
        {
            // Move back
            _buffer.Move(position);
        }
    }

    public Token Consume(TokenType type)
    {
        var temp = Current;
        if (temp == null)
        {
            throw new SpdxParseException("Could not parse expression (tried consuming null token)");
        }

        Expect(type);
        MoveNext();
        return temp;
    }

    public void ConsumeOptional(TokenType type)
    {
        if (Current?.Type == type)
        {
            MoveNext();
        }
    }

    public Token ConsumeAny(params TokenType[] types)
    {
        var temp = Current;
        if (temp == null)
        {
            throw new SpdxParseException("Could not parse expression (tried consuming null token)");
        }

        foreach (var type in types)
        {
            if (Current?.Type == type)
            {
                MoveNext();
                return temp;
            }
        }

        var text = string.Join(", ", types.Select(t => t.ToString()));
        throw new SpdxParseException($"Expected token to be one of the following: {text} but got '{Current?.Type}ä");
    }

    public bool Read([NotNullWhen(true)] out Token? token)
    {
        if (_queue.Count > 0)
        {
            token = _queue.Dequeue();
            return true;
        }

        EatWhitespace();

        var current = _buffer.PeekChar();

        if (!_buffer.CanRead)
        {
            token = null;
            return false;
        }

        if (current == '+')
        {
            _buffer.Discard('+');
            token = new Token(TokenType.Plus, "+");
            return true;
        }
        else if (current == '(')
        {
            _buffer.Discard('(');
            token = new Token(TokenType.LParen, "(");
            return true;
        }
        else if (current == ')')
        {
            _buffer.Discard(')');
            token = new Token(TokenType.RParen, ")");
            return true;
        }
        else
        {
            var accumulator = new StringBuilder();
            while (_buffer.CanRead)
            {
                current = _buffer.PeekChar();
                if (current == ':' || current == '.' || current == '-' || char.IsDigit(current) || char.IsLetter(current))
                {
                    accumulator.Append(_buffer.ReadChar());
                }
                else
                {
                    break;
                }
            }

            var text = accumulator.ToString();
            if (text.Equals("AND", StringComparison.Ordinal))
            {
                token = new Token(TokenType.And, "AND");
                return true;
            }
            else if (text.Equals("OR", StringComparison.Ordinal))
            {
                token = new Token(TokenType.Or, "OR");
                return true;
            }
            else if (text.Equals("WITH", StringComparison.Ordinal))
            {
                token = new Token(TokenType.With, "WITH");
                return true;
            }
            else
            {
                if (SpdxLicense.Exists(text))
                {
                    token = new Token(TokenType.LicenseId, text);
                    return true;
                }
                else if (SpdxLicense.Exceptions.Exists(text))
                {
                    token = new Token(TokenType.Exception, text);
                    return true;
                }
                else
                {
                    var parts = text.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries);
                    if (parts.Length == 1)
                    {
                        var licenseRef = ParseRef("LicenseRef-", parts);
                        if (licenseRef != null)
                        {
                            token = new Token(TokenType.LicenseRef, licenseRef);
                            return true;
                        }

                        if (Previous != null && Previous.Type == TokenType.With)
                        {
                            if (_options.HasFlag(SpdxLicenseParseOptions.AllowUnknownExceptions))
                            {
                                token = new Token(TokenType.Exception, text);
                                return true;
                            }

                            throw new SpdxParseException($"Invalid SPDX license exception '{text}'");
                        }

                        if (_options.HasFlag(SpdxLicenseParseOptions.AllowUnknownLicenses))
                        {
                            token = new Token(TokenType.LicenseId, text);
                            return true;
                        }
                    }
                    else if (parts.Length == 2)
                    {
                        var documentRef = ParseRef("DocumentRef-", parts);
                        var licenseRef = ParseRef("LicenseRef-", parts);

                        if (documentRef != null && licenseRef != null)
                        {
                            _queue.Enqueue(new Token(TokenType.LicenseRef, licenseRef));

                            token = new Token(TokenType.DocumentRef, documentRef);
                            return true;
                        }
                    }

                    throw new SpdxParseException($"Invalid SPDX license '{text}'");
                }
            }
        }

        throw new SpdxParseException("Could not parse expression");
    }

    private string? ParseRef(string prefix, string[] parts)
    {
        foreach (var part in parts)
        {
            if (part.StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                return part[prefix.Length..];
            }
        }

        return null;
    }

    private void Expect(TokenType type)
    {
        if (Current?.Type != type)
        {
            throw new SpdxParseException($"Expected token of type '{type}'.");
        }
    }

    private void EatWhitespace()
    {
        while (_buffer.CanRead)
        {
            var ch = (char)_buffer.Peek();
            if (!char.IsWhiteSpace(ch))
            {
                break;
            }

            _buffer.Read();
        }
    }
}
