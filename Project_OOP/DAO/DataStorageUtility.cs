using System;
using System.IO;
using System.Xml.Serialization;
using System.Data.SqlClient;

public class DataStorageUtility
{
    private string _connectionString = "Server=LAPTOP-2C4LFE1O\\SQLEXPRESS;Database=Project_Desktop;Trusted_Connection=True;TrustServerCertificate=True;";

    public bool SaveData<T>(T dataToSave, string filePath)
    {
        try
        {
            string xmlText;
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringWriter writer = new StringWriter())
            {
                serializer.Serialize(writer, dataToSave);
                xmlText = writer.ToString();
            }

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "IF EXISTS (SELECT 1 FROM XmlStorage WHERE FilePath = @FilePath) " +
                               "UPDATE XmlStorage SET XmlContent = @XmlContent WHERE FilePath = @FilePath " +
                               "ELSE INSERT INTO XmlStorage (FilePath, XmlContent) VALUES (@FilePath, @XmlContent)";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FilePath", filePath);
                    cmd.Parameters.AddWithValue("@XmlContent", xmlText);
                    cmd.ExecuteNonQuery();
                }
            }
            return true;
        }
        catch (Exception exception)
        {
            throw new Exception("Lỗi lưu database SQL: " + exception.Message);
        }
    }

    public T LoadData<T>(string filePath)
    {
        try
        {
            string xmlText = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                string query = "SELECT XmlContent FROM XmlStorage WHERE FilePath = @FilePath";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@FilePath", filePath);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        xmlText = result.ToString();
                    }
                }
            }

            if (string.IsNullOrEmpty(xmlText))
            {
                return default(T);
            }

            XmlSerializer serializer = new XmlSerializer(typeof(T));
            using (StringReader reader = new StringReader(xmlText))
            {
                return (T)serializer.Deserialize(reader);
            }
        }
        catch (Exception exception)
        {
            throw new Exception("Lỗi đọc database SQL: " + exception.Message);
        }
    }
}