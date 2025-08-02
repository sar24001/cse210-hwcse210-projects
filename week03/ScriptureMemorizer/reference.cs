using System;

namespace ScriptureMemorizer
{
    public class Reference
    {
        private readonly string _book;
        private readonly int _chapter;
        private readonly int _startVerse;
        private readonly int _endVerse;

        // Single-verse constructor
        public Reference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = verse;
            _endVerse = verse;
        }

        // Range-of-verses constructor
        public Reference(string book, int chapter, int startVerse, int endVerse)
        {
            _book = book;
            _chapter = chapter;
            _startVerse = startVerse;
            _endVerse = endVerse;
        }

        public string GetDisplayText()
        {
            if (_startVerse == _endVerse)
                return $"{_book} {_chapter}:{_startVerse}";
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
        }
    }
}
