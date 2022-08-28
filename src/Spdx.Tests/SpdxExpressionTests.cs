using Spdx.Expressions;
using Spdx.Tests.Extensions;

namespace Spdx.Tests
{
    public sealed class SpdxExpressionTests
    {
        public sealed class TheParseMethod
        {
            [Fact]
            public void Should_Parse_Expression()
            {
                // Given, When
                var result = SpdxExpression.Parse("(MIT AND Apache-2.0+ AND DocumentRef-foo:LicenseRef-bar) WITH gnu-javamail-exception");

                // When
                result.ShouldBeOfType<SpdxWithExpression>().And(with =>
                {
                    with.Expression.ShouldBeOfType<SpdxScopeExpression>().And(scope =>
                    {
                        scope.Expression.ShouldBeOfType<SpdxAndExpression>().And(and =>
                        {
                            and.Left.ShouldBeOfType<SpdxAndExpression>().And(and2 =>
                            {
                                and2.Left.ShouldBeOfType<SpdxLicenseExpression>().And(node =>
                                {
                                    node.Id.ShouldBe("MIT");
                                    node.OrLater.ShouldBe(false);
                                });
                                and2.Right.ShouldBeOfType<SpdxLicenseExpression>().And(node =>
                                {
                                    node.Id.ShouldBe("Apache-2.0");
                                    node.OrLater.ShouldBe(true);
                                });
                            });
                            and.Right.ShouldBeOfType<SpdxLicenseReferenceExpression>().And(node =>
                            {
                                node.DocumentReference.ShouldBe("foo");
                                node.LicenseRef.ShouldBe("bar");
                            });
                        });
                    });

                    with.Exception.ShouldNotBeNull().And(node => node.Id.ShouldBe("gnu-javamail-exception"));
                });
            }

            [Fact]
            public void Should_Parse_Expression_With_Document_And_License_Reference()
            {
                // Given, When
                var result = SpdxExpression.Parse("MIT AND DocumentRef-foo:LicenseRef-bar");

                // When
                result.ShouldBeOfType<SpdxAndExpression>().And(and =>
                {
                    and.Left.ShouldBeOfType<SpdxLicenseExpression>().And(x => x.Id.ShouldBe("MIT"));
                    and.Right.ShouldBeOfType<SpdxLicenseReferenceExpression>().And(reference =>
                    {
                        reference.DocumentReference.ShouldBe("foo");
                        reference.LicenseRef.ShouldBe("bar");
                    });
                });
            }

            [Fact]
            public void Should_Parse_Expression_With_License_Reference()
            {
                // Given, When
                var result = SpdxExpression.Parse("MIT AND LicenseRef-bar");

                // When
                result.ShouldBeOfType<SpdxAndExpression>().And(and =>
                {
                    and.Left.ShouldBeOfType<SpdxLicenseExpression>().And(x => x.Id.ShouldBe("MIT"));
                    and.Right.ShouldBeOfType<SpdxLicenseReferenceExpression>().And(reference =>
                    {
                        reference.DocumentReference.ShouldBeEmpty();
                        reference.LicenseRef.ShouldBe("bar");
                    });
                });
            }

            [Fact]
            public void Should_Consider_WITH_To_Have_Higher_Precedence()
            {
                // Given, When
                var result = SpdxExpression.Parse("MIT AND Apache-2.0+ WITH gnu-javamail-exception");

                // When
                result.ShouldBeOfType<SpdxWithExpression>().And(with =>
                {
                    with.Expression.ShouldBeOfType<SpdxAndExpression>().And(and =>
                    {
                        and.Left.ShouldBeOfType<SpdxLicenseExpression>().And(node =>
                        {
                            node.Id.ShouldBe("MIT");
                            node.OrLater.ShouldBe(false);
                        });
                        and.Right.ShouldBeOfType<SpdxLicenseExpression>().And(node =>
                        {
                            node.Id.ShouldBe("Apache-2.0");
                            node.OrLater.ShouldBe(true);
                        });
                    });

                    with.Exception.ShouldNotBeNull().And(node => node.Id.ShouldBe("gnu-javamail-exception"));
                });
            }

