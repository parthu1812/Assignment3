using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Assignment3
{
    public class Authmanager
    {
      
        private readonly UserFileManager userFileManager;

        public Authmanager()
        {
            userFileManager = new UserFileManager();
        }

        public bool AuthenticateUser(string username, string password)
        {
            return userFileManager.ValidateCredentials(username, password);
        }

        public bool RegisterUser(string username, string password)
        {
            return userFileManager.AddUser(username, password);
        }
    }
}
