using Project_OOP;
using System;
using System.Collections.Generic;
using System.Linq;
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
            get { return _duration; }
            set { _duration = value; }
        }

        public string Resolution
        {
            get { return _resolution; }
            set { _resolution = value; }
        }

        public override void DisplayContent()
        {
            Console.WriteLine("Đang phát video...");
            Console.WriteLine("Độ phân giải: " + _resolution);
            Console.WriteLine("Thời lượng: " + _duration + " phút");
        }
    }
}
