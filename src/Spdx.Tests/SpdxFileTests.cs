namespace Spdx.Tests;

public sealed class SpdxFileTests
{
    [UsesVerify]
    [ExpectationPath("File/Validation")]
    public sealed class TheValidateMethod
    {
        [Fact]
        [Expectation("SPDXID")]
        public Task Should_Have_SPDXID()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.Files[0].SpdxId = null!;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("Filename")]
        public Task Should_Have_Filename()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.Files[0].Filename = null!;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("LicenseConcluded")]
        public Task Should_Have_LicenseConcluded()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.Files[0].LicenseConcluded = null!;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("CopyrightText")]
        public Task Should_Have_CopyrightText()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.Files[0].CopyrightText = null!;

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
            document.Files[0].Checksums[0].Algorithm = null!;

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
            document.Files[0].Checksums[0].Algorithm = "FOO";

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
            document.Files[0].Checksums[0].Value = null!;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("LicenseInfoInFiles")]
        public Task Should_Have_LicenseInfoInFiles()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.Files[0].LicenseInfoInFiles.Clear();

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }
    }
}
