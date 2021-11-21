namespace Spdx.Expressions;

/// <summary>
/// Represents a SPDX license expression.
/// </summary>
public abstract class SpdxExpression
{
    /// <summary>
    /// Parses the provided expression into an abstract syntax tree
    /// representing the original expression.
    /// </summary>
    /// <param name="expression">The expression to parse.</param>
    /// <returns>An abstract syntax tree representing the original expression.</returns>
    public static SpdxExpression Parse(string expression)
    {
        var lexer = new Lexer(expression);
        return Parser.Parse(lexer);
    }

    internal abstract TResult Accept<TContext, TResult>(TContext context, ISpdxExpressionVisitor<TContext, TResult> visitor);
}
