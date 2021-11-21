namespace Spdx;

/// <summary>
/// Represents a SPDX license exception.
/// </summary>
public sealed partial class SpdxLicenseException
{
    /// <summary>
    /// Gets the SPDX license exception ID.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the license exception name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the SPDX license exception URL.
    /// </summary>
    public string Url { get; }

    /// <summary>
    /// Gets the SPDX JSON license exception URL.
    /// </summary>
    public string JsonUrl { get; }

    /// <summary>
    /// Gets a value indicating whether or not the license has been deprecated or not.
    /// </summary>
    public bool IsDeprecated { get; }

    /// <summary>
    /// Gets all SPDX license exceptions.
    /// </summary>
    public static IReadOnlyList<SpdxLicenseException> All { get; }

    /// <summary>
    /// Gets a dictionary that can be used for lookup of license exceptions.
    /// </summary>
    public static IReadOnlyDictionary<string, SpdxLicenseException> Lookup { get; }

    static SpdxLicenseException()
    {
        All = GenerateExceptionList();
        Lookup = All.ToDictionary(x => x.Id, x => x, StringComparer.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxLicenseException"/> class.
    /// </summary>
    /// <param name="id">The SPDX license ID.</param>
    /// <param name="name">The license name.</param>
    /// <param name="url">The SPDX license URL.</param>
    /// <param name="jsonUrl">The SPDX JSON license URL.</param>
    /// <param name="deprecated">Whether or not the license has been deprecated or not.</param>
    public SpdxLicenseException(string id, string name, string url, string jsonUrl, bool deprecated)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        Name = name;
        Url = url;
        JsonUrl = jsonUrl;
        IsDeprecated = deprecated;
    }
}
