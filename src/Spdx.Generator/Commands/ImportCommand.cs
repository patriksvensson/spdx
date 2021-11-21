using System.Diagnostics.CodeAnalysis;
using Spectre.Console;
using Spectre.IO;

namespace Spdx.Generator.Commands;

public sealed class ImportCommand : AsyncCommand<ImportCommand.Settings>
{
    private const string? LicensesUrl = "https://raw.githubusercontent.com/spdx/license-list-data/master/json/licenses.json";
    private const string? ExceptionsUrl = "https://raw.githubusercontent.com/spdx/license-list-data/master/json/exceptions.json";

    public sealed class Settings : CommandSettings
    {
        [CommandOption("-o|--output <FILE>")]
        public string? Output { get; }

        public Settings(string? output)
        {
            Output = output;
        }
    }

    [SuppressMessage("Design", "RCS1090:Add call to 'ConfigureAwait' (or vice versa).")]
    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        return await AnsiConsole.Status()
            .StartAsync("Generating...", async _ =>
            {
                await GenerateLicenses(settings).ConfigureAwait(false);
                await GenerateLicenseExceptions(settings).ConfigureAwait(false);

                return 0;
            });
    }

    private static async Task GenerateLicenses(Settings settings)
    {
        var json = await new HttpClient().GetStringAsync(LicensesUrl).ConfigureAwait(false);
        var model = JsonSerializer.Deserialize<SpdxLicenseManifest>(json);

        var template = Template.Parse(File.ReadAllText("Templates/Licenses.template"));
        var result = template.Render(new { model!.Licenses });

        if (!string.IsNullOrWhiteSpace(settings.Output))
        {
            var output = new DirectoryPath(settings.Output);
            File.WriteAllText(output.CombineWithFilePath("SpdxLicense.Generated.cs").FullPath, result);
        }
    }

    private static async Task GenerateLicenseExceptions(Settings settings)
    {
        var json = await new HttpClient().GetStringAsync(ExceptionsUrl).ConfigureAwait(false);
        var model = JsonSerializer.Deserialize<SpdxExceptionsManifest>(json);

        var template = Template.Parse(File.ReadAllText("Templates/Exceptions.template"));
        var result = template.Render(new { model!.Exceptions });

        if (!string.IsNullOrWhiteSpace(settings.Output))
        {
            var output = new DirectoryPath(settings.Output);
            File.WriteAllText(output.CombineWithFilePath("SpdxLicenseException.Generated.cs").FullPath, result);
        }
    }
}