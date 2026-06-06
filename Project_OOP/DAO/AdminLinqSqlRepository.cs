using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Project_OOP
{
    public class AdminLinqSqlRepository
    {
        private readonly string _connectionString = "Server=LAPTOP-2C4LFE1O\\SQLEXPRESS;Database=Project_Desktop;Trusted_Connection=True;TrustServerCertificate=True;";

        public bool TryResetPassword(string fullName, string email, string role, string newPassword)
        {
            List<DbUserRecord> users = LoadUsers();

            DbUserRecord? matchedUser = users.FirstOrDefault(user =>
                string.Equals(user.FullName.Trim(), fullName.Trim(), StringComparison.OrdinalIgnoreCase) &&
                string.Equals(user.Email.Trim(), email.Trim(), StringComparison.OrdinalIgnoreCase) &&
                string.Equals(user.Role.Trim(), role.Trim(), StringComparison.OrdinalIgnoreCase));

            if (matchedUser == null)
            {
                return false;
            }

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Users SET Password = @Password WHERE Id = @Id AND Email = @Email", conn))
                {
                    cmd.Parameters.AddWithValue("@Password", newPassword);
                    cmd.Parameters.AddWithValue("@Id", matchedUser.Id);
                    cmd.Parameters.AddWithValue("@Email", matchedUser.Email);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public List<MailboxMessageRecord> LoadMailboxMessages()
        {
            EnsureMailboxTable();
            List<MailboxMessageRecord> messages = new List<MailboxMessageRecord>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Id, SenderEmail, ReceiverEmail, Subject, Content, CreatedAt, IsRead FROM MailboxMessages ORDER BY CreatedAt DESC", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        messages.Add(new MailboxMessageRecord
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            SenderEmail = ReadString(reader, "SenderEmail"),
                            ReceiverEmail = ReadString(reader, "ReceiverEmail"),
                            Subject = ReadString(reader, "Subject"),
                            Content = ReadString(reader, "Content"),
                            CreatedAt = Convert.ToDateTime(reader["CreatedAt"]),
                            IsRead = Convert.ToBoolean(reader["IsRead"])
                        });
                    }
                }
            }

            return messages
                .OrderBy(message => message.IsRead)
                .ThenByDescending(message => message.CreatedAt)
                .ToList();
        }

        public bool AddMailboxMessage(string senderEmail, string receiverEmail, string subject, string content)
        {
            EnsureMailboxTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "INSERT INTO MailboxMessages (SenderEmail, ReceiverEmail, Subject, Content, CreatedAt, IsRead) VALUES (@SenderEmail, @ReceiverEmail, @Subject, @Content, @CreatedAt, 0)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SenderEmail", senderEmail);
                    cmd.Parameters.AddWithValue("@ReceiverEmail", receiverEmail);
                    cmd.Parameters.AddWithValue("@Subject", subject);
                    cmd.Parameters.AddWithValue("@Content", content);
                    cmd.Parameters.AddWithValue("@CreatedAt", DateTime.Now);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool MarkMessageAsRead(int id)
        {
            EnsureMailboxTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE MailboxMessages SET IsRead = 1 WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public bool DeleteMailboxMessage(int id)
        {
            EnsureMailboxTable();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM MailboxMessages WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }

        public AdminStatisticsReport LoadStatistics()
        {
            List<DbUserRecord> users = LoadUsers();
            List<PublicationRecord> publications = LoadPublications();
            List<MailboxMessageRecord> messages = LoadMailboxMessages();

            AdminStatisticsReport report = new AdminStatisticsReport();
            report.TotalUsers = users.Count;
            report.TotalPublications = publications.Count;
            report.ApprovedPublications = publications.Count(post => post.IsApproved);
            report.PendingPublications = publications.Count(post => !post.IsApproved);
            report.UnreadMessages = messages.Count(message => !message.IsRead);

            report.UsersByRole = users
                .GroupBy(user => user.Role)
                .Select(group => new StatisticRow
                {
                    Name = group.Key,
                    Count = group.Count()
                })
                .OrderByDescending(row => row.Count)
                .ToList();

            report.PublicationsByType = publications
                .GroupBy(post => post.Type)
                .Select(group => new StatisticRow
                {
                    Name = group.Key,
                    Count = group.Count()
                })
                .OrderByDescending(row => row.Count)
                .ToList();

            report.PublicationsByStatus = publications
                .GroupBy(post => post.IsApproved ? "Đã duyệt" : "Chờ duyệt")
                .Select(group => new StatisticRow
                {
                    Name = group.Key,
                    Count = group.Count()
                })
                .OrderByDescending(row => row.Count)
                .ToList();

            return report;
        }

        public void EnsureMailboxTable()
        {
            string query = @"
IF OBJECT_ID('dbo.MailboxMessages', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.MailboxMessages
    (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        SenderEmail NVARCHAR(255) NOT NULL,
        ReceiverEmail NVARCHAR(255) NOT NULL,
        Subject NVARCHAR(255) NOT NULL,
        Content NVARCHAR(MAX) NOT NULL,
        CreatedAt DATETIME NOT NULL,
        IsRead BIT NOT NULL
    )
END";

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private List<DbUserRecord> LoadUsers()
        {
            List<DbUserRecord> users = new List<DbUserRecord>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Id, FullName, Email, Role, Password FROM Users", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new DbUserRecord
                        {
                            Id = ReadString(reader, "Id"),
                            FullName = ReadString(reader, "FullName"),
                            Email = ReadString(reader, "Email"),
                            Role = ReadString(reader, "Role"),
                            Password = ReadString(reader, "Password")
                        });
                    }
                }
            }

            return users;
        }

        private List<PublicationRecord> LoadPublications()
        {
            List<PublicationRecord> publications = new List<PublicationRecord>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT Id, Title, PublishDate, IsApproved, Type FROM Publications", conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        publications.Add(new PublicationRecord
                        {
                            Id = ReadString(reader, "Id"),
                            Title = ReadString(reader, "Title"),
                            PublishDate = Convert.ToDateTime(reader["PublishDate"]),
                            IsApproved = Convert.ToBoolean(reader["IsApproved"]),
                            Type = ReadString(reader, "Type")
                        });
                    }
                }
            }

            return publications;
        }

        private static string ReadString(SqlDataReader reader, string columnName)
        {
            object value = reader[columnName];
            return value == DBNull.Value ? "" : value.ToString() ?? "";
        }
    }

    public class DbUserRecord
    {
        public string Id { get; set; } = "";
        public string FullName { get; set; } = "";
        public string Email { get; set; } = "";
        public string Role { get; set; } = "";
        public string Password { get; set; } = "";
    }

    public class PublicationRecord
    {
        public string Id { get; set; } = "";
        public string Title { get; set; } = "";
        public DateTime PublishDate { get; set; }
        public bool IsApproved { get; set; }
        public string Type { get; set; } = "";
    }

    public class MailboxMessageRecord
    {
        public int Id { get; set; }
        public string SenderEmail { get; set; } = "";
        public string ReceiverEmail { get; set; } = "";
        public string Subject { get; set; } = "";
        public string Content { get; set; } = "";
        public DateTime CreatedAt { get; set; }
        public bool IsRead { get; set; }
    }

    public class StatisticRow
    {
        public string Name { get; set; } = "";
        public int Count { get; set; }
    }

    public class AdminStatisticsReport
    {
        public int TotalUsers { get; set; }
        public int TotalPublications { get; set; }
        public int ApprovedPublications { get; set; }
        public int PendingPublications { get; set; }
        public int UnreadMessages { get; set; }
        public List<StatisticRow> UsersByRole { get; set; } = new List<StatisticRow>();
        public List<StatisticRow> PublicationsByType { get; set; } = new List<StatisticRow>();
        public List<StatisticRow> PublicationsByStatus { get; set; } = new List<StatisticRow>();
    }
}
