using System;
namespace online_marketplace
{
    public class User
    {
        private int userId;
        private string username;
        private string email;
        private DateTime dateRegistered;

        public int UserId 
        { 
            get { return userId; } // read only
        }
        public string Username 
        { 
            get { return username; } 
            set { username = value; } 
        }
        public string Email 
        { 
            get { return email; } 
            set { email = value; } 
        }
        public DateTime DateRegistered 
        { 
            get { return dateRegistered; } 
            private set { dateRegistered = value; } 
        }

        public User(string username, string email)
        {
            userId = new Random().Next(1, 1000000); // userId is generated randomly.
            Username = username;
            Email = email;
            DateRegistered = DateTime.Now;
        }
    }
}

