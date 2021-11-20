using System.Diagnostics.CodeAnalysis;
using Spectre.Console;

namespace Spdx.Generator.Commands;

public sealed class ImportCommand : AsyncCommand<ImportCommand.Settings>
{
    private const string? Url = "https://raw.githubusercontent.com/spdx/license-list-data/master/json/licenses.json";

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
                var json = await new HttpClient().GetStringAsync(Url).ConfigureAwait(false);
                var model = JsonSerializer.Deserialize<SpdxLicenseManifest>(json);

                var template = Template.Parse(File.ReadAllText("Templates/Licenses.template"));
                var result = template.Render(new { model!.Licenses });

                if (!string.IsNullOrWhiteSpace(settings.Output))
                {
                    File.WriteAllText(settings.Output, result);
                }

                return 0;
            });
    }
}