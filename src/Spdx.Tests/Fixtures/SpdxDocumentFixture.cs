namespace Spdx.Tests.Fixtures;

public static class SpdxDocumentFixture
{
    public static SpdxDocument Create()
    {
        return new SpdxDocument()
        {
            SpdxId = "SPDXRef-DOCUMENT",
            DocumentName = "hades",
            DocumentNamespace = "http://spdx.org/spdxdocs/hades-9906A8B7-A923-40B6-ACC1-4D36F7E1FF6D",
            CreationInfo = new SpdxCreationInfo
            {
                Created = new DateTimeOffset(2020, 08, 19, 19, 44, 12, TimeSpan.Zero),
                Creators = new List<string>
                    {
                        "Person: Patrik Svensson (patrik@patriksvensson.se)",
                        "Organization: Spectre Systems AB ()",
                    },
            },

            Packages = new List<SpdxPackage>
                {
                    new SpdxPackage
                    {
                        SpdxId = "SPDXRef-Hades",
                        PackageName = "Hades",
                        PackageDownloadLocation = "http://example.com/Hades/Download",
                        CopyrightText = "Copyright 2022 Patrik Svensson",
                        LicenseConcluded = "MIT",
                        LicenseDeclared = "MIT",
                    },

                    new SpdxPackage
                    {
                        SpdxId = "SPDXRef-Foo",
                        PackageName = "Foo",
                        VersionInfo = "3.2.1",
                        CopyrightText = "Copyright 2021-2022 John Smith",
                        PackageDownloadLocation = "http://example.com/Foo/Download",
                        LicenseConcluded = "(MIT OR Apache-2.0)",
                        LicenseDeclared = "(Apache-2.0 OR MIT)",
                        LicenseInfoFromFiles = new List<string> { "Apache-2.0", "MIT" },
                        Supplier = "Person: John Smith (john.smith@example.com)",
                        FilesAnalyzed = true,
                        PackageVerificationCode = new SpdxPackageVerificationCode
                        {
                            Value = "d6a770ba38583ed4bb4525bd96e50461655d2758",
                            ExcludedFiles = new List<string> { "./package.spdx" },
                        },
                        ExternalReferences = new List<SpdxExternalReference>
                        {
                            new SpdxExternalReference
                            {
                                Category = "PACKAGE-MANAGER",
                                Type = "purl",
                                Locator = "pkg:qux/Foo@3.2.1",
                            },
                            new SpdxExternalReference
                            {
                                Category = "OTHER",
                                Type = "website",
                                Locator = "http://example.com/Foo",
                            },
                        },
                        Checksums = new List<SpdxChecksum>
                        {
                            new SpdxChecksum
                            {
                                Algorithm = "SHA1",
                                Value = "85ed0817af83a24ad8da68c2b5094de69833983c",
                            },
                            new SpdxChecksum
                            {
                                Algorithm = "SHA256",
                                Value = "11b6d3ee554eedf79299905a98f9b9a04e498210b59f15094c916c91d150efcd",
                            },
                        },
                    },
                },

            Files = new List<SpdxFile>
                {
                    new SpdxFile
                    {
                        SpdxId = "SPDXRef-BuildScript",
                        CopyrightText = "Copyright 2021-2022 Jabe Smith",
                        Filename = "build.cake",
                        FileTypes = new List<string> { "SOURCE" },
                        LicenseConcluded = "MIT",
                        LicenseInfoInFiles = new List<string> { "MIT", "Apache-2.0" },
                        Checksums = new List<SpdxChecksum>
                        {
                            new SpdxChecksum
                            {
                                Algorithm = "SHA1",
                                Value = "2fd4e1c67a2d28fced849ee1bb76e7391b93eb12",
                            },
                        },
                    },
                },

            Relationships = new List<SpdxRelationship>
                {
                    new SpdxRelationship
                    {
                        Identifier = "SPDXRef-DOCUMENT",
                        Type = "DESCRIBES",
                        RelatedIdentifier = "SPDXRef-Hades",
                    },
                    new SpdxRelationship
                    {
                        Identifier = "SPDXRef-Hades",
                        Type = "DEPENDS_ON",
                        RelatedIdentifier = "SPDXRef-Foo",
                    },
                    new SpdxRelationship
                    {
                        Identifier = "SPDXRef-BuildScript",
                        Type = "BUILD_TOOL_OF",
                        RelatedIdentifier = "SPDXRef-Hades",
                    },
                },
        };
    }
}
