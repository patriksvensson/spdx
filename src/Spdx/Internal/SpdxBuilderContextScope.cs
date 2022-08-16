﻿namespace Spdx.Internal;

internal sealed class SpdxBuilderContextScope : IDisposable
{
    private readonly SpdxBuilderContext _context;

    public string? Name { get; }
    public bool HasErrors { get; private set; }

    public SpdxBuilderContextScope(SpdxBuilderContext context, string? name)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        Name = name;
    }

    public void AddDiagnostic(SpdxDiagnostic diagnostic)
    {
        if (!HasErrors)
        {
            HasErrors = diagnostic.Kind == SpdxDiagnosticKind.Error;
        }

        _context.AddDiagnostic(diagnostic);
    }

    public void Dispose()
    {
    }
}
