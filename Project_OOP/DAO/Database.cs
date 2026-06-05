using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Project_OOP
{
    [Serializable]
    public class Database
    {
        private List<Subscriber> _subscribers = new List<Subscriber>();
        private List<Admin> _admins = new List<Admin>();
        private DataStorageUtility _storage = new DataStorageUtility();
        private string _connectionString = "Server=LAPTOP-2C4LFE1O\\SQLEXPRESS;Database=Project_Desktop;Trusted_Connection=True;TrustServerCertificate=True;";

        public Database()
        {
            LoadFromDatabase();
        }

        public List<Subscriber> Subscribers
        {
            get { return this._subscribers; }
            set { this._subscribers = value; }
        }

        public List<Admin> Admins
        {
            get { return this._admins; }
            set { this._admins = value; }
        }

        public void AddSubscriber(Subscriber subscriber)
        {
            this._subscribers.Add(subscriber);
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Users (Id, FullName, Email, IsPremium, Password, Role) VALUES (@Id, @FullName, @Email, @IsPremium, @Password, 'Subscriber')";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", subscriber.Id);
                    cmd.Parameters.AddWithValue("@FullName", subscriber.FullName);
                    cmd.Parameters.AddWithValue("@Email", subscriber.Email);
                    cmd.Parameters.AddWithValue("@IsPremium", subscriber.IsPremium);
                    cmd.Parameters.AddWithValue("@Password", subscriber.Password);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void AddAdmin(Admin admin)
        {
            this._admins.Add(admin);
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "INSERT INTO Users (Id, FullName, Email, Password, Role) VALUES (@Id, @FullName, @Email, @Password, 'Admin')";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", admin.Id);
                    cmd.Parameters.AddWithValue("@FullName", admin.FullName);
                    cmd.Parameters.AddWithValue("@Email", admin.Email);
                    cmd.Parameters.AddWithValue("@Password", admin.Password);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public bool IsEmailExists(string email)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(1) FROM Users WHERE Email = @Email", conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    return (int)cmd.ExecuteScalar() > 0;
                }
            }
        }

        private void LoadFromDatabase()
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Role = 'Subscriber'", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bool isPremium = reader["IsPremium"] != DBNull.Value && Convert.ToBoolean(reader["IsPremium"]);
                            _subscribers.Add(new Subscriber(reader["Id"].ToString(), reader["FullName"].ToString(), reader["Email"].ToString(), isPremium, reader["Password"].ToString()));
                        }
                    }
                }
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Users WHERE Role = 'Admin'", conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _admins.Add(new Admin(reader["Id"].ToString(), reader["FullName"].ToString(), reader["Email"].ToString(), reader["Password"].ToString(), reader["Role"].ToString()));
                        }
                    }
                }
            }
        }
    }
}