namespace Spdx;

public sealed class SpdxChecksum
{
    public SpdxChecksumAlgorithm Algorithm { get; }
    public byte[] Value { get; }

    public SpdxChecksum(SpdxChecksumAlgorithm algorithm, byte[] value)
    {
        Algorithm = algorithm;
        Value = value ?? throw new ArgumentNullException(nameof(value));
    }
}
