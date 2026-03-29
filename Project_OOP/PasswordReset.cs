using System;
using System.Collections.Generic;

namespace Project_OOP
{
    public class PasswordResetService
    {
        private Database _database;

        public PasswordResetService(Database database)
        {
            this._database = database;
        }

        public bool ResetPassword(string email, string newPassword)
        {
            int i;
            List<Admin> admins = this._database.Admins;

            for (i = 0; i < admins.Count; i = i + 1)
            {
                Admin admin = admins[i];

                if (admin.Email == email)
                {
                    admin.Password = newPassword;
                    return true;
                }
            }
            return false;
        }
    }
}