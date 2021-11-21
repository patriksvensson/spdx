namespace Spdx;

/// <summary>
/// Represents a SPDX license.
/// </summary>
public sealed partial class SpdxLicense
{
    /// <summary>
    /// Gets the SPDX license ID.
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Gets the license name.
    /// </summary>
    public string Name { get; }

    /// <summary>
    /// Gets the SPDX license URL.
    /// </summary>
    public string Url { get; }

    /// <summary>
    /// Gets the SPDX JSON license URL.
    /// </summary>
    public string JsonUrl { get; }

    /// <summary>
    /// Gets a value indicating whether or not the license is FSF Libre.
    /// </summary>
    public bool IsFsfLibre { get; }

    /// <summary>
    /// Gets a value indicating whether or not the license is OSI approved or not.
    /// </summary>
    public bool IsOsiApproved { get; }

    /// <summary>
    /// Gets a value indicating whether or not the license has been deprecated or not.
    /// </summary>
    public bool IsDeprecated { get; }

    /// <summary>
    /// Gets all SPDX licenses.
    /// </summary>
    public static IReadOnlyList<SpdxLicense> All { get; }

    /// <summary>
    /// Gets a dictionary that can be used for lookup of licenses.
    /// </summary>
    public static IReadOnlyDictionary<string, SpdxLicense> Lookup { get; }

    static SpdxLicense()
    {
        All = GenerateLicenseList();
        Lookup = All.ToDictionary(x => x.Id, x => x, StringComparer.OrdinalIgnoreCase);
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxLicense"/> class.
    /// </summary>
    /// <param name="id">The SPDX license ID.</param>
    /// <param name="name">The license name.</param>
    /// <param name="url">The SPDX license URL.</param>
    /// <param name="jsonUrl">The SPDX JSON license URL.</param>
    /// <param name="isOsiApproved">Whether or not the license is OSI approved or not.</param>
    /// <param name="isFsfLibre">Whether or not the license is FSF Libre.</param>
    /// <param name="deprecated">Whether or not the license has been deprecated or not.</param>
    public SpdxLicense(string id, string name, string url, string jsonUrl, bool isOsiApproved, bool isFsfLibre, bool deprecated)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        Name = name;
        Url = url;
        JsonUrl = jsonUrl;
        IsFsfLibre = isFsfLibre;
        IsOsiApproved = isOsiApproved;
        IsDeprecated = deprecated;
    }
}
