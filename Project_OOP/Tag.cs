using System;

namespace Project_OOP
{
    public class Tag
    {
        private string _tagName;
        private int _clickCount;

        public string TagName
        {
            get { return _tagName; }
            set { _tagName = value; }
        }

        public int ClickCount
        {
            get { return _clickCount; }
            set { _clickCount = value; }
        }

        public Tag()
        {
            _clickCount = 0;
        }

        public Tag(string tagName)
        {
            _tagName = tagName;
            _clickCount = 0;
        }

        public void Click()
        {
            _clickCount = _clickCount + 1;
        }
    }
}