using System;
using System.IO;
using System.Xml.Serialization; // Đổi thư viện sang XML

public class DataStorageUtility
{
    public bool SaveData<T>(T dataToSave, string filePath)
    {
        FileStream fileStream = null;
        try
        {
            fileStream = new FileStream(filePath, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            serializer.Serialize(fileStream, dataToSave);
            return true;
        }
        catch (Exception exception)
        {
            throw new Exception("Lỗi lưu file: " + exception.Message);
        }
        finally
        {
            if (fileStream != null)
            {
                fileStream.Close();
            }
        }
    }

    public T LoadData<T>(string filePath)
    {
        if (File.Exists(filePath) == false)
        {
            return default(T);
        }

        FileStream fileStream = null;
        try
        {
            fileStream = new FileStream(filePath, FileMode.Open);
            XmlSerializer serializer = new XmlSerializer(typeof(T));

            object loadedObject = serializer.Deserialize(fileStream);
            T resultData = (T)loadedObject;

            return resultData;
        }
        catch (Exception exception)
        {
            throw new Exception("Lỗi đọc file: " + exception.Message);
        }
        finally
        {
            if (fileStream != null)
            {
                fileStream.Close();
            }
        }
    }
}