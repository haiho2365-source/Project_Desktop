using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using global::Project_OOP;
using System;

namespace Project_OOP
{
    [Serializable]
    public class Admin : Person
    {
        private string _password;
        private string _role;

        public Admin() : base() { }

        // Sử dụng base để khởi tạo lớp cha
        public Admin(string id, string fullName, string email, string password, string role)
            : base(id, fullName, email)
        {
            this._password = password;
            this._role = role;
        }

        public bool CheckPassword(string inputPass)
        {
            return this._password == inputPass;
        }

        // Ghi đè phương thức (Đa hình)
        public override void ShowInfo()
        {
            Console.WriteLine("[QUẢN TRỊ VIÊN]");
            Console.WriteLine("ID: " + this._id);
            Console.WriteLine("Họ tên: " + this._fullName);
            Console.WriteLine("Email: " + this._email);
            Console.WriteLine("Vai trò: " + this._role);
            Console.WriteLine("-------------------------");
        }
    }
}
