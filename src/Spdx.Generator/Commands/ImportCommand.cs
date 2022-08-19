using Octokit;
using Spectre.Console;
using Spectre.IO;

namespace Spdx.Generator.Commands;

public sealed class ImportCommand : AsyncCommand<ImportCommand.Settings>
{
    public sealed class Settings : CommandSettings
    {
        [CommandOption("-o|--output <FILE>")]
        public string? Output { get; }

        public Settings(string? output)
        {
            Output = output;
        }
    }

    public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
    {
        return await AnsiConsole.Status()
            .StartAsync("Generating...", async ctx =>
            {
                ctx.Status("Fetching tags...");
                var tag = await GetLatestTag();
                if (tag == null)
                {
                    return 1;
                }

                ctx.Status("Generating licenses...");
                await GenerateLicenses(settings, tag.Commit.Sha);

                ctx.Status("Generating license exceptions...");
                await GenerateLicenseExceptions(settings, tag.Commit.Sha);

                return 0;
            });
    }

    private static async Task<RepositoryTag?> GetLatestTag()
    {
        var client = new GitHubClient(new ProductHeaderValue("SPDX"));
        var tags = await client.Repository.GetAllTags("spdx", "license-list-data");
        return tags.FirstOrDefault();
    }

    private static async Task GenerateLicenses(Settings settings, string tag)
    {
        var licensesUrl = $"https://raw.githubusercontent.com/spdx/license-list-data/{tag}/json/licenses.json";

        var json = await new HttpClient().GetStringAsync(licensesUrl).ConfigureAwait(false);
        var model = JsonSerializer.Deserialize<SpdxLicenseManifest>(json);

        var template = Template.Parse(File.ReadAllText("Templates/Licenses.template"));
        var result = template.Render(new { Version = model!.LicenseListVersion, Licenses = model!.Licenses.OrderBy(x => x.Id) });

        if (!string.IsNullOrWhiteSpace(settings.Output))
        {
            var output = new DirectoryPath(settings.Output);
            File.WriteAllText(output.CombineWithFilePath("SpdxLicense.Generated.cs").FullPath, result);
        }
    }

    private static async Task GenerateLicenseExceptions(Settings settings, string tag)
    {
        var exceptionsUrl = $"https://raw.githubusercontent.com/spdx/license-list-data/{tag}/json/exceptions.json";

        var json = await new HttpClient().GetStringAsync(exceptionsUrl).ConfigureAwait(false);
        var model = JsonSerializer.Deserialize<SpdxExceptionsManifest>(json);

        var template = Template.Parse(File.ReadAllText("Templates/Exceptions.template"));
        var result = template.Render(new { Exceptions = model!.Exceptions.OrderBy(x => x.Id) });

        if (!string.IsNullOrWhiteSpace(settings.Output))
        {
            var output = new DirectoryPath(settings.Output);
            File.WriteAllText(output.CombineWithFilePath("SpdxLicense.Exceptions.Generated.cs").FullPath, result);
        }
    }
}