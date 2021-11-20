using System;
using System.Linq;
using Spdx;
using Spectre.Console;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var licenses = SpdxLicense.GetAll();

            var osiApproved = licenses.Where(x => x.IsOsiApproved);
            var fsfLibre = licenses.Where(x => x.IsFsfLibre);
            var deprecated = licenses.Where(x => x.IsDeprecated);

            AnsiConsole.WriteLine();
            AnsiConsole.Write(new Table()
                .HideHeaders()
                .NoBorder()
                .AddColumn(new TableColumn("Key").RightAligned())
                .AddColumn("Value")
                .AddRow("[yellow]Number of licenses:[/]", licenses.Count.ToString())
                .AddRow("[yellow]OSI approved:[/]", osiApproved.Count().ToString())
                .AddRow("[yellow]FSF Libre:[/]", fsfLibre.Count().ToString())
                .AddRow("[yellow]Deprecated:[/]", deprecated.Count().ToString()));

            // Get a random license
            var license = licenses[Random.Shared.Next(licenses.Count - 1)];

            AnsiConsole.WriteLine();
            AnsiConsole.Write(new Table()
                .HideHeaders()
                .Title("[green]Random License[/]")
                .AddColumns("Key", "Value")
                .AddRow("[yellow]ID[/]", license.Id)
                .AddRow("[yellow]Name[/]", license.Name)
                .AddRow("[yellow]URL[/]", license.Url)
                .AddRow("[yellow]JSON URL[/]", license.JsonUrl)
                .AddRow("[yellow]OSI approved[/]", license.IsOsiApproved ? "Yes" : "No")
                .AddRow("[yellow]FSF Libre[/]", license.IsFsfLibre ? "Yes" : "No")
                .AddRow("[yellow]Deprecated[/]", license.IsDeprecated ? "Yes" : "No"));
        }
    }
}
