using System.Collections;

namespace Shared
{
    public class Input : IEnumerable<Line>
    {
        private readonly List<string> _lines;
        private int _lineIndex = 0;
        public int NumberOfLines => _lines.Count;

        public IList<Line> Lines;
        public Line this[int index] => Lines[index];

        public Input(string input) : this(input.Split(Environment.NewLine))
        { }

        public Input(string[] lines)
        {
            _lines = new List<string>(lines);
            Lines = lines.Select(l => new Line(l)).ToList();
        }

        public string ReadLine()
        {
            if (_lineIndex > NumberOfLines - 1)
                throw new Exception("No more lines!");
            return _lines[_lineIndex++];
        }

        public T ReadLine<T>()
        {
            if (_lineIndex > NumberOfLines - 1)
                throw new Exception("No more lines!");
            return (T)Convert.ChangeType(_lines[_lineIndex++], typeof(T));
        }

        public bool IsBlank()
        {
            return string.IsNullOrEmpty(_lines[_lineIndex]);
        }

        //public T ReadToken<T>()
        //{
        //    if (_lineIndex > NumberOfLines - 1)
        //        throw new Exception("No more lines!");
        //    var tokens = _lines[_lineIndex].Split(' ');
        //    if(_tokenIndex > tokens.Length - 1)

        //}

        public string[] ReadLines()
        {
            return _lines.ToArray();
        }

        public IEnumerator<Line> GetEnumerator()
        {
            return Lines.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

}