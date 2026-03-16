using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    [Serializable]
    public abstract class Publication
    {
        protected string _id;
        protected string _title;
        protected DateTime _publishDate;
        protected int _viewCount = 0;

        public Publication() { }

        public Publication(string id, string title, DateTime publishDate)
        {
            this._id = id;
            this._title = title;
            this._publishDate = publishDate;
        }

        public string Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public DateTime PublishDate
        {
            get { return _publishDate; }
            set { _publishDate = value; }
        }

        public int ViewCount
        {
            get { return _viewCount; }
        }

        public void IncrementView()
        {
            _viewCount = _viewCount + 1;
        }

        public abstract void DisplayContent();
    }
}