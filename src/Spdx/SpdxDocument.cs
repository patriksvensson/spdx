namespace Spdx;

public sealed class SpdxDocument : ISpdxValidatable
{
    // Constants
    public string Version { get; } = "SPDX-2.2";
    public string DataLicense { get; } = "CC0-1.0";

    // Required
    public string? Identifier { get; set; }
    public string? Name { get; set; }
    public SpdxDocumentUri? Namespace { get; set; }
    public SpdxCreationInfo? CreationInfo { get; set; }

    // Optional
    public List<SpdxExternalDocumentRef> ExternalDocumentRefs { get; init; } = new List<SpdxExternalDocumentRef>();
    public string? Comment { get; set; }

    public SpdxValidationReport Validate()
    {
        var context = new SpdxValidationContext();
        ((ISpdxValidatable)this).Validate(context);
        return context.CreateReport();
    }

    public string Serialize()
    {
        return SpdxTagSerializer.Shared.Serialize(this);
    }

    void ISpdxValidatable.Validate(SpdxValidationContext context)
    {
        if (string.IsNullOrWhiteSpace(Identifier))
        {
            context.AddError("Identifier is missing");
        }

        if (string.IsNullOrWhiteSpace(Name))
        {
            context.AddError("Name is missing");
        }

        if (Namespace == null)
        {
            context.AddError("Namespace is missing");
        }

        if (CreationInfo == null)
        {
            context.AddError("Creation info is missing");
        }
        else
        {
            using (context.PushPath("CreationInfo"))
            {
                ((ISpdxValidatable)CreationInfo).Validate(context);
            }
        }
    }
}
