namespace Spdx.Tests;

public sealed class SpdxPackageTests
{
    [UsesVerify]
    [ExpectationPath("Package/Validation")]
    public sealed class TheValidateMethod
    {
        [Fact]
        [Expectation("SPDXID")]
        public Task Should_Have_SPDXID()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.Packages[1].SpdxId = null!;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("PackageDownloadLocation")]
        public Task Should_Have_PackageDownloadLocation()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.Packages[1].PackageDownloadLocation = null!;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("Checksum_Algorithm")]
        public Task Should_Have_Checksum_Algorithm_For_Checksum()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.Packages[1].Checksums[0].Algorithm = null!;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("Unknown_Checksum_Algorithm")]
        public Task Should_Have_Known_Checksum_Algorithm_For_Checksum()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.Packages[1].Checksums[0].Algorithm = "FOO";

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("Checksum_Value")]
        public Task Should_Have_Checksum_Value_For_Checksum()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.Packages[1].Checksums[0].Value = null!;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }
    }
}
