using System.Globalization;

namespace Spdx.Document;

internal sealed class SpdxJsonSerializer
{
    public static string Serialize<TPackage, TFile, TRelationship>(
        SpdxDocument<TPackage, TFile, TRelationship> document)
            where TPackage : SpdxPackage
            where TFile : SpdxFile
            where TRelationship : SpdxRelationship
    {
        if (document is null)
        {
            throw new ArgumentNullException(nameof(document));
        }

        using (var writer = new JsonWriterEx())
        {
            using (writer.WriteObject())
            {
                writer.WriteProperty("SPDXID", document.SpdxId);
                writer.WriteProperty("spdxVersion", document.SpdxVersion);
                writer.WriteProperty("dataLicense", document.DataLicense);
                writer.WriteProperty("name", document.DocumentName);
                writer.WriteProperty("documentNamespace", document.DocumentNamespace);

                if (document.CreationInfo != null)
                {
                    WriteCreationInfo(writer, document.CreationInfo);
                }

                if (document.Packages?.Count > 0)
                {
                    using (writer.WriteArray("packages"))
                    {
                        foreach (var package in document.Packages)
                        {
                            WritePackage(writer, package);
                        }
                    }
                }

                if (document.Files?.Count > 0)
                {
                    using (writer.WriteArray("files"))
                    {
                        foreach (var file in document.Files)
                        {
                            WriteFile(writer, file);
                        }
                    }
                }

                if (document.Relationships?.Count > 0)
                {
                    using (writer.WriteArray("relationships"))
                    {
                        foreach (var relationship in document.Relationships)
                        {
                            WriteRelationship(writer, relationship);
                        }
                    }
                }
            }

            return writer.ToString();
        }
    }

    private static void WriteCreationInfo(JsonWriterEx writer, SpdxCreationInfo info)
    {
        if (info == null)
        {
            return;
        }

        using (writer.WriteObject("creationInfo"))
        {
            if (info.LicenseListVersion != null)
            {
                writer.WriteProperty("licenseListVersion", info.LicenseListVersion);
            }

            if (info.Created != null)
            {
                var created = info.Created.Value.ToUniversalTime();
                writer.WriteProperty("created", created.ToString("yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture));
            }

            if (info.Creators?.Count > 0)
            {
                writer.WriteArray("creators", info.Creators);
            }
        }
    }

    private static void WritePackage(JsonWriterEx writer, SpdxPackage package)
    {
        using (writer.WriteObject())
        {
            writer.WriteProperty("SPDXID", package.SpdxId);
            writer.WriteProperty("name", package.PackageName);
            writer.WriteProperty("versionInfo", package.VersionInfo);

            if (package.Checksums?.Count > 0)
            {
                using (writer.WriteArray("checksums"))
                {
                    foreach (var checksum in package.Checksums)
                    {
                        using (writer.WriteObject())
                        {
                            writer.WriteProperty("algorithm", checksum.Algorithm);
                            writer.WriteProperty("checksumValue", checksum.Value);
                        }
                    }
                }
            }

            writer.WriteProperty("copyrightText", package.CopyrightText);
            writer.WriteProperty("downloadLocation", package.PackageDownloadLocation);
            writer.WriteProperty("filesAnalyzed", package.FilesAnalyzed);
            writer.WriteProperty("licenseConcluded", package.LicenseConcluded);
            writer.WriteProperty("licenseDeclared", package.LicenseDeclared);
            writer.WriteProperty("supplier", package.Supplier);

            if (package.PackageVerificationCode != null)
            {
                using (writer.WriteObject("packageVerificationCode"))
                {
                    writer.WriteProperty("packageVerificationCodeValue", package.PackageVerificationCode.Value);

                    if (package.PackageVerificationCode.ExcludedFiles?.Count > 0)
                    {
                        writer.WriteArray(
                            "packageVerificationCodeExcludedFiles",
                            package.PackageVerificationCode.ExcludedFiles);
                    }
                }
            }

            if (package.LicenseInfoFromFiles?.Count > 0)
            {
                writer.WriteArray(
                    "licenseInfoFromFiles",
                    package.LicenseInfoFromFiles);
            }

            if (package.ExternalReferences?.Count > 0)
            {
                using (writer.WriteArray("externalRefs"))
                {
                    foreach (var @ref in package.ExternalReferences)
                    {
                        using (writer.WriteObject())
                        {
                            writer.WriteProperty("referenceCategory", @ref.Category);
                            writer.WriteProperty("referenceType", @ref.Type);
                            writer.WriteProperty("referenceLocator", @ref.Locator);
                        }
                    }
                }
            }
        }
    }

    private static void WriteFile(JsonWriterEx writer, SpdxFile file)
    {
        using (writer.WriteObject())
        {
            writer.WriteProperty("SPDXID", file.SpdxId);
            writer.WriteProperty("fileName", file.Filename);
            writer.WriteProperty("copyrightText", file.CopyrightText);
            writer.WriteProperty("licenseConcluded", file.LicenseConcluded);

            if (file.Checksums != null)
            {
                using (writer.WriteArray("checksums"))
                {
                    foreach (var checksum in file.Checksums)
                    {
                        using (writer.WriteObject())
                        {
                            writer.WriteProperty("algorithm", checksum.Algorithm);
                            writer.WriteProperty("checksumValue", checksum.Value);
                        }
                    }
                }
            }

            if (file.FileTypes.Count > 0)
            {
                writer.WriteArray("fileTypes", file.FileTypes);
            }

            if (file.LicenseInfoInFiles?.Count > 0)
            {
                writer.WriteArray(
                    "licenseInfoInFiles",
                    file.LicenseInfoInFiles);
            }
        }
    }

    private static void WriteRelationship(JsonWriterEx writer, SpdxRelationship relationship)
    {
        using (writer.WriteObject())
        {
            writer.WriteProperty("spdxElementId", relationship.Identifier);
            writer.WriteProperty("relatedSpdxElement", relationship.RelatedIdentifier);
            writer.WriteProperty("relationshipType", relationship.Type);
        }
    }
}
