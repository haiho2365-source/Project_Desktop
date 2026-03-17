using System;

namespace Project_OOP
{
    [Serializable]
    public class Comment
    {
        public string Content { get; set; }
        public Person Author { get; set; }
        public DateTime Timestamp { get; set; }

        private string _content;
        private Person _author;
        private DateTime _timestamp;

        public Comment()
        {
            Timestamp = DateTime.Now;
        }

        public Comment(string content, Person author)
        {
            Content = content;
            Author = author;
            Timestamp = DateTime.Now;
        }
    }
}
