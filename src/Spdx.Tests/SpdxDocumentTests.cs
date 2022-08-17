namespace Spdx.Tests;

public sealed class SpdxDocumentTests
{
    [Fact]
    public void Should_Validate_Document()
    {
        // Given
        var document = new SpdxDocument
        {
            Name = "Foo",
            Identifier = "Bar",
            Comment = "A document describing Foo",
            Namespace = SpdxDocumentUri.FromDocumentName("Baz", new Guid("FFD43F1A-5415-434A-B2D2-23C8175745FD")),
            CreationInfo = new SpdxCreationInfo
            {
                Created = DateTimeOffset.Now,
                Comment = "Created by Hades",
                Creators = new List<SpdxCreator>
                {
                    SpdxCreator.Person("Patrik Svensson"),
                    SpdxCreator.Organization("Spectre Systems"),
                    SpdxCreator.Tool("Hades", "1.2.3"),
                },
            },
        };

        // When
        var result = document.Validate();

        // Then
        result.Successful.ShouldBeTrue();
    }

    public sealed class TheSerializeMethod
    {
        [Fact]
        public void Should_Serialize_Message()
        {
            // Given
            var document = new SpdxDocument
            {
                Name = "Foo",
                Identifier = "Bar",
                Comment = "A document describing Foo",
                Namespace = SpdxDocumentUri.FromDocumentName("Baz", new Guid("FFD43F1A-5415-434A-B2D2-23C8175745FD")),
                ExternalDocumentRefs = new List<SpdxExternalDocumentRef>
                {
                    new SpdxExternalDocumentRef(
                        "Foo",
                        SpdxDocumentUri.FromDocumentName("Qux", new Guid("FFD43F1A-5415-434A-B2D2-23C8175745FD")),
                        new SpdxChecksum(SpdxChecksumAlgorithm.SHA1, new byte[] { 1, 2, 3 })),
                },
                CreationInfo = new SpdxCreationInfo
                {
                    Created = DateTimeOffset.Now,
                    Comment = "Created by Hades",
                    Creators = new List<SpdxCreator>
                    {
                        SpdxCreator.Person("Patrik Svensson"),
                        SpdxCreator.Organization("Spectre Systems"),
                        SpdxCreator.Tool("Hades", "1.2.3"),
                    },
                },
            };

            // When
            var result = document.Serialize();

            // Then
            result.ShouldBe("");
        }
    }
}
