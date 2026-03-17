using System;

namespace Project_OOP
{
    [Serializable]
    public class Reporter : Person
    {
        private string _department;
        private int _postsCount;
        public string Department { get; set; }
        public int PostsCount { get; set; }
        public Reporter() : base() { }
        public Reporter(string id, string fullName, string email, string department)
            : base(id, fullName, email)
        {
            this.Department = department; 
            this.PostsCount = 0;          
        }
        public void UpdatePostCount()
        {
            this.PostsCount = this.PostsCount + 1;
        }
        public override void ShowInfo()
        {
            Console.WriteLine("[PHÓNG VIÊN]");
            Console.WriteLine("Tên: " + this.FullName + " | Phòng ban: " + this.Department);
            Console.WriteLine("Số lượng bài viết đã thực hiện: " + this.PostsCount);
            Console.WriteLine("-------------------------");
        }
    }
}
