namespace Spdx.Document;

internal static class SpdxSerializer
{
    public static bool Serialize(
        SpdxDocument document,
        SpdxDocumentFormat format,
        out SpdxValidationReport report,
        [NotNullWhen(true)] out string? output,
        out Exception? exception)
    {
        if (document is null)
        {
            throw new ArgumentNullException(nameof(document));
        }

        exception = null;

        report = document.Validate();
        if (report.Successful)
        {
            try
            {
                output = format switch
                {
                    SpdxDocumentFormat.Json => SpdxJsonSerializer.Serialize(document),
                    _ => throw new NotSupportedException("Unknown document format"),
                };

                return true;
            }
            catch (Exception ex)
            {
                exception = ex;
                report = new SpdxValidationReport(new[]
                {
                    new SpdxValidationError("An error occured during serialization")
                        .WithInfo("Hint", "See inner exception for more information"),
                });
            }
        }

        output = null;
        return false;
    }
}
