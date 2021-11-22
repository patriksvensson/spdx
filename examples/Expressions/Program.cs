using Expressions;
using Spdx.Expressions;
using Spectre.Console;

// Parse the expression
var expression = SpdxExpression.Parse(
    "(MIT OR (LGPL-3.0+ WITH Libtool-exception) " +
    "WITH CLISP-exception-2.0) OR Apache-2.0");

// Print the expression to the console
AnsiConsole.WriteLine();
AnsiConsole.MarkupLine("[yellow]Expression:[/] ");
AnsiConsole.Write("   ");
ExpressionPrinter.Print(AnsiConsole.Console, expression);

// Collect all licenses from the expression in a table
var table = new Table();
table.AddColumn("[grey]License ID[/]");
table.AddColumn("[grey]Exceptions[/]");
foreach (var item in LicenseCollector.Collect(expression))
{
    table.AddRow(
        $"[green]{item.Id.EscapeMarkup()}[/]",
        item.Exceptions.Count > 0
            ? string.Join("[grey],[/] ", item.Exceptions.Select(x => $"[blue]{x.EscapeMarkup()}[/]"))
            : "[grey]N/A[/]");
}

// Render the table
AnsiConsole.WriteLine();
AnsiConsole.Write(table);