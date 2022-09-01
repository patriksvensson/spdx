namespace Spdx.Document;

internal static class SpdxValidator
{
    public static void Validate<TPackage, TFile, TRelationship, TExtractedLicense>(
        SpdxValidationContext context,
        SpdxDocument<TPackage, TFile, TRelationship, TExtractedLicense> document)
            where TPackage : SpdxPackage
            where TFile : SpdxFile
            where TRelationship : SpdxRelationship
            where TExtractedLicense : SpdxExtractedLicense
    {
        using (context.PushPath("Document"))
        {
            if (string.IsNullOrWhiteSpace(document.SpdxVersion))
            {
                context.AddError(nameof(SpdxDocument.SpdxVersion), "SPDX Version is required")
                    .WithInfo("Hint", $"See property '{nameof(SpdxDocument.SpdxVersion)}'")
                    .WithInfo("Link", "https://spdx.github.io/spdx-spec/document-creation-information/#61-spdx-version-field");
            }

            if (string.IsNullOrWhiteSpace(document.DataLicense))
            {
                context.AddError(nameof(SpdxDocument.DataLicense), "Data license is required")
                    .WithInfo("Hint", $"See property '{nameof(SpdxDocument.DataLicense)}'")
                    .WithInfo("Link", "https://spdx.github.io/spdx-spec/document-creation-information/#62-data-license-field");
            }

            if (string.IsNullOrWhiteSpace(document.SpdxId))
            {
                context.AddError(nameof(SpdxDocument.SpdxId), "SPDX identifier is required")
                    .WithInfo("Hint", $"See property '{nameof(SpdxDocument.SpdxId)}'")
                    .WithInfo("Link", "https://spdx.github.io/spdx-spec/document-creation-information/#63-spdx-identifier-field");
            }

            if (string.IsNullOrWhiteSpace(document.DocumentName))
            {
                context.AddError(nameof(SpdxDocument.DocumentName), "Document name is required")
                    .WithInfo("Hint", $"See property '{nameof(SpdxDocument.DocumentName)}'")
                    .WithInfo("Link", "https://spdx.github.io/spdx-spec/document-creation-information/#64-document-name-field");
            }

            if (string.IsNullOrWhiteSpace(document.DocumentNamespace))
            {
                context.AddError(nameof(SpdxDocument.DocumentNamespace), "Document namespace is required")
                    .WithInfo("Hint", $"See property '{nameof(SpdxDocument.DocumentNamespace)}'")
                    .WithInfo("Link", "https://spdx.github.io/spdx-spec/document-creation-information/#65-spdx-document-namespace-field");
            }

            if (document.CreationInfo == null)
            {
                context.AddError(nameof(SpdxDocument.CreationInfo), "Document creation information is required")
                    .WithInfo("Hint", $"See property '{nameof(SpdxDocument.CreationInfo)}'");
            }
            else
            {
                using (context.PushPath(nameof(SpdxDocument.CreationInfo)))
                {
                    if (document.CreationInfo.Creators == null || document.CreationInfo.Creators.Count == 0)
                    {
                        context.AddError(nameof(SpdxDocument.CreationInfo.Creators), "At least one creator is required")
                            .WithInfo("Hint", $"See property '{nameof(SpdxDocument.CreationInfo.Creators)}'")
                            .WithInfo("Link", "https://spdx.github.io/spdx-spec/document-creation-information/#68-creator-field");
                    }

                    if (document.CreationInfo.Created == null)
                    {
                        context.AddError(nameof(SpdxDocument.CreationInfo.Created), "Creation timestamp is required")
                            .WithInfo("Hint", $"See property '{nameof(SpdxDocument.CreationInfo.Created)}'")
                            .WithInfo("Link", "https://spdx.github.io/spdx-spec/document-creation-information/#69-created-field");
                    }
                }
            }

            if (document.Packages?.Count > 0)
            {
                using (context.PushPath("Packages"))
                {
                    foreach (var (index, _, _, package) in document.Packages.Enumerate())
                    {
                        using (context.PushPath($"[{index}]"))
                        {
                            ValidatePackage(context, package);
                        }
                    }
                }
            }

            if (document.Files?.Count > 0)
            {
                using (context.PushPath("Files"))
                {
                    foreach (var (index, _, _, file) in document.Files.Enumerate())
                    {
                        using (context.PushPath($"[{index}]"))
                        {
                            ValidateFile(context, file);
                        }
                    }
                }
            }

            if (document.Relationships?.Count > 0)
            {
                using (context.PushPath("Relationships"))
                {
                    foreach (var (index, _, _, relationship) in document.Relationships.Enumerate())
                    {
                        using (context.PushPath($"[{index}]"))
                        {
                            ValidateRelationship(context, relationship);
                        }
                    }
                }
            }

            if (document.ExtractedLicenses?.Count > 0)
            {
                using (context.PushPath("ExtractedLicenses"))
                {
                    foreach (var (index, _, _, license) in document.ExtractedLicenses.Enumerate())
                    {
                        using (context.PushPath($"[{index}]"))
                        {
                            ValidateExtractedLicense(context, license);
                        }
                    }
                }
            }
        }
    }

