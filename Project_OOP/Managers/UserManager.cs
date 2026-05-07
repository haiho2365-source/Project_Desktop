using Project_OOP;
using System.Collections.Generic;

public class UserManager
{
    private List<Person> _userList;

    public UserManager()
    {
        _userList = new List<Person>();
    }

    public bool AddUser(Person newUser)
    {
        for (int i = 0; i < this._userList.Count; i = i + 1)
        {
            Person existingUser = this._userList[i];
            if (existingUser.Id == newUser.Id)
            {
                return false; 
            }
        }
        this._userList.Add(newUser);
        return true;
    }

    public bool DeleteUser(string id)
    {
        for (int i = 0; i < this._userList.Count; i = i + 1)
        {
            if (this._userList[i].Id == id)
            {
                this._userList.RemoveAt(i);
                return true;
            }
        }
        return false;
    }

    public bool UpdateUser(string id, string newName, string newEmail)
    {
        for (int i = 0; i < this._userList.Count; i = i + 1)
        {
            if (this._userList[i].Id == id)
            {
                this._userList[i].FullName = newName;
                this._userList[i].Email = newEmail;
                return true;
            }
        }
        return false;
    }

    public Person FindUser(string email)
    {
        for (int i = 0; i < this._userList.Count; i = i + 1)
        {
            Person p = this._userList[i];
            if (p.Email == email)
            {
                return p;
            }
        }
        return null;
    }

    public bool Login(string email, string password)
    {
        Person user = this.FindUser(email);
        if (user != null)
        {
            if (user is Admin admin)
            {
                return admin.CheckPassword(password);
            }
            else if (user is Reporter reporter)
            {
                return reporter.CheckPassword(password);
            }
            else if (user is Subscriber subscriber)
            {
                return subscriber.CheckPassword(password);
            }
        }
        return false;
    }

    public List<Person> GetUsersForDisplay()
    {
        List<Person> displayList = new List<Person>();

        for (int i = 0; i < this._userList.Count; i = i + 1)
        {
            Person p = this._userList[i];

            if (!(p is Admin))
            {
                displayList.Add(p);
            }
        }
        return displayList;
    }

    public void SetUserList(List<Person> loadedList)
    {
        this._userList = loadedList;
    }
}