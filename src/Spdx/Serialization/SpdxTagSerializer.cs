using System.Globalization;

namespace Spdx.Serialization;

internal sealed class SpdxTagSerializer : ISpdxSerializer
{
    public static SpdxTagSerializer Shared { get; } = new SpdxTagSerializer();

    public string Serialize(SpdxDocument document)
    {
        var builder = new StringBuilder();

        builder.Append("SPDXVersion: ").AppendLine(document.Version);
        builder.Append("DataLicense: ").AppendLine(document.DataLicense);
        builder.Append("SPDXID: ").AppendLine(document.Identifier);
        builder.Append("DocumentName: ").AppendLine(document.Name);
        builder.Append("DocumentNamespace: ").Append(document.Namespace).AppendLine();

        if (document.Comment != null)
        {
            builder.Append("DocumentComment: ").AppendLine(document.Comment);
        }

        if (document.ExternalDocumentRefs.Count > 0)
        {
            builder.AppendLine();
            builder.AppendLine("# External references");

            foreach (var foo in document.ExternalDocumentRefs)
            {
                var value = BitConverter.ToString(foo.Checksum.Value).Replace("-", string.Empty);
                var externalRef = $"{foo.Identifier} {foo.DocumentUri} {foo.Checksum.Algorithm}: {value}";
                builder.Append("ExternalDocumentRef: ").AppendLine(externalRef);
            }
        }

        if (document.CreationInfo != null)
        {
            builder.AppendLine();
            builder.AppendLine("# Creation info");

            if (document.CreationInfo.Created != null)
            {
                var created = document.CreationInfo.Created.Value.ToUniversalTime();
                builder.Append("Created: ").AppendLine(created.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture));
            }

            if (document.CreationInfo.Comment != null)
            {
                builder.Append("CreatorComment: ").AppendLine(document.CreationInfo.Comment);
            }

            if (document.CreationInfo.LicenseListVersion != null)
            {
                builder.Append("LicenseListVersion: ").AppendLine(document.CreationInfo.LicenseListVersion);
            }

            foreach (var creator in document.CreationInfo.Creators)
            {
                builder.Append("Creator: ").AppendLine(creator.ToString());
            }
        }

        return builder.ToString();
    }
}
