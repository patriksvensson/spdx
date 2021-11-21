namespace Spdx.Expressions.Parsing;

internal sealed class TextBuffer
{
    private readonly ReadOnlyMemory<char> _buffer;
    private int _position;

    public bool CanRead => _position < _buffer.Length;
    public int Position => _position;
    public int Column { get; private set; }
    public int Line { get; private set; }

    public TextBuffer(string content)
    {
        _buffer = content.AsMemory();
        _position = 0;
    }

    public int Peek()
    {
        if (_position >= _buffer.Length)
        {
            return -1;
        }

        return _buffer.Span[_position];
    }

    public void Move(int position)
    {
        _position = position;
    }

    public int Read()
    {
        var result = Peek();
        if (result != -1)
        {
            _position++;
        }

        Column++;

        if ((char)result == '\n')
        {
            Line++;
            Column = 0;
        }

        return result;
    }

    public ReadOnlyMemory<char> Slice(int start, int stop)
    {
        return _buffer[start..stop];
    }

    public char PeekChar()
    {
        return (char)Peek();
    }

    public char ReadChar()
    {
        return (char)Read();
    }

    public void Discard()
    {
        Read();
    }

    public void Discard(char expected)
    {
        var read = ReadChar();
        if (read != expected)
        {
            throw new InvalidOperationException($"Expected '{expected}' but got '{read}'.");
        }
    }
}
