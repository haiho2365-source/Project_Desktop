using Project_OOP;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public class UserManager
{
    private List<Person> _userList;
    private string _connectionString = "Server=LAPTOP-2C4LFE1O\\SQLEXPRESS;Database=Project_Desktop;Trusted_Connection=True;TrustServerCertificate=True;";

    public UserManager()
    {
        _userList = new List<Person>();
        LoadFromDatabase();
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
        if (newUser == null) return false;

        bool exists = _userList.Any(u => u.Id.Equals(newUser.Id.Trim(), StringComparison.OrdinalIgnoreCase));
        if (exists) return false;

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

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    this._userList.Add(newUser);
                    return true;
                }
            }
        }
        return false;
    }

    public bool DeleteUser(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return false;

        Person target = _userList.FirstOrDefault(u => u.Id.Equals(id.Trim(), StringComparison.OrdinalIgnoreCase));
        if (target == null) return false;

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id.Trim());
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    this._userList.Remove(target);
                    return true;
                }
            }
        }
        return false;
    }

    public bool UpdateUser(string id, string newName, string newEmail)
    {
        if (string.IsNullOrWhiteSpace(id)) return false;

        Person target = _userList.FirstOrDefault(u => u.Id.Equals(id.Trim(), StringComparison.OrdinalIgnoreCase));
        if (target == null) return false;

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE Users SET FullName = @FullName, Email = @Email WHERE Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@FullName", newName ?? "");
                cmd.Parameters.AddWithValue("@Email", newEmail ?? "");
                cmd.Parameters.AddWithValue("@Id", id.Trim());

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    target.FullName = newName;
                    target.Email = newEmail;
                    return true;
                }
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