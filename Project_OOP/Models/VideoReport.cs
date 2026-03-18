using Project_OOP;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Project_OOP
{
    [Serializable]
    public class VideoReport : Publication
    {
        private double _duration;
        private string _resolution;

        public VideoReport() : base() { }

        public VideoReport(string id, string title, DateTime publishDate, double duration, string resolution)
            : base(id, title, publishDate)
        {
            this._duration = duration;
            this._resolution = resolution;
        }

        public double Duration
        {
            get { return this._duration; }
            set 
            {
                if (value > 0)
                {
                    this._duration = value;
                }
            }
        }

        public string Resolution
        {
            get { return this._resolution; }
            set 
            {
                if (!string.IsNullOrEmpty(value))
                {
                    this._resolution = value;
                }
            }
        }

        public override void DisplayContent()
        {
            Console.WriteLine("Đang phát video...");
            Console.WriteLine("Độ phân giải: " + Resolution);
            Console.WriteLine("Thời lượng: " + Duration + " phút");
        }
    }
}
