using Newtonsoft.Json;

namespace Spdx.Document;

internal sealed class JsonWriterEx : IDisposable
{
    private readonly StringWriter _writer;
    private readonly JsonTextWriter _json;

    public JsonWriterEx()
    {
        _writer = new StringWriter(new StringBuilder());
        _json = new JsonTextWriter(_writer)
        {
            Formatting = Formatting.Indented,
        };
    }

    public IDisposable WriteObject()
    {
        _json.WriteStartObject();
        return new Scope(() => _json.WriteEndObject());
    }

    public IDisposable WriteObject(string name)
    {
        _json.WritePropertyName(name);
        _json.WriteStartObject();
        return new Scope(() => _json.WriteEndObject());
    }

    public IDisposable WriteArray(string name)
    {
        _json.WritePropertyName(name);
        _json.WriteStartArray();
        return new Scope(() => _json.WriteEndArray());
    }

    public void WriteArray<T>(string name, IEnumerable<T> values)
    {
        if (values != null)
        {
            _json.WritePropertyName(name);
            _json.WriteStartArray();

            foreach (var value in values)
            {
                _json.WriteValue(value);
            }

            _json.WriteEndArray();
        }
    }

    public void WriteProperty(string name, object? value)
    {
        if (value != null)
        {
            _json.WritePropertyName(name);
            _json.WriteValue(value);
        }
    }

    public void WriteValue(object? value)
    {
        _json.WriteValue(value);
    }

    private sealed class Scope : IDisposable
    {
        private readonly Action _action;
        private bool _disposed;

        public Scope(Action action)
        {
            _action = action;
        }

        ~Scope()
        {
            throw new InvalidOperationException("Scope not disposed");
        }

        public void Dispose()
        {
            if (!_disposed)
            {
                GC.SuppressFinalize(this);
                _action();
                _disposed = true;
            }
        }
    }

    public void Dispose()
    {
        _json.Close();
    }

    public override string ToString()
    {
        _json.Flush();
        return _writer.ToString();
    }
}