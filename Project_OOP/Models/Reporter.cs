using System;

namespace Project_OOP
{
    [Serializable]
    public class Reporter : Person
    {
        private string _department;
        private int _postsCount;
        private string _password; 
        
        public Reporter() : base()
        {
        }

        public Reporter(string id, string fullName, string email, string department, string password)
            : base(id, fullName, email)
        {
            this._department = department;
            this._postsCount = 0;
            this._password = password;
        }

        public string Department
        {
            get { return this._department; }
            set { this._department = value; }
        }

        public int PostsCount
        {
            get { return this._postsCount; }
            set { this._postsCount = value; }
        }

        public string Password
        {
            get { return this._password; }
            set { this._password = value; }
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

        public void UpdatePostCount()
        {
            this._postsCount = this._postsCount + 1;
        }

        public override void ShowInfo()
        {
            Console.WriteLine("[PHÓNG VIÊN]");

            string info = "Tên: " + this.FullName + " | Phòng ban: " + this.Department;
            
            Console.WriteLine(info);
            Console.WriteLine("Số lượng bài viết đã thực hiện: " + this.PostsCount.ToString());
            Console.WriteLine("-------------------------");
        }
    }
}
