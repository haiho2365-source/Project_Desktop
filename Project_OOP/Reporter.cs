using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

namespace Project_OOP
{
    [Serializable]
    public class Reporter : Person
    {
        private string _department;
        private int _postsCount;

        public Reporter() : base() { }

        public Reporter(string id, string fullName, string email, string department)
            : base(id, fullName, email)
        {
            this._department = department;
            this._postsCount = 0;
        }

        public void UpdatePostCount()
        {
            this._postsCount = this._postsCount + 1;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("[PHÓNG VIÊN]");
            Console.WriteLine("Tên: " + this._fullName + " | Phòng ban: " + this._department);
            Console.WriteLine("Số lượng bài viết đã thực hiện: " + this._postsCount);
            Console.WriteLine("-------------------------");
        }
    }
}
