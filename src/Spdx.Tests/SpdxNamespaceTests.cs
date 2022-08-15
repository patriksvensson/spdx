namespace Spdx.Tests;

public sealed class SpdxNamespaceTests
{
    public sealed class TheFromUriMethod
    {
        [Fact]
        public void Should_Create_Namespace()
        {
            // Given, When
            var result = SpdxDocumentUri.FromUri("spectresystems.se/spdx-documents/spdx-example-444504E0-4F89-41D3-9A0C-0305E82C3301");

            // Then
            result.Website.ShouldBe("spectresystems.se");
            result.PathToSpdx.ShouldBe("spdx-documents");
            result.DocumentName.ShouldBe("spdx-example");
            result.UUID.ShouldBe("444504E0-4F89-41D3-9A0C-0305E82C3301");
        }
    }

    public sealed class FromDocumentName
    {
        [Fact]
        public void Should_Create_Namespace_With_Default_Website_And_Path()
        {
            // Given, When
            var result = SpdxDocumentUri.FromDocumentName("spdx-example", new Guid("444504E0-4F89-41D3-9A0C-0305E82C3301"));

            // Then
            result.Website.ShouldBe("spdx.org");
            result.PathToSpdx.ShouldBe("spdxdocs");
            result.DocumentName.ShouldBe("spdx-example");
            result.UUID.ShouldBe("444504E0-4F89-41D3-9A0C-0305E82C3301");
        }
    }

    public sealed class TheToStringMethod
    {
        [Fact]
        public void Should_Return_Equivilant_URI()
        {
            // Given
            var uri = SpdxDocumentUri.FromUri("https://spectresystems.se/spdx-documents/spdx-example-444504E0-4F89-41D3-9A0C-0305E82C3301");

            // When
            var result = uri.ToString();

            // Then
            result.ShouldBe("https://spectresystems.se/spdx-documents/spdx-example-444504E0-4F89-41D3-9A0C-0305E82C3301");
        }
    }
}
