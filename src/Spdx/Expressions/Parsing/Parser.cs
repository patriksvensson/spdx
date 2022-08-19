namespace Spdx.Expressions;

internal static class Parser
{
    public static SpdxExpression Parse(Lexer lexer, SpdxLicenseOptions options)
    {
        lexer.MoveNext();
        return ParseExpression(lexer, options);
    }

    private static SpdxExpression ParseExpression(Lexer lexer, SpdxLicenseOptions options)
    {
        var expression = ParseAnd(lexer, options);
        if (lexer.Current?.Type == TokenType.With)
        {
            lexer.MoveNext();

            var right = ParsePredicate(lexer, options);
            if (right is not SpdxLicenseExceptionExpression exception)
            {
                if (right is SpdxLicenseExpression license && options.HasFlag(SpdxLicenseOptions.AllowUnknownExceptions))
                {
                    exception = new SpdxLicenseExceptionExpression(license.Id);
                }
                else
                {
                    throw new SpdxParseException("The right side of WITH clause must be an SPDX license exception");
                }
            }

            return new SpdxWithExpression(expression, exception);
        }

        return expression;
    }

    private static SpdxExpression ParseAnd(Lexer lexer, SpdxLicenseOptions options)
    {
        var expression = ParseOr(lexer, options);
        while (lexer.Current?.Type == TokenType.And)
        {
            lexer.MoveNext();
            expression = new SpdxAndExpression(expression, ParseOr(lexer, options));
        }

        return expression;
    }

    private static SpdxExpression ParseOr(Lexer lexer, SpdxLicenseOptions options)
    {
        var expression = ParsePredicate(lexer, options);
        while (lexer.Current?.Type == TokenType.Or)
        {
            lexer.MoveNext();
            expression = new SpdxOrExpression(expression, ParseOr(lexer, options));
        }

        return expression;
    }

    private static SpdxExpression ParsePredicate(Lexer lexer, SpdxLicenseOptions options)
    {
        if (lexer.Current != null)
        {
            switch (lexer.Current.Type)
            {
                case TokenType.LParen:
                    return ParseScopeExpression(lexer, options);
                case TokenType.LicenseId:
                    return ParseLicenseId(lexer, lexer.Current.Value);
                case TokenType.LicenseRef:
                    var licenseRef = lexer.Current.Value;
                    lexer.MoveNext();
                    return new SpdxLicenseReferenceExpression(null, licenseRef);
                case TokenType.DocumentRef:
                    var documentRef = lexer.Current.Value;
                    lexer.MoveNext();
                    if (lexer.Current?.Type == TokenType.LicenseRef)
                    {
                        var licenseRef2 = lexer.Current.Value;
                        lexer.MoveNext();
                        return new SpdxLicenseReferenceExpression(documentRef, licenseRef2);
                    }

                    throw new InvalidOperationException();
                case TokenType.Exception:
                    var id = lexer.Current.Value;
                    lexer.MoveNext();
                    return new SpdxLicenseExceptionExpression(id);
            }
        }

        throw new SpdxParseException("Encountered unexpected end of expression.");
    }

    private static SpdxExpression ParseScopeExpression(Lexer lexer, SpdxLicenseOptions options)
    {
        lexer.Consume(TokenType.LParen);
        var expression = ParseExpression(lexer, options);
        lexer.Consume(TokenType.RParen);
        return new SpdxScopeExpression(expression);
    }

    private static SpdxExpression ParseLicenseId(Lexer lexer, string id)
    {
        lexer.MoveNext();

        var orLater = false;
        if (lexer.Current?.Type == TokenType.Plus)
        {
            orLater = true;
            lexer.MoveNext();
        }

        return new SpdxLicenseExpression(id, orLater);
    }
}
