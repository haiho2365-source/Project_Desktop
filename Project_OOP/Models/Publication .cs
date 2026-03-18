using System;
using System.Collections.Generic;
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
            get { return this._id; }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                {
                   this._id = value;
                }
            }
        }

        public string Title
        {
            get { return this._title; }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._title = value;
                }
            }
        }

        public DateTime PublishDate
        {
            get { return this._publishDate; }
            set
            {
                if (value <= DateTime.Now)
                {
                    this._publishDate = value;
                }
            }
        }

        public int ViewCount
        {
            get { return this._viewCount; }
        }

        public void IncrementView()
        {
            this._viewCount++;
        }

        public abstract void DisplayContent();
    }
}
