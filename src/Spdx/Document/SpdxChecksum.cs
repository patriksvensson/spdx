namespace Spdx.Document;

/// <summary>
/// Represents a SPDX checksum.
/// </summary>
public sealed class SpdxChecksum
{
    /// <summary>
    /// Gets a set of all accepted algorithms.
    /// </summary>
    public static IReadOnlySet<string> Algorithms { get; } = new HashSet<string>(StringComparer.Ordinal)
    {
        "SHA1", "SHA224", "SHA256",
        "SHA384", "SHA512", "MD2",
        "MD4", "MD5", "MD6",
    };

    /// <summary>
    /// <para>Gets or sets the algorithm identifier.</para>
    /// <para>Algorithms that can be used:</para>
    /// <list type="bullet">
    /// <item><c>SHA1</c></item>
    /// <item><c>SHA224</c></item>
    /// <item><c>SHA256</c></item>
    /// <item><c>SHA384</c></item>
    /// <item><c>SHA512</c></item>
    /// <item><c>MD2</c></item>
    /// <item><c>MD4</c></item>
    /// <item><c>MD5</c></item>
    /// <item><c>MD6</c></item>
    /// </list>
    /// </summary>
    public string Algorithm { get; set; } = null!;

    /// <summary>
    /// Gets or sets the checksum.
    /// </summary>
    public string Value { get; set; } = null!;
}
