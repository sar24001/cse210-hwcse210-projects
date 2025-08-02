namespace ScriptureMemorizer
{
    public class Word(string text)
    {
        private readonly string _text = text;
        private bool _isHidden = false;

        public void Hide()
        {
            _isHidden = true;
        }

        public void Show()
        {
            _isHidden = false;
        }

        public bool IsHidden()
        {
            return _isHidden;
        }

        public string GetDisplayText()
        {
            if (_isHidden)
                return new string('_', _text.Length);
            return _text;
        }
    }
}
