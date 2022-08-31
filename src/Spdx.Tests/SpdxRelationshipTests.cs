namespace Spdx.Tests;

public sealed class SpdxRelationshipTests
{
    [UsesVerify]
    [ExpectationPath("Relationship/Validation")]
    public sealed class TheValidateMethod
    {
        [Fact]
        [Expectation("Identifier")]
        public Task Should_Have_Identifier()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.Relationships[0].Identifier = null!;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("RelatedIdentifier")]
        public Task Should_Have_RelatedIdentifier()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.Relationships[0].RelatedIdentifier = null!;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("Type")]
        public Task Should_Have_Type()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.Relationships[0].Type = null!;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("Unknown_Type")]
        public Task Should_Have_Known_Checksum_Algorithm_For_Checksum()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.Relationships[0].Type = "FOO";

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }
    }
}