            [Fact]
            public void Should_Return_Error_If_Right_Part_Of_WITH_Is_Not_An_Exception()
            {
                // Given, When
                var result = Record.Exception(() => SpdxExpression.Parse("MIT WITH Apache-2.0+"));

                // Then
                result.ShouldNotBeNull();
                result.Message.ShouldBe("The right side of WITH clause must be an SPDX license exception");
            }

            [Fact]
            public void Should_Return_Error_If_License_Is_Unknown()
            {
                // Given, When
                var result = Record.Exception(() => SpdxExpression.Parse("PATRIK"));

                // Then
                result.ShouldNotBeNull();
                result.Message.ShouldBe("Invalid SPDX license 'PATRIK'");
            }

            [Fact]
            public void Should_Not_Return_Error_When_License_Is_Unknown_If_Parsing_Allows_Unknown_Licenses()
            {
                // Given, When
                var result = SpdxExpression.Parse("PATRIK", SpdxLicenseOptions.AllowUnknownLicenses);

                // Then
                result.ShouldNotBeNull();
                result.ShouldBeOfType<SpdxLicenseExpression>()
                    .And(license => license.Id.ShouldBe("PATRIK"));
            }

            [Fact]
            public void Should_Not_Return_Error_When_License_Is_Unknown_If_Parsing_Is_Relaxed()
            {
                // Given, When
                var result = SpdxExpression.Parse("PATRIK", SpdxLicenseOptions.Relaxed);

                // Then
                result.ShouldNotBeNull();
                result.ShouldBeOfType<SpdxLicenseExpression>()
                    .And(license => license.Id.ShouldBe("PATRIK"));
            }

            [Fact]
            public void Should_Return_Error_If_License_Exception_Is_Unknown()
            {
                // Given, When
                var result = Record.Exception(() => SpdxExpression.Parse("MIT WITH PATRIK"));

                // Then
                result.ShouldNotBeNull();
                result.Message.ShouldBe("Invalid SPDX license exception 'PATRIK'");
            }

            [Fact]
            public void Should_Not_Return_Error_If_License_Exception_Is_Unknown_If_Parsing_Is_Relaxed()
            {
                // Given, When
                var result = SpdxExpression.Parse("MIT WITH PATRIK", SpdxLicenseOptions.Relaxed);

                // Then
                result.ShouldNotBeNull();
                result.ShouldBeOfType<SpdxWithExpression>().And(with =>
                {
                    with.Expression.ShouldBeOfType<SpdxLicenseExpression>()
                        .And(license => license.Id.ShouldBe("MIT"));

                    with.Exception.ShouldBeOfType<SpdxLicenseExceptionExpression>()
                        .And(license => license.Id.ShouldBe("PATRIK"));
                });
            }
        }

        public sealed class TheTryParseMethod
        {
            [Fact]
            public void Should_Not_Throw_When_Encountering_Invalid_Expression()
            {
                // Given, When
                var result = SpdxExpression.TryParse("FOO ORZ BAR", out var parsed);

                // Then
                result.ShouldBeFalse();
                parsed.ShouldBeNull();
            }
        }

        public sealed class TheIsValidExpressionMethod
        {
            [Fact]
            public void Should_Return_True_For_Valid_Expression()
            {
                // Given, When
                var result = SpdxExpression.IsValidExpression("MIT OR Apache-2.0");

                // Then
                result.ShouldBeTrue();
            }

            [Fact]
            public void Should_Return_False_For_Invalid_Expression()
            {
                // Given, When
                var result = SpdxExpression.IsValidExpression("MIT OR LOL");

                // Then
                result.ShouldBeFalse();
            }

            [Fact]
            public void Should_Return_True_For_Valid_Expression_With_Unknown_License_If_Parsing_Is_Relazed()
            {
                // Given, When
                var result = SpdxExpression.IsValidExpression("MIT OR LOL", SpdxLicenseOptions.Relaxed);

                // Then
                result.ShouldBeTrue();
            }
        }
    }
}
