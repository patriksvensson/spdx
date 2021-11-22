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

    /// <summary>
    /// Accepts a node using the specified context and <see cref="ISpdxExpressionVisitor{TContext, TResult}"/>.
    /// </summary>
    /// <typeparam name="TContext">The context type.</typeparam>
    /// <typeparam name="TResult">The result type.</typeparam>
    /// <param name="context">The context.</param>
    /// <param name="visitor">The visitor.</param>
    /// <returns>The result of the invocation.</returns>
    public abstract TResult Accept<TContext, TResult>(TContext context, ISpdxExpressionVisitor<TContext, TResult> visitor);
}
