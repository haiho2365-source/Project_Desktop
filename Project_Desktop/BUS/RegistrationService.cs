using System;

namespace Project_Desktop
{
    public class RegistrationService
    {
        private Database _database;

        public RegistrationService(Database database)
        {
            this._database = database;
        }

        public bool Register(string id, string fullName, string email, string password)
        {
            if (this._database.IsEmailExists(email) == true || this._database.IsUserIdExists(id) == true)
            {
                return false;
            }

            
            Subscriber newUser = new Subscriber(id, fullName, email, false, password);

            this._database.AddSubscriber(newUser);

            return true;
        }
    }
}
