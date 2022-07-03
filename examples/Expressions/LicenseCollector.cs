using Spdx;
using Spdx.Expressions;

namespace Expressions
{
    public sealed class LicenseCollector 
    {
        public static List<CollectedLicense> Collect(SpdxExpression expression)
        {
            var visitor = new Visitor();
            return visitor.Visit(null, expression).ToList();
        }

        public sealed class CollectedLicense
        {
            public string Id { get; }
            public List<string> Exceptions { get; }

            public CollectedLicense(string id)
            {
                Id = id;
                Exceptions = new List<string>();
            }
        }

        private sealed class Visitor : SpdxExpressionVisitor<object?, IEnumerable<CollectedLicense>>
        {
            public override IEnumerable<CollectedLicense> VisitAnd(object? context, SpdxAndExpression expression)
            {
                return expression.Left.Accept(context, this)
                    .Concat(expression.Right.Accept(context, this));
            }

            public override IEnumerable<CollectedLicense> VisitException(object? context, SpdxLicenseExceptionExpression expression)
            {
                yield break;
            }

            public override IEnumerable<CollectedLicense> VisitLicense(object? context, SpdxLicenseExpression expression)
            {
                yield return new CollectedLicense(expression.Id);
            }

            public override IEnumerable<CollectedLicense> VisitOr(object? context, SpdxOrExpression expression)
            {
                return expression.Left.Accept(context, this)
                    .Concat(expression.Right.Accept(context, this));
            }

            public override IEnumerable<CollectedLicense> VisitReference(object? context, SpdxLicenseReferenceExpression expression)
            {
                yield break;
            }

            public override IEnumerable<CollectedLicense> VisitScope(object? context, SpdxScopeExpression expression)
            {
                return expression.Expression.Accept(context, this);
            }

            public override IEnumerable<CollectedLicense> VisitWith(object? context, SpdxWithExpression expression)
            {
                foreach (var item in expression.Expression.Accept(context, this))
                {
                    var license = new CollectedLicense(item.Id);
                    license.Exceptions.AddRange(item.Exceptions);
                    license.Exceptions.Add(expression.Exception.Id);
                    yield return license;
                }
            }
        }
    }
}