    private static void ValidatePackage(SpdxValidationContext context, SpdxPackage package)
    {
        if (string.IsNullOrWhiteSpace(package.SpdxId))
        {
            context.AddError(nameof(SpdxPackage.SpdxId), "SPDX package identifier is required")
                .WithInfo("Hint", $"See property '{nameof(SpdxPackage.SpdxId)}'")
                .WithInfo("Link", "https://spdx.github.io/spdx-spec/package-information/#72-package-spdx-identifier-field");
        }

        if (string.IsNullOrWhiteSpace(package.PackageName))
        {
            context.AddError(nameof(SpdxPackage.PackageName), "SPDX package identifier is required")
                .WithInfo("Hint", $"See property '{nameof(SpdxPackage.PackageName)}'")
                .WithInfo("Link", "https://spdx.github.io/spdx-spec/package-information/#71-package-name-field");
        }

        if (string.IsNullOrWhiteSpace(package.PackageDownloadLocation))
        {
            context.AddError(nameof(SpdxPackage.PackageDownloadLocation), "Package download location is required")
                .WithInfo("Hint", $"See property '{nameof(SpdxPackage.PackageDownloadLocation)}'")
                .WithInfo("Link", "https://spdx.github.io/spdx-spec/package-information/#77-package-download-location-field");
        }

        if (string.IsNullOrWhiteSpace(package.LicenseConcluded))
        {
            context.AddError(nameof(SpdxPackage.LicenseConcluded), "Concluded license for package is required")
                .WithInfo("Hint", $"See property '{nameof(SpdxPackage.LicenseConcluded)}'")
                .WithInfo("Link", "https://spdx.github.io/spdx-spec/package-information/#713-concluded-license-field");
        }

        if (string.IsNullOrWhiteSpace(package.LicenseDeclared))
        {
            context.AddError(nameof(SpdxPackage.LicenseDeclared), "Declared license for package is required")
                .WithInfo("Hint", $"See property '{nameof(SpdxPackage.LicenseDeclared)}'")
                .WithInfo("Link", "https://spdx.github.io/spdx-spec/package-information/#715-declared-license-field");
        }

        if (string.IsNullOrWhiteSpace(package.CopyrightText))
        {
            context.AddError(nameof(SpdxPackage.CopyrightText), "Package copyright text is required")
                .WithInfo("Hint", $"See property '{nameof(SpdxPackage.CopyrightText)}'")
                .WithInfo("Link", "https://spdx.github.io/spdx-spec/package-information/#717-copyright-text-field");
        }

        if (package.Checksums != null)
        {
            using (context.PushPath("Checksums"))
            {
                foreach (var (index, _, _, checksum) in package.Checksums.Enumerate())
                {
                    using (context.PushPath($"[{index}]"))
                    {
                        ValidateChecksum(context, checksum);
                    }
                }
            }
        }
    }

    private static void ValidateFile(SpdxValidationContext context, SpdxFile file)
    {
        if (string.IsNullOrWhiteSpace(file.SpdxId))
        {
            context.AddError(nameof(SpdxFile.SpdxId), "SPDX file identifier is required")
                .WithInfo("Hint", $"See property '{nameof(SpdxFile.SpdxId)}'")
                .WithInfo("Link", "https://spdx.github.io/spdx-spec/file-information/#82-file-spdx-identifier-field");
        }

        if (string.IsNullOrWhiteSpace(file.Filename))
        {
            context.AddError(nameof(SpdxFile.Filename), "Filename is required")
                .WithInfo("Hint", $"See property '{nameof(SpdxFile.Filename)}'")
                .WithInfo("Link", "https://spdx.github.io/spdx-spec/file-information/#81-file-name-field");
        }

        if (file.Checksums?.Count > 0)
        {
            using (context.PushPath("Checksums"))
            {
                foreach (var (index, _, _, checksum) in file.Checksums.Enumerate())
                {
                    using (context.PushPath($"[{index}]"))
                    {
                        ValidateChecksum(context, checksum);
                    }
                }
            }

            var hasSha1 = file.Checksums.Any(c => c.Algorithm?.Equals("SHA1", StringComparison.Ordinal) ?? false);
            if (!hasSha1)
            {
                context.AddError(nameof(SpdxFile.Checksums), "If checksums are present, at least one need to be SHA1")
                    .WithInfo("Hint", $"See property '{nameof(SpdxFile.Checksums)}'")
                    .WithInfo("Link", "https://spdx.github.io/spdx-spec/file-information/#84-file-checksum-field");
            }
        }

        if (string.IsNullOrWhiteSpace(file.LicenseConcluded))
        {
            context.AddError(nameof(SpdxFile.LicenseConcluded), "Concluded license for file is required")
                .WithInfo("Hint", $"See property '{nameof(SpdxFile.LicenseConcluded)}'")
                .WithInfo("Link", "https://spdx.github.io/spdx-spec/file-information/#85-concluded-license-field");
        }

        if (file.LicenseInfoInFiles == null || file.LicenseInfoInFiles.Count == 0)
        {
            context.AddError(nameof(SpdxFile.LicenseInfoInFiles), "License information found in file required. If none, set to 'NONE'")
                .WithInfo("Hint", $"See property '{nameof(SpdxFile.LicenseInfoInFiles)}'")
                .WithInfo("Link", "https://spdx.github.io/spdx-spec/file-information/#86-license-information-in-file-field");
        }

        if (string.IsNullOrWhiteSpace(file.CopyrightText))
        {
            context.AddError(nameof(SpdxFile.CopyrightText), "File copyright text is required")
                .WithInfo("Hint", $"See property '{nameof(SpdxFile.CopyrightText)}'")
                .WithInfo("Link", "https://spdx.github.io/spdx-spec/file-information/#88-copyright-text-field");
        }
    }

