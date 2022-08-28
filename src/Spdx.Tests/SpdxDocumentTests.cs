using Spdx.Tests.Extensions;

namespace Spdx.Tests;

public sealed class SpdxDocumentTests
{
    [UsesVerify]
    [ExpectationPath("Document/Serialization")]
    public sealed class TheSerializeMethod
    {
        [Fact]
        [Expectation("Json")]
        public Task Should_Serialize()
        {
            // Given
            var document = SpdxDocumentFixture.Create();

            // When
            var result = document.Serialize(SpdxDocumentFormat.Json);

            // Then
            return Verify(result);
        }

        [Fact]
        public void Should_Throw_If_Validation_Failed()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.SpdxId = null!;

            // When
            var result = Record.Exception(() => document.Serialize(SpdxDocumentFormat.Json));

            // Then
            result.ShouldBeOfType<SpdxSerializationException>().And(ex =>
            {
                ex.Message.ShouldBe("The SPDX document is not valid. See report for more information");

                ex.Report.ShouldNotBeNull();
                ex.Report.Errors.Count.ShouldBe(1);
                ex.Report.Errors[0].Message.ShouldBe("SPDX identifier is required");
            });
        }
    }

    public sealed class TheTrySerializeMethod
    {
        [Fact]
        public void Should_Return_True_If_Serialization_Succeeded()
        {
            // Given
            var document = SpdxDocumentFixture.Create();

            // When
            var result = document.TrySerialize(SpdxDocumentFormat.Json, out var output);

            // Then
            result.ShouldBeTrue();
            output.ShouldNotBeNull();
        }

        [Fact]
        public void Should_Return_False_If_Serialization_Succeeded()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.SpdxId = null!;

            // When
            var result = document.TrySerialize(SpdxDocumentFormat.Json, out var output);

            // Then
            result.ShouldBeFalse();
            output.ShouldBeNull();
        }
    }

    [UsesVerify]
    [ExpectationPath("Document/Validation")]
    public sealed class TheValidateMethod
    {
        [Fact]
        [Expectation("SPDXVersion")]
        public Task Should_Have_SPDX_Version()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.SpdxVersion = null!;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("DataLicense")]
        public Task Should_Have_DataLicense()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.DataLicense = null!;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("SPDXID")]
        public Task Should_Have_SPDXID()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.SpdxId = null!;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("DocumentName")]
        public Task Should_Have_DocumentName()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.DocumentName = null!;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("DocumentNamespace")]
        public Task Should_Have_DocumentNamespace()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.DocumentNamespace = null!;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("CreationInfo")]
        public Task Should_Have_CreationInfo()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.CreationInfo = null!;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("Creators")]
        public Task Should_Have_Creators()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.CreationInfo.Creators.Clear();

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("Creators_Null")]
        public Task Should_Have_Non_Null_Creators()
        {
            // Given
            var document = new SpdxDocument
            {
                SpdxId = "SPDXRef-DOCUMENT",
                DocumentName = "hades",
                DocumentNamespace = "http://spdx.org/spdxdocs/hades-9906A8B7-A923-40B6-ACC1-4D36F7E1FF6D",
                CreationInfo = new SpdxCreationInfo
                {
                    Created = new DateTimeOffset(2020, 08, 19, 19, 44, 12, TimeSpan.Zero),
                    Creators = null!,
                },
            };

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }

        [Fact]
        [Expectation("Created")]
        public Task Should_Have_Created_Timestamp()
        {
            // Given
            var document = SpdxDocumentFixture.Create();
            document.CreationInfo.Created = null;

            // When
            var result = document.Validate();

            // Then
            return Verify(result);
        }
    }
}