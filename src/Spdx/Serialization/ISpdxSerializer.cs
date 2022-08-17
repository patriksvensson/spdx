namespace Spdx.Serialization;

internal interface ISpdxSerializer
{
    string Serialize(SpdxDocument document);
}
