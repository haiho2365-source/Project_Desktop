using System;
using System.Threading.Tasks;


namespace Project_OOP
{
    [Serializable] 
    public abstract class Person
    {
        protected string _id;
        protected string _fullName;
        protected string _email;

        public Person()
        {
        }

        public Person(string id, string fullName, string email)
        {
            this._id = id;
            this._fullName = fullName;
            this._email = email;
        }

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

        public abstract void ShowInfo();
    }
}
