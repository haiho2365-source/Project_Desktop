using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace Project_OOP
{
    [Serializable]
    public class Subscriber : Person
    {
        private bool _isPremium;
        private List<string> _interestedTopics; // Explicit typing

        public Subscriber() : base() { }

        public Subscriber(string id, string fullName, string email, bool isPremium)
            : base(id, fullName, email)
        {
            this._isPremium = isPremium;
            this._interestedTopics = new List<string>();
        }

        public void AddTopic(string topic)
        {
            // Không dùng LINQ, thao tác danh sách cơ bản
            this._interestedTopics.Add(topic);
        }

        public override void ShowInfo()
        {
            string status = this._isPremium ? "Tài khoản VIP" : "Tài khoản Thường";
            Console.WriteLine("[THUÊ BAO] " + status);
            Console.WriteLine("Tên: " + this._fullName);
            Console.WriteLine("Chủ đề quan tâm: ");

            // Dùng vòng lặp foreach cơ bản
            foreach (string topic in _interestedTopics)
            {
                Console.Write("- " + topic + " ");
            }
            Console.WriteLine("\n-------------------------");
        }
    }
}