    private static void ValidateChecksum(SpdxValidationContext context, SpdxChecksum checksum)
    {
        if (string.IsNullOrWhiteSpace(checksum.Algorithm))
        {
            context.AddError(nameof(SpdxChecksum.Algorithm), "Checksum algorithm is required")
                .WithInfo("Hint", $"See property '{nameof(SpdxChecksum.Algorithm)}'")
                .WithInfo("Accepted", string.Join(", ", SpdxChecksum.Algorithms));
        }
        else if (!SpdxChecksum.Algorithms.Contains(checksum.Algorithm))
        {
            context.AddError(nameof(SpdxChecksum.Algorithm), $"Unknown checksum algorithm '{checksum.Algorithm}'")
                .WithInfo("Hint", $"See property '{nameof(SpdxChecksum.Algorithm)}'")
                .WithInfo("Accepted", string.Join(", ", SpdxChecksum.Algorithms));
        }

        if (string.IsNullOrWhiteSpace(checksum.Value))
        {
            context.AddError(nameof(SpdxChecksum.Value), "Checksum value is required")
                .WithInfo("Hint", $"See property '{nameof(SpdxChecksum.Value)}'");
        }
    }

    private static void ValidateRelationship(SpdxValidationContext context, SpdxRelationship relationship)
    {
        if (string.IsNullOrWhiteSpace(relationship.Identifier))
        {
            context.AddError(nameof(SpdxRelationship.Identifier), "Relationship identifier is required")
                .WithInfo("Hint", $"See property '{nameof(SpdxRelationship.Identifier)}'");
        }

        if (string.IsNullOrWhiteSpace(relationship.RelatedIdentifier))
        {
            context.AddError(nameof(SpdxRelationship.RelatedIdentifier), "Related relationship identifier is required")
                .WithInfo("Hint", $"See property '{nameof(SpdxRelationship.RelatedIdentifier)}'");
        }

        if (string.IsNullOrWhiteSpace(relationship.Type))
        {
            context.AddError(nameof(SpdxRelationship.Type), "Relationship type is required")
                .WithInfo("Hint", $"See property '{nameof(SpdxRelationship.Type)}'")
                .WithInfo("Accepted", string.Join(", ", SpdxRelationship.Types));
        }
        else
        {
            if (!SpdxRelationship.Types.Contains(relationship.Type))
            {
                context.AddError(nameof(SpdxRelationship.Type), $"Unknown relationship type '{relationship.Type}'")
                    .WithInfo("Hint", $"See property '{nameof(SpdxRelationship.Type)}'")
                    .WithInfo("Accepted", string.Join(", ", SpdxRelationship.Types));
            }
        }
    }

    private static void ValidateExtractedLicense(SpdxValidationContext context, SpdxExtractedLicense license)
    {
        if (string.IsNullOrWhiteSpace(license.LicenseId))
        {
            context.AddError(nameof(SpdxExtractedLicense.LicenseId), "License ID is required")
                .WithInfo("Hint", $"See property '{nameof(SpdxExtractedLicense.LicenseId)}'")
                .WithInfo("Link", "https://spdx.github.io/spdx-spec/other-licensing-information-detected/#101-license-identifier-field");
        }
        else if (string.IsNullOrWhiteSpace(license.ExtractedText))
        {
            context.AddError(nameof(SpdxExtractedLicense.ExtractedText), "Extracted text is required")
                .WithInfo("Hint", $"See property '{nameof(SpdxExtractedLicense.ExtractedText)}'")
                .WithInfo("Link", "https://spdx.github.io/spdx-spec/other-licensing-information-detected/#102-extracted-text-field");
        }
    }
}
