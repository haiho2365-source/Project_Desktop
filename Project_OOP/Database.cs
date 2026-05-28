using System;
using System.Collections.Generic;
using System.IO;

namespace Project_OOP
{
    [Serializable]
    public class Database
    {
        private List<Subscriber> _subscribers;
        private List<Admin> _admins;

        private DataStorageUtility _storage = new DataStorageUtility();
        private string _filePath = "user_accounts.xml";

        public Database()
        {
            this._subscribers = new List<Subscriber>();
            this._admins = new List<Admin>();
            LoadFromFile();
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
            SaveToFile(); 
        }

        public void AddAdmin(Admin admin)
        {
            this._admins.Add(admin);
        }

        public bool IsEmailExists(string email)
        {
            int i;
            for (i = 0; i < this._subscribers.Count; i = i + 1)
            {
                if (this._subscribers[i].Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public void SaveToFile()
        {
            _storage.SaveData<List<Subscriber>>(this._subscribers, _filePath);
        }

        private void LoadFromFile()
        {
            if (File.Exists(_filePath))
            {
                List<Subscriber> loadedUsers = _storage.LoadData<List<Subscriber>>(_filePath);
                if (loadedUsers != null)
                {
                    this._subscribers = loadedUsers;
                }
            }
        }
    }
}