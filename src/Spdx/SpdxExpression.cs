using Spdx.Expressions;

namespace Spdx;

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
        return Parse(expression, SpdxLicenseOptions.Strict);
    }

    /// <summary>
    /// Parses the provided expression into an abstract syntax tree
    /// representing the original expression.
    /// </summary>
    /// <param name="expression">The expression to parse.</param>
    /// <param name="options">The options to use when parsing the expression.</param>
    /// <returns>An abstract syntax tree representing the original expression.</returns>
    public static SpdxExpression Parse(string expression, SpdxLicenseOptions options)
    {
        var lexer = new Lexer(expression, options);
        return Parser.Parse(lexer, options);
    }

    /// <summary>
    /// Parses the provided expression into an abstract syntax tree
    /// representing the original expression.
    /// A return value indicates whether the operation succeeded.
    /// </summary>
    /// <param name="expression">The expression to parse.</param>
    /// <param name="result">
    /// When this method returns, contains the abstract syntax tree
    /// equivalent of the expression contained in <paramref name="expression"/>.
    /// </param>
    /// <returns>
    /// <c>true</c> if <paramref name="expression"/> was parsed successfully; otherwise, <c>false</c>.
    /// </returns>
    public static bool TryParse(string expression, out SpdxExpression? result)
    {
        return TryParse(expression, SpdxLicenseOptions.Strict, out result);
    }

    /// <summary>
    /// Parses the provided expression into an abstract syntax tree
    /// representing the original expression.
    /// A return value indicates whether the operation succeeded.
    /// </summary>
    /// <param name="expression">The expression to parse.</param>
    /// <param name="options">The options to use when parsing the expression.</param>
    /// <param name="result">
    /// When this method returns, contains the abstract syntax tree
    /// equivalent of the expression contained in <paramref name="expression"/>.
    /// </param>
    /// <returns>
    /// <c>true</c> if <paramref name="expression"/> was parsed successfully; otherwise, <c>false</c>.
    /// </returns>
    public static bool TryParse(string expression, SpdxLicenseOptions options, out SpdxExpression? result)
    {
        try
        {
            result = Parse(expression, options);
            return true;
        }
        catch
        {
            result = null;
            return false;
        }
    }

    /// <summary>
    /// Checks whether or not the provided expression is valid.
    /// </summary>
    /// <param name="expression">The expression to parse.</param>
    /// <returns>
    /// <c>true</c> if <paramref name="expression"/> was parsed successfully; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsValidExpression(string expression)
    {
        return TryParse(expression, out var _);
    }

    /// <summary>
    /// Checks whether or not the provided expression is valid.
    /// </summary>
    /// <param name="expression">The expression to parse.</param>
    /// <param name="options">The options to use when parsing the expression.</param>
    /// <returns>
    /// <c>true</c> if <paramref name="expression"/> was parsed successfully; otherwise, <c>false</c>.
    /// </returns>
    public static bool IsValidExpression(string expression, SpdxLicenseOptions options)
    {
        return TryParse(expression, options, out var _);
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
