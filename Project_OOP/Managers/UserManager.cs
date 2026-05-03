using Project_OOP;
using System.Collections.Generic;

public class UserManager
{
    private List<Person> _userList;

    public UserManager()
    {
        _userList = new List<Person>();
    }

    public void AddUser(Person user)
    {
        _userList.Add(user);
    }

    public Person FindUser(string email)
    {
        foreach (Person p in _userList)
        {
            if (p.Email == email)
            {
                return p;
            }
        }
        return null;
    }

    public bool Login(string email, string password)
    {
        Person user = FindUser(email);
        if (user != null)
        {
            if (user is Admin)
            {
                Admin adminUser = (Admin)user;
                return adminUser.CheckPassword(password);
            }
        }
        return false;
    }

    public List<Person> GetUserList()
    {
        return _userList;
    }

    public void SetUserList(List<Person> loadedList)
    {
        _userList = loadedList;
    }
}