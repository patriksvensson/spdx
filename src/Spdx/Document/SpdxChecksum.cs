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
        "SHA3-256", "SHA3-384", "SHA3-512",
        "BLAKE2b-256", "BLAKE2b-384", "BLAKE2b-512",
        "BLAKE3", "ADLER32",
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
    /// <item><c>SHA3-256</c></item>
    /// <item><c>SHA3-384</c></item>
    /// <item><c>SHA3-512</c></item>
    /// <item><c>BLAKE2b-256</c></item>
    /// <item><c>BLAKE2b-384</c></item>
    /// <item><c>BLAKE2b-512</c></item>
    /// <item><c>BLAKE3</c></item>
    /// <item><c>ADLER32</c></item>
    /// </list>
    /// </summary>
    public string Algorithm { get; set; } = null!;

    /// <summary>
    /// Gets or sets the checksum.
    /// </summary>
    public string Value { get; set; } = null!;
}
