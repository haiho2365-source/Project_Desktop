using global::Project_OOP;
using System;

namespace Project_OOP
{
    [Serializable]
    public class Admin : Person
    {
        private string _password;
        private string _role;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public string Role
        {
            get { return _role; }
            set { _role = value; }
        }
        public Admin() : base() 
        { 
        }
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
        public override void ShowInfo()
        {
            Console.WriteLine("[QUẢN TRỊ VIÊN]");
            Console.WriteLine("ID: " + this.Id); // Dùng Property Id từ lớp cha
            Console.WriteLine("Họ tên: " + this.FullName);
            Console.WriteLine("Email: " + this.Email);
            Console.WriteLine("Vai trò: " + this._role);
            Console.WriteLine("-------------------------");
        }
    }
}
