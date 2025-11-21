namespace Spdx.Tests;

public sealed class SpdxExtractedLicenseTests
{
    [ExpectationPath("ExtractedLicense/Validation")]
    public sealed class TheValidateMethod
    {
        [Fact]
        [Expectation("LicenseId")]
        public Task Should_Have_LicenseId()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.ExtractedLicenses = new List<SpdxExtractedLicense>
            {
                new SpdxExtractedLicense
                {
                    LicenseId = null!,
                },
            };

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("ExtractedText")]
        public Task Should_Have_Extracted_Text()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.ExtractedLicenses = new List<SpdxExtractedLicense>
            {
                new SpdxExtractedLicense
                {
                    LicenseId = "Foo",
                    LicenseName = "The Foo license",
                },
            };

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }
    }
}
