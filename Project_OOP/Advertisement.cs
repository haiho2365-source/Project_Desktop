using System;

namespace Project_OOP
{
    public class Advertisement
    {
        private string _sponsorName;
        private string _content;

        public string SponsorName
        {
            get { return _sponsorName; }
            set { _sponsorName = value; }
        }

        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public Advertisement()
        {
        }

        public Advertisement(string sponsorName, string content)
        {
            _sponsorName = sponsorName;
            _content = content;
        }

        public string ShowAd()
        {
            string result = "=== Advertisement ===\n";
            result = result + "Sponsor: " + _sponsorName + "\n";
            result = result + "Content: " + _content + "\n";
            result = result + "=====================";
            return result;
        }
    }
}