namespace Spdx;

/// <summary>
/// Represents a SPDX license.
/// </summary>
public sealed partial class SpdxLicense
{
    private static readonly IReadOnlyList<SpdxLicense> _licenses;
    private static readonly Dictionary<string, SpdxLicense> _lookup;

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

    static SpdxLicense()
    {
        _licenses = GenerateLicenseList();
        _lookup = new Dictionary<string, SpdxLicense>(StringComparer.OrdinalIgnoreCase);
        foreach (var license in _licenses)
        {
            _lookup.Add(license.Id, license);
        }
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

    /// <summary>
    /// Gets the number of SPDX licenses.
    /// </summary>
    /// <returns>The number of SPDX licenses.</returns>
    public static int GetCount()
    {
        return _licenses.Count;
    }

    /// <summary>
    /// Gets all SPDX licenses.
    /// </summary>
    /// <returns>An enumerable of SPDX licenses.</returns>
    public static IReadOnlyList<SpdxLicense> GetAll()
    {
        return _licenses;
    }

    /// <summary>
    /// Gets a SPDX license by its SPDX license ID.
    /// </summary>
    /// <param name="id">The SPDX license ID.</param>
    /// <returns>The SPDX license, or <c>null</c> if not found.</returns>
    public static SpdxLicense? GetById(string id)
    {
        _lookup.TryGetValue(id, out var license);
        return license;
    }
}
