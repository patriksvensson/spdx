namespace Spdx.Document;

/// <summary>
/// Represents a SPDX relationship.
/// </summary>
public sealed class SpdxRelationship
{
    /// <summary>
    /// Gets or sets the identifier of the SPDX element.
    /// </summary>
    public string Identifier { get; set; } = null!;

    /// <summary>
    /// Gets or sets the identifier of the related SPDX element.
    /// </summary>
    public string RelatedIdentifier { get; set; } = null!;

    /// <summary>
    /// <para>Gets or sets the relationship type.</para>
    /// <para>
    /// In cases where there are "known unknowns", the use of the keyword <c>NOASSERTION</c>
    /// can be used on the right hand side of a relationship to indicate that the author
    /// is not asserting whether there are other SPDX elements (package/file/snippet)
    /// that are connected by relationships or not. That is, there could be some, but
    /// the author is not asserting one way or another.
    /// </para>
    /// <list type="bullet">
    ///     <item><term>DESCRIBES</term> Is to be used when SPDXRef-DOCUMENT describes <c>SPDXRef-A</c>.</item>
    ///     <item><term>DESCRIBED_BY</term> Is to be used when <c>SPDXRef-A</c> is described by SPDXREF-Document.</item>
    ///     <item><term>CONTAINS</term> Is to be used when <c>SPDXRef-A</c> contains <c>SPDXRef-B</c>.</item>
    ///     <item><term>CONTAINED_BY</term> Is to be used when <c>SPDXRef-A</c> is contained by <c>SPDXRef-B</c>.</item>
    ///     <item><term>DEPENDS_ON</term> Is to be used when <c>SPDXRef-A</c> depends on <c>SPDXRef-B</c>.</item>
    ///     <item><term>DEPENDENCY_OF</term> Is to be used when <c>SPDXRef-A</c> is dependency of <c>SPDXRef-B</c>.</item>
    ///     <item><term>DEPENDENCY_MANIFEST_OF</term> Is to be used when <c>SPDXRef-A</c> is a manifest file that lists a set of dependencies for <c>SPDXRef-B</c>.</item>
    ///     <item><term>BUILD_DEPENDENCY_OF</term> Is to be used when <c>SPDXRef-A</c> is a build dependency of <c>SPDXRef-B</c>.</item>
    ///     <item><term>DEV_DEPENDENCY_OF</term> Is to be used when <c>SPDXRef-A</c> is a development dependency of <c>SPDXRef-B</c>.</item>
    ///     <item><term>OPTIONAL_DEPENDENCY_OF</term> Is to be used when <c>SPDXRef-A</c> is an optional dependency of <c>SPDXRef-B</c>.</item>
    ///     <item><term>PROVIDED_DEPENDENCY_OF</term> Is to be used when <c>SPDXRef-A</c> is a to be provided dependency of <c>SPDXRef-B</c>.</item>
    ///     <item><term>TEST_DEPENDENCY_OF</term> Is to be used when <c>SPDXRef-A</c> is a test dependency of <c>SPDXRef-B</c>.</item>
    ///     <item><term>RUNTIME_DEPENDENCY_OF</term> Is to be used when <c>SPDXRef-A</c> is a dependency required for the execution of <c>SPDXRef-B</c>.</item>
    ///     <item><term>EXAMPLE_OF</term> Is to be used when <c>SPDXRef-A</c> is an example of <c>SPDXRef-B</c>.</item>
    ///     <item><term>GENERATES</term> Is to be used when <c>SPDXRef-A</c> generates <c>SPDXRef-B</c>.</item>
    ///     <item><term>GENERATED_FROM</term> Is to be used when <c>SPDXRef-A</c> was generated from <c>SPDXRef-B</c>.</item>
    ///     <item><term>ANCESTOR_OF</term> Is to be used when <c>SPDXRef-A</c> is an ancestor (same lineage but pre-dates) <c>SPDXRef-B</c>.</item>
    ///     <item><term>DESCENDANT_OF</term> Is to be used when <c>SPDXRef-A</c> is a descendant of (same lineage but postdates) <c>SPDXRef-B</c>.</item>
    ///     <item><term>VARIANT_OF</term> Is to be used when <c>SPDXRef-A</c> is a variant of (same lineage but not clear which came first) <c>SPDXRef-B</c>.</item>
    ///     <item><term>DISTRIBUTION_ARTIFACT</term> Is to be used when distributing <c>SPDXRef-A</c> requires that <c>SPDXRef-B</c> also be distributed.</item>
    ///     <item><term>PATCH_FOR</term> Is to be used when <c>SPDXRef-A</c> is a patch file for (to be applied to) <c>SPDXRef-B</c>.</item>
    ///     <item><term>PATCH_APPLIED</term> Is to be used when <c>SPDXRef-A</c> is a patch file that has been applied to <c>SPDXRef-B</c>.</item>
    ///     <item><term>COPY_OF</term> Is to be used when <c>SPDXRef-A</c> is an exact copy of <c>SPDXRef-B</c>.</item>
    ///     <item><term>FILE_ADDED</term> Is to be used when <c>SPDXRef-A</c> is a file that was added to <c>SPDXRef-B</c>.</item>
    ///     <item><term>FILE_DELETED</term> Is to be used when <c>SPDXRef-A</c> is a file that was deleted from <c>SPDXRef-B</c>.</item>
    ///     <item><term>FILE_MODIFIED</term> Is to be used when <c>SPDXRef-A</c> is a file that was modified from <c>SPDXRef-B</c>.</item>
    ///     <item><term>EXPANDED_FROM_ARCHIVE</term> Is to be used when <c>SPDXRef-A</c> is expanded from the archive <c>SPDXRef-B</c>.</item>
    ///     <item><term>DYNAMIC_LINK</term> Is to be used when <c>SPDXRef-A</c> dynamically links to <c>SPDXRef-B</c>.</item>
    ///     <item><term>STATIC_LINK</term> Is to be used when <c>SPDXRef-A</c> statically links to <c>SPDXRef-B</c>.</item>
    ///     <item><term>DATA_FILE_OF</term> Is to be used when <c>SPDXRef-A</c> is a data file used in <c>SPDXRef-B</c>.</item>
    ///     <item><term>TEST_CASE_OF</term> Is to be used when <c>SPDXRef-A</c> is a test case used in testing <c>SPDXRef-B</c>.</item>
    ///     <item><term>BUILD_TOOL_OF</term> Is to be used when <c>SPDXRef-A</c> is used to build <c>SPDXRef-B</c>.</item>
    ///     <item><term>DEV_TOOL_OF</term> Is to be used when <c>SPDXRef-A</c> is used as a development tool for <c>SPDXRef-B</c>.</item>
    ///     <item><term>TEST_OF</term> Is to be used when <c>SPDXRef-A</c> is used for testing <c>SPDXRef-B</c>.</item>
    ///     <item><term>TEST_TOOL_OF</term> Is to be used when <c>SPDXRef-A</c> is used as a test tool for <c>SPDXRef-B</c>.</item>
    ///     <item><term>DOCUMENTATION_OF</term> Is to be used when <c>SPDXRef-A</c> provides documentation of <c>SPDXRef-B</c>.</item>
    ///     <item><term>OPTIONAL_COMPONENT_OF</term> Is to be used when <c>SPDXRef-A</c> is an optional component of <c>SPDXRef-B</c>.</item>
    ///     <item><term>METAFILE_OF</term> Is to be used when <c>SPDXRef-A</c> is a metafile of <c>SPDXRef-B</c>.</item>
    ///     <item><term>PACKAGE_OF</term> Is to be used when <c>SPDXRef-A</c> is used as a package as part of <c>SPDXRef-B</c>.</item>
    ///     <item><term>AMENDS</term> Is to be used when (current) SPDXRef-DOCUMENT amends the SPDX information in <c>SPDXRef-B</c>.</item>
    ///     <item><term>PREREQUISITE_FOR</term> Is to be used when <c>SPDXRef-A</c> is a prerequisite for <c>SPDXRef-B</c>.</item>
    ///     <item><term>HAS_PREREQUISITE</term> Is to be used when <c>SPDXRef-A</c> has as a prerequisite <c>SPDXRef-B</c>.</item>
    ///     <item><term>OTHER</term> Is to be used for a relationship which has not been defined in the formal SPDX specification. A description of the relationship should be included in the Relationship comments field.</item>
    /// </list>
    /// </summary>
    public string Type { get; set; } = null!;
}
