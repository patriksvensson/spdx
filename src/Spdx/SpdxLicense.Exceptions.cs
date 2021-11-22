namespace Spdx;

/// <summary>
/// Represents a SPDX license.
/// </summary>
public sealed partial class SpdxLicense
{
    /// <summary>
    /// Represents SPDX license exceptions.
    /// </summary>
    public sealed partial class Exceptions
    {
        /// <summary>
        /// Gets all SPDX license exceptions.
        /// </summary>
        public static IReadOnlySet<string> All => _exceptions;

        /// <summary>
        /// Determines whether or not a SPDX license exception with the specified ID exist.
        /// </summary>
        /// <param name="id">The SPDX license exception ID.</param>
        /// <returns><c>true</c> it the license exception exists, otherwise <c>false</c>.</returns>
        public static bool Exists(string id)
        {
            return All.Contains(id);
        }
    }
}
