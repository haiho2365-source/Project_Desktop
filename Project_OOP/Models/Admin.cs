using global::Project_OOP;
using System;

namespace Project_OOP
{
    [Serializable]
    public class Admin : Person
    {
        private string _password;
        private string _role;
        public Admin() : base() 
        { 
        }
        public Admin(string id, string fullName, string email, string password, string role)
            : base(id, fullName, email)
        {
            this._password = password;
            this._role = role;
        }
        public string Password
        {
            get { return this._password; }
            set { this._password = value; }
        }

        public string Role
        {
            get { return this._role; }
            set { this._role = value; }
        }
        public bool CheckPassword(string inputPass)
        {
            bool isCorrect = false;
            if (this._password == inputPass)
            {
                isCorrect = true;
            }
            return isCorrect;
        }
        public override void ShowInfo()
        {
            Console.WriteLine("[QUẢN TRỊ VIÊN]");
            Console.WriteLine("ID: " + this.Id); 
            Console.WriteLine("Họ tên: " + this.FullName);
            Console.WriteLine("Email: " + this.Email);
            Console.WriteLine("Vai trò: " + this.Role);
            Console.WriteLine("-------------------------");
        }
    }
}
