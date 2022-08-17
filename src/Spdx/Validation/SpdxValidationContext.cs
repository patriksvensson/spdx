namespace Spdx.Validation;

internal sealed class SpdxValidationContext
{
    private readonly List<SpdxValidationError> _errors;
    private readonly Stack<string> _path;

    public string Path => string.Join("::", _path.Reverse().Select(x => x));

    public SpdxValidationContext()
    {
        _errors = new List<SpdxValidationError>();
        _path = new Stack<string>();
    }

    private sealed class Scope : IDisposable
    {
        private readonly Action _action;

        public Scope(Action action)
        {
            _action = action;
        }

        public void Dispose()
        {
            _action();
        }
    }

    public IDisposable PushPath(string name)
    {
        _path.Push(name ?? throw new ArgumentNullException(nameof(name)));
        return new Scope(() =>
        {
            if (_path.Count > 0)
            {
                _path.Pop();
            }
        });
    }

    public void AddError(SpdxValidationError error)
    {
        _errors.Add(error);
    }

    public SpdxValidationError AddError(string message)
    {
        var error = new SpdxValidationError(message).WithInfo("Path", Path);
        _errors.Add(error);
        return error;
    }

    public SpdxValidationReport CreateReport()
    {
        return new SpdxValidationReport(_errors);
    }
}
