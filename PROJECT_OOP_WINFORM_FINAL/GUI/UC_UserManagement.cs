using Project_OOP;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

public class UserManager
{
    private List<Person> _userList;
    private string _connectionString = "Server=LAPTOP-2C4LFE1O\\SQLEXPRESS;Database=Project_Desktop;Trusted_Connection=True;TrustServerCertificate=True;";

    public UserManager()
    {
        _userList = new List<Person>();
        LoadFromDatabase();
    }

    public List<Person> GetUsersForDisplay()
    {
        return this._userList;
    }

    private void LoadFromDatabase()
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users", conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader["Id"].ToString();
                        string fullName = reader["FullName"].ToString();
                        string email = reader["Email"].ToString();
                        string role = reader["Role"].ToString();
                        string password = reader["Password"].ToString();

                        if (role == "Admin")
                        {
                            _userList.Add(new Admin(id, fullName, email, password, role));
                        }
                        else if (role == "Reporter")
                        {
                            string dept = reader["Department"].ToString();
                            _userList.Add(new Reporter(id, fullName, email, dept, password));
                        }
                        else if (role == "Subscriber")
                        {
                            bool isPremium = reader["IsPremium"] != DBNull.Value && Convert.ToBoolean(reader["IsPremium"]);
                            _userList.Add(new Subscriber(id, fullName, email, isPremium, password));
                        }
                    }
                }
            }
        }
    }

    public bool AddUser(Person newUser)
    {
        for (int i = 0; i < this._userList.Count; i = i + 1)
        {
            if (this._userList[i].Id == newUser.Id) return false;
        }
        this._userList.Add(newUser);

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string query = "INSERT INTO Users (Id, FullName, Email, Role, Password, Department, IsPremium) VALUES (@Id, @FullName, @Email, @Role, @Password, @Department, @IsPremium)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", newUser.Id);
                cmd.Parameters.AddWithValue("@FullName", newUser.FullName);
                cmd.Parameters.AddWithValue("@Email", newUser.Email);

                string role = "Subscriber";
                string password = "";
                object dept = DBNull.Value;
                object isPremium = DBNull.Value;

                if (newUser is Admin admin)
                {
                    role = "Admin";
                    password = admin.Password;
                }
                else if (newUser is Reporter reporter)
                {
                    role = "Reporter";
                    password = reporter.Password;
                    dept = reporter.Department;
                }
                else if (newUser is Subscriber subscriber)
                {
                    role = "Subscriber";
                    password = subscriber.Password;
                    isPremium = subscriber.IsPremium;
                }

                cmd.Parameters.AddWithValue("@Role", role);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Department", dept);
                cmd.Parameters.AddWithValue("@IsPremium", isPremium);
                cmd.ExecuteNonQuery();
            }
        }
        return true;
    }

    public bool DeleteUser(string id)
    {
        for (int i = 0; i < this._userList.Count; i = i + 1)
        {
            if (this._userList[i].Id == id)
            {
                this._userList.RemoveAt(i);
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE Id = @Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
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
                using (SqlConnection conn = new SqlConnection(_connectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("UPDATE Users SET FullName = @FullName, Email = @Email WHERE Id = @Id", conn))
                    {
                        cmd.Parameters.AddWithValue("@FullName", newName);
                        cmd.Parameters.AddWithValue("@Email", newEmail);
                        cmd.Parameters.AddWithValue("@Id", id);
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
        }
        return false;
    }

    public Person FindUser(string email)
    {
        for (int i = 0; i < this._userList.Count; i = i + 1)
        {
            if (this._userList[i].Email == email) return this._userList[i];
        }
        return null;
    }
}