using System;
using System.Collections.Generic;

namespace Project_OOP
{
    public class AdminLoginService
    {
        private Database _database;

        public AdminLoginService(Database database)
        {
            this._database = database;
        }

        public bool Login(string email, string password)
        {
            int i;
            List<Admin> admins = this._database.Admins;
            for (i = 0; i < admins.Count; i = i + 1)
            {
                Admin admin = admins[i];
                if (admin.Email == email && admin.CheckPassword(password))
                {
                    return true;
                }
            }
            return false;
        }
    }
}