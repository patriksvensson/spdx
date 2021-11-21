namespace Spdx.Expressions.Parsing;

internal static class Parser
{
    public static SpdxExpression Parse(Lexer lexer)
    {
        lexer.MoveNext();
        return ParseExpression(lexer);
    }

    private static SpdxExpression ParseExpression(Lexer lexer)
    {
        var expression = ParseAnd(lexer);
        if (lexer.Current?.Type == TokenType.With)
        {
            lexer.MoveNext();

            var right = ParsePredicate(lexer);
            if (right is not SpdxLicenseExceptionExpression exception)
            {
                throw new InvalidOperationException("The right side of WITH clause must be an SPDX license exception");
            }

            return new SpdxWithExpression(expression, exception);
        }

        return expression;
    }

    private static SpdxExpression ParseAnd(Lexer lexer)
    {
        var expression = ParseOr(lexer);
        while (lexer.Current?.Type == TokenType.And)
        {
            lexer.MoveNext();
            expression = new SpdxAndExpression(expression, ParseOr(lexer));
        }

        return expression;
    }

    private static SpdxExpression ParseOr(Lexer lexer)
    {
        var expression = ParsePredicate(lexer);
        while (lexer.Current?.Type == TokenType.Or)
        {
            lexer.MoveNext();
            expression = new SpdxAndExpression(expression, ParseOr(lexer));
        }

        return expression;
    }

    private static SpdxExpression ParsePredicate(Lexer lexer)
    {
        if (lexer.Current != null)
        {
            switch (lexer.Current.Type)
            {
                case TokenType.LParen:
                    return ParseScopeExpression(lexer);
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

        throw new InvalidOperationException("Unexpected end of expression.");
    }

    private static SpdxExpression ParseScopeExpression(Lexer lexer)
    {
        lexer.Consume(TokenType.LParen);
        var expression = ParseExpression(lexer);
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
