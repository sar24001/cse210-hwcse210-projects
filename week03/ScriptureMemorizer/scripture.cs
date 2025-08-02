using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private readonly Reference _reference;
        private readonly List<Word> _words;
        private static readonly Random _random = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = [.. text
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(w => new Word(w))];
        }

        // Hide up to 'count' random words that are not already hidden
        public void HideRandomWords(int count)
        {
            var visibleWords = _words.Where(w => !w.IsHidden()).ToList();
            if (visibleWords.Count == 0)
                return;

            if (count > visibleWords.Count)
                count = visibleWords.Count;

            for (int i = 0; i < count; i++)
            {
                var index = _random.Next(visibleWords.Count);
                visibleWords[index].Hide();
                visibleWords.RemoveAt(index);
            }
        }

        // Reveal one random hidden word
        public void RevealRandomWord()
        {
            var hiddenWords = _words.Where(w => w.IsHidden()).ToList();
            if (hiddenWords.Count == 0)
                return;

            var index = _random.Next(hiddenWords.Count);
            hiddenWords[index].Show();
        }

        public bool IsCompletelyHidden()
        {
            return _words.All(w => w.IsHidden());
        }

        // Build display: reference line + joined words
        public string GetDisplayText()
        {
            var referenceLine = _reference.GetDisplayText();
            var scriptureText = string.Join(' ', _words.Select(w => w.GetDisplayText()));
            return $"{referenceLine}\n{scriptureText}";
        }
    }
}
