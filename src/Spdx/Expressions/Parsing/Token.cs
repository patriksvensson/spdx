namespace Spdx.Expressions;

internal sealed class Token
{
    public TokenType Type { get; set; }
    public string Value { get; }

    public Token(TokenType type, string value)
    {
        Type = type;
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }
}
