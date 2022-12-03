using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class Line
    {
        private string _line;

        private int _lineIndex = 0;

        public Line(string line)
        {
            _line = line;
        }

        public string Read()
        {
            return _line;
        }

        public string ReadToken()
        {
            if (_lineIndex >= _line.Length)
                throw new Exception("No more tokens.");
            var end = _line.IndexOf(' ', _lineIndex);
            if (end == -1)
                end = _line.Length;
            var token = _line.Substring(_lineIndex, end - _lineIndex);
            _lineIndex = end + 1;
            return token;
        }

        public char ReadChar()
        {
            if (_lineIndex >= _line.Length)
                throw new Exception("No more characters.");
            return _line[_lineIndex++];
        }

        public T Read<T>() => (T)Convert.ChangeType(Read(), typeof(T));
        public T ReadToken<T>() => (T)Convert.ChangeType(ReadToken(), typeof(T));
        public T ReadChar<T>() => (T)Convert.ChangeType(ReadChar(), typeof(T));

        public bool IsBlank() => string.IsNullOrEmpty(_line);
        public bool HasNextToken() => _line.IndexOf(' ', _lineIndex) >= 0;
        public bool HasNextChar() => _lineIndex < _line.Length;

        public override string ToString()
        {
            return _line;
        }

        public string Substring(int startIndex) => _line.Substring(startIndex);
        public string Substring(int startIndex, int length) => _line.Substring(startIndex, length);
        public bool Contains(char c) => _line.Contains(c);
        public bool Contains(string s) => _line.Contains(s);

        public int Length => _line.Length;

        public static implicit operator int(Line l) => int.Parse(l._line);
        public static implicit operator double(Line l) => double.Parse(l._line);
        public static explicit operator string(Line l) => l._line;
    }
}
