using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Spdx.Expressions;
using Spdx.Expressions.Ast;
using Spectre.Console;

namespace Expressions
{
    public sealed class ExpressionPrinter
    {
        public static void Print(IAnsiConsole console, SpdxExpression expression)
        {
            var visitor = new Visitor();
            visitor.Visit(console, expression);
            console.WriteLine();
        }

        private sealed class Visitor : SpdxExpressionVisitor<IAnsiConsole>
        {
            public override void VisitAnd(IAnsiConsole context, SpdxAndExpression expression)
            {
                expression.Left.Accept(context, this);
                context.Markup(" [grey]AND[/] ");
                expression.Right.Accept(context, this);
            }

            public override void VisitException(IAnsiConsole context, SpdxLicenseExceptionExpression expression)
            {
                context.Markup("[blue]{0}[/]", expression.Id.EscapeMarkup());
            }

            public override void VisitLicense(IAnsiConsole context, SpdxLicenseExpression expression)
            {
                context.Markup("[green]{0}[/]", expression.Id.EscapeMarkup());
            }

            public override void VisitOr(IAnsiConsole context, SpdxOrExpression expression)
            {
                expression.Left.Accept(context, this);
                context.Markup(" [grey]OR[/] ");
                expression.Right.Accept(context, this);
            }

            public override void VisitReference(IAnsiConsole context, SpdxLicenseReferenceExpression expression)
            {
                if (string.IsNullOrWhiteSpace(expression.DocumentReference))
                {
                    context.Markup("[green]LicenseRef-{1}[/]",
                        expression.LicenseRef.EscapeMarkup());
                }
                else
                {
                    context.Markup("[green]DocumentRef-{0}[/]:[green]LicenseRef-{1}[/]",
                        expression.DocumentReference.EscapeMarkup(),
                        expression.LicenseRef.EscapeMarkup());
                }
            }

            public override void VisitScope(IAnsiConsole context, SpdxScopeExpression expression)
            {
                context.Markup("[grey]([/]");
                expression.Expression.Accept(context, this);
                context.Markup("[grey])[/]");
            }

            public override void VisitWith(IAnsiConsole context, SpdxWithExpression expression)
            {
                expression.Expression.Accept(context, this);
                context.Markup(" [grey]WITH[/] ");
                expression.Exception.Accept(context, this);
            }
        }
    }
}
