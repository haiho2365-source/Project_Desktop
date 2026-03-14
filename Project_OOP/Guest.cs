using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Project_OOP
{
    [Serializable]
    public class Guest : Person
    {
        private string _sessionId;

        public Guest() : base() { }

        // Truyền cứng thông tin lên lớp cha qua base
        public Guest(string sessionId)
            : base("GUEST_ID", "Ẩn danh", "No Email")
        {
            this._sessionId = sessionId;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("[KHÁCH TRUY CẬP]");
            Console.WriteLine("Mã phiên làm việc (Session): " + this._sessionId);
            Console.WriteLine("-------------------------");
        }
    }
}
