using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project_OOP
{
    [Serializable] 
    public abstract class Person
    {
        // Fields mang tính nội bộ, camelCase có gạch dưới
        protected string _id;
        protected string _fullName;
        protected string _email;

        // Constructor không tham số mặc định
        public Person()
        {
        }

        // Khai báo tường minh, constructor đầy đủ tham số
        public Person(string id, string fullName, string email)
        {
            this._id = id;
            this._fullName = fullName;
            this._email = email;
        }

        // Thuộc tính (Properties) PascalCase để truy cập từ bên ngoài
        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string FullName
        {
            get { return this._fullName; }
            set { this._fullName = value; }
        }

        public string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }

        // Phương thức trừu tượng (Contract)
        public abstract void ShowInfo();
    }
}
