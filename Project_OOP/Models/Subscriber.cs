using System;
using System.Collections.Generic;

namespace Project_OOP
{
    [Serializable]
    public class Subscriber : Person
    {
        private bool _isPremium;
        private List<string> _interestedTopics;
        public Subscriber() : base()
        {
            this._interestedTopics = new List<string>();
        }
        public Subscriber(string id, string fullName, string email, bool isPremium)
            : base(id, fullName, email)
        {
            this._isPremium = isPremium;
            this._interestedTopics = new List<string>();
        }
        public bool IsPremium
        {
            get { return this._isPremium; }
            set { this._isPremium = value; }
        }

        public List<string> InterestedTopics
        {
            get { return this._interestedTopics; }
            set { this._interestedTopics = value; }
        }
        public void AddTopic(string topic)
        {
            this._interestedTopics.Add(topic);
        }
        public override void ShowInfo()
        {
            string status = "";
            if (this.IsPremium == true)
            {
                status = "Tài khoản VIP";
            }
            else
            {
                status = "Tài khoản Thường";
            }

            Console.WriteLine("[THUÊ BAO] " + status);
            Console.WriteLine("Tên: " + this.FullName);
            Console.WriteLine("Chủ đề quan tâm: ");
            for (int i = 0; i < this._interestedTopics.Count; i = i + 1)
            {
                string topic = this._interestedTopics[i];
                Console.Write("- " + topic + " ");
            }
            Console.WriteLine("\n-------------------------");
        }
    }
}
