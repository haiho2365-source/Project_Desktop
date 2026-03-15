using System;

namespace Project_OOP
{
    [Serializable]
    public class Comment
    {
        private string _content;
        private Person _author;
        private DateTime _timestamp;

        public string Content
        {
            get { return this._content; }
            set { this._content = value; }
        }

        public Person Author
        {
            get { return this._author; }
            set { this._author = value; }
        }

        public DateTime Timestamp
        {
            get { return this._timestamp; }
            set { this._timestamp = value; }
        }

        // Constructor không tham số (phục vụ serialize)
        public Comment()
        {
            this._timestamp = DateTime.Now;
        }

        // Constructor đầy đủ
        public Comment(string content, Person author)
        {
            this._content = content;
            this._author = author;
            this._timestamp = DateTime.Now;
        }
    }
}