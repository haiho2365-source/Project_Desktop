using Project_OOP;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

public class PublicationManager
{
    private List<Publication> _postList;
    private string _connectionString = "Server=LAPTOP-2C4LFE1O\\SQLEXPRESS;Database=Project_Desktop;Trusted_Connection=True;TrustServerCertificate=True;";

    public PublicationManager()
    {
        this._postList = new List<Publication>();
        LoadFromDatabase();
    }

    private void LoadFromDatabase()
    {
        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Publications", conn))
            {
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader["Id"].ToString();
                        string title = reader["Title"].ToString();
                        DateTime publishDate = Convert.ToDateTime(reader["PublishDate"]);
                        bool isApproved = Convert.ToBoolean(reader["IsApproved"]);
                        string content = reader["Content"].ToString();
                        string videoUrl = reader["VideoUrl"].ToString();
                        string type = reader["Type"].ToString();

                        Publication p = null;
                        if (type == "DailyNews")
                        {
                            int trend = reader["TrendLevel"] != DBNull.Value ? Convert.ToInt32(reader["TrendLevel"]) : 0;
                            p = new DailyNews(id, title, publishDate, trend);
                        }
                        else if (type == "BreakingNews")
                        {
                            int trend = reader["TrendLevel"] != DBNull.Value ? Convert.ToInt32(reader["TrendLevel"]) : 0;
                            p = new BreakingNews(id, title, publishDate, trend);
                        }
                        else if (type == "VideoReport")
                        {
                            string resolution = reader["Resolution"].ToString();
                            p = new VideoReport(id, title, publishDate, 0, resolution);
                        }
                        else if (type == "WeeklyMagazine")
                        {
                            string author = reader["Author"].ToString();
                            p = new WeeklyMagazine(id, title, publishDate, author);
                        }

                        if (p != null)
                        {
                            p.Content = content;
                            p.VideoUrl = videoUrl;
                            p.IsApproved = isApproved;
                            _postList.Add(p);
                        }
                    }
                }
            }
        }
    }

    public void AddPost(Publication post)
    {
        if (post == null || string.IsNullOrWhiteSpace(post.Id)) return;

        bool isExist = this._postList.Any(p => p.Id.Equals(post.Id.Trim(), StringComparison.OrdinalIgnoreCase));
        if (isExist) return;

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            string query = "INSERT INTO Publications (Id, Title, PublishDate, IsApproved, Content, VideoUrl, Type, TrendLevel, Resolution, Author) VALUES (@Id, @Title, @PublishDate, @IsApproved, @Content, @VideoUrl, @Type, @TrendLevel, @Resolution, @Author)";
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@Id", post.Id);
                cmd.Parameters.AddWithValue("@Title", post.Title);
                cmd.Parameters.AddWithValue("@PublishDate", post.PublishDate);
                cmd.Parameters.AddWithValue("@IsApproved", post.IsApproved);
                cmd.Parameters.AddWithValue("@Content", post.Content ?? "");
                cmd.Parameters.AddWithValue("@VideoUrl", post.VideoUrl ?? "");

                string type = "DailyNews";
                object trend = DBNull.Value;
                object resolution = DBNull.Value;
                object author = DBNull.Value;

                if (post is BreakingNews b) { type = "BreakingNews"; trend = b.TrendLevel; }
                else if (post is DailyNews d) { type = "DailyNews"; trend = d.TrendLevel; }
                else if (post is VideoReport v) { type = "VideoReport"; resolution = v.Resolution; }
                else if (post is WeeklyMagazine w) { type = "WeeklyMagazine"; author = w.Author; }

                cmd.Parameters.AddWithValue("@Type", type);
                cmd.Parameters.AddWithValue("@TrendLevel", trend);
                cmd.Parameters.AddWithValue("@Resolution", resolution);
                cmd.Parameters.AddWithValue("@Author", author);

                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    this._postList.Add(post);
                }
            }
        }
    }

    public bool UnapprovePost(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return false;

        Publication post = this._postList.FirstOrDefault(p => p.Id.Equals(id.Trim(), StringComparison.OrdinalIgnoreCase));
        if (post == null) return false;

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE Publications SET IsApproved = 0 WHERE Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id.Trim());
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    post.IsApproved = false;
                    return true;
                }
            }
        }
        return false;
    }

    public bool ApprovePost(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return false;

        Publication post = this._postList.FirstOrDefault(p => p.Id.Equals(id.Trim(), StringComparison.OrdinalIgnoreCase));
        if (post == null) return false;

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("UPDATE Publications SET IsApproved = 1 WHERE Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id.Trim());
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    post.IsApproved = true;
                    return true;
                }
            }
        }
        return false;
}

    public bool RemovePost(string id)
    {
        if (string.IsNullOrWhiteSpace(id)) return false;

        Publication post = this._postList.FirstOrDefault(p => p.Id.Equals(id.Trim(), StringComparison.OrdinalIgnoreCase));
        if (post == null) return false;

        using (SqlConnection conn = new SqlConnection(_connectionString))
        {
            conn.Open();
            using (SqlCommand cmd = new SqlCommand("DELETE FROM Publications WHERE Id = @Id", conn))
            {
                cmd.Parameters.AddWithValue("@Id", id.Trim());
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    this._postList.Remove(post);
                    return true;
                }
            }
        }
        return false;
    }

    public List<Publication> GetPostList()
    {
        return this._postList;
    }
}