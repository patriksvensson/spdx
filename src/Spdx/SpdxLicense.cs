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
    public static IReadOnlyList<SpdxLicense> All => _licenses;

    /// <summary>
    /// Initializes a new instance of the <see cref="SpdxLicense"/> class.
    /// </summary>
    /// <param name="id">The SPDX license ID.</param>
    /// <param name="name">The license name.</param>
    /// <param name="isOsiApproved">Whether or not the license is OSI approved or not.</param>
    /// <param name="isFsfLibre">Whether or not the license is FSF Libre.</param>
    /// <param name="deprecated">Whether or not the license has been deprecated or not.</param>
    public SpdxLicense(string id, string name, bool isOsiApproved, bool isFsfLibre, bool deprecated)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
        Name = name;
        IsFsfLibre = isFsfLibre;
        IsOsiApproved = isOsiApproved;
        IsDeprecated = deprecated;
    }

    /// <summary>
    /// Gets a specific SPDX license by it's ID.
    /// </summary>
    /// <param name="id">The SPDX license ID.</param>
    /// <returns>The specified license, or <c>null</c> if it doesn't exist.</returns>
    public static SpdxLicense? GetById(string id)
    {
        _lookup.TryGetValue(id, out var license);
        return license;
    }

    /// <summary>
    /// Gets a specific SPDX license by it's ID.
    /// </summary>
    /// <param name="id">The SPDX license ID.</param>
    /// <param name="license">
    /// When this method returns, contains the SPDX license associated with the specified ID,
    /// if the SPDX license is found; otherwise, <c>null</c>.
    /// </param>
    /// <returns><c>true</c> if the SPDX license was found; otherwise, <c>false</c>.</returns>
    public static bool TryGetById(string id, [NotNullWhen(true)] out SpdxLicense? license)
    {
        return _lookup.TryGetValue(id, out license);
    }

    /// <summary>
    /// Determines whether or not a SPDX license with the specified ID exist.
    /// </summary>
    /// <param name="id">The SPDX license ID.</param>
    /// <returns><c>true</c> it the license exists, otherwise <c>false</c>.</returns>
    public static bool Exists(string id)
    {
        return _lookup.ContainsKey(id);
    }
}
