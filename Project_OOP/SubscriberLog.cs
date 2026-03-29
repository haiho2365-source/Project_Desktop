using System;
using System.Collections.Generic;

namespace Project_OOP
{
    public class SubscriberLoginService
    {
        private Database _database;

        public SubscriberLoginService(Database database)
        {
            this._database = database;
        }

        public Subscriber Login(string email)
        {
            int i;
            List<Subscriber> subscribers = this._database.Subscribers;
            for (i = 0; i < subscribers.Count; i = i + 1)
            {
                Subscriber sub = subscribers[i];

                if (sub.Email == email)
                {
                    return sub;
                }
            }
            return null;
        }
    }
}