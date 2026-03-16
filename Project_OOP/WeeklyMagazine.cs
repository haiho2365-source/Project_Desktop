using Project_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    [Serializable]
    public class WeeklyMagazine : Publication
    {
        private string _author;
        private List<string> _references;

        public WeeklyMagazine() : base()
        {
            _references = new List<string>();
        }

        public WeeklyMagazine(string id, string title, DateTime publishDate, string author)
            : base(id, title, publishDate)
        {
            this._author = author;
            this._references = new List<string>();
        }

        public string Author
        {
            get { return _author; }
            set { _author = value; }
        }

        public void AddReference(string link)
        {
            _references.Add(link);
        }

        public override void DisplayContent()
        {
            Console.WriteLine("--- WEEKLY MAGAZINE ---");
            Console.WriteLine("Tiêu đề: " + _title);
            Console.WriteLine("Tác giả: " + _author);
            Console.WriteLine("Nguồn tham khảo:");

            for (int i = 0; i < _references.Count; i = i + 1)
            {
                Console.WriteLine(" + " + _references[i]);
            }
        }
    }
}
