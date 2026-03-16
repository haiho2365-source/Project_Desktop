using Project_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    [Serializable]
    public class DailyNews : Publication
    {
        private int _trendLevel;

        public DailyNews() : base() { }

        public DailyNews(string id, string title, DateTime publishDate, int trendLevel)
            : base(id, title, publishDate)
        {
            this._trendLevel = trendLevel;
        }

        public int TrendLevel
        {
            get { return _trendLevel; }
            set { _trendLevel = value; }
        }

        public override void DisplayContent()
        {
            string summary = _title;
            if (_title.Length > 50)
            {
                summary = _title.Substring(0, 50);
            }

            Console.WriteLine("--- DAILY NEWS ---");
            Console.WriteLine("Tiêu đề: " + summary);
            Console.WriteLine("Trend: " + _trendLevel);
        }
    }
}
