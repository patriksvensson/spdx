namespace Spdx.Tests;

public sealed class SpdxDocumentBuilderTests
{
    [Fact]
    public void Should_Build_Document()
    {
        // Given
        var builder = new SpdxDocumentBuilder();
        builder.SetName("Foo");
        builder.SetIdentifier("Bar");
        builder.SetNamespace(SpdxDocumentUri.FromDocumentName("Baz", new Guid("FFD43F1A-5415-434A-B2D2-23C8175745FD")));
        builder.SetCreationInfo(info =>
        {
            info.Created = DateTimeOffset.UtcNow;
            info.Creators.Add(SpdxCreator.Person("Patrik Svensson"));
            info.Creators.Add(SpdxCreator.Organization("Spectre Systems AB"));
        });

        // When
        var result = builder.TryBuild(out var diagnostics, out var document);

        // Then
        result.ShouldBeTrue();
    }
}
