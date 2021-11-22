using System;
using System.Linq;
using Spdx;
using Spectre.Console;

namespace Example
{
    public static class Program
    {
        public static void Main()
        {
            var osiApproved = SpdxLicense.All.Where(x => x.IsOsiApproved);
            var fsfLibre = SpdxLicense.All.Where(x => x.IsFsfLibre);
            var deprecated = SpdxLicense.All.Where(x => x.IsDeprecated);

            AnsiConsole.WriteLine();
            AnsiConsole.Write(new Table()
                .HideHeaders()
                .NoBorder()
                .AddColumn(new TableColumn("Key").RightAligned())
                .AddColumn("Value")
                .AddRow("[yellow]Number of licenses:[/]", SpdxLicense.All.Count.ToString())
                .AddRow("[yellow]Exceptions:[/]", SpdxLicense.Exceptions.All.Count.ToString())
                .AddRow("[yellow]OSI approved:[/]", osiApproved.Count().ToString())
                .AddRow("[yellow]FSF Libre:[/]", fsfLibre.Count().ToString())
                .AddRow("[yellow]Deprecated:[/]", deprecated.Count().ToString()));

            // Get a random license
            var license = SpdxLicense.All[Random.Shared.Next(SpdxLicense.All.Count)];

            AnsiConsole.WriteLine();
            AnsiConsole.Write(new Table()
                .HideHeaders()
                .Title("[green]Random License[/]")
                .AddColumns("Key", "Value")
                .AddRow("[yellow]ID[/]", license.Id)
                .AddRow("[yellow]Name[/]", license.Name)
                .AddRow("[yellow]OSI approved[/]", license.IsOsiApproved ? "Yes" : "No")
                .AddRow("[yellow]FSF Libre[/]", license.IsFsfLibre ? "Yes" : "No")
                .AddRow("[yellow]Deprecated[/]", license.IsDeprecated ? "Yes" : "No"));
        }
    }
}
