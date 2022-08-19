namespace Spdx.Expressions;

/// <summary>
/// Represent options provided to the SPDX expression parser.
/// </summary>
[Flags]
public enum SpdxLicenseOptions
{
    /// <summary>
    /// Strict parsing (default).
    /// </summary>
    Strict = 0x00,

    /// <summary>
    /// Allow unknown licenses.
    /// </summary>
    AllowUnknownLicenses = 0x01,

    /// <summary>
    /// Allow unknown exceptions.
    /// </summary>
    AllowUnknownExceptions = 0x02,

    /// <summary>
    /// Relaxed parsing.
    /// </summary>
    Relaxed = AllowUnknownLicenses | AllowUnknownExceptions,
}
