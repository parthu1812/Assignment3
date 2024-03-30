using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class UserFileManager
    {
        private const string UserFilePath = "C:\\Users\\PARTHU\\OneDrive\\Desktop\\c#Assignment-3\\User.txt";

        
       
        public bool ValidateCredentials(string username, string password)
        {
            if (!File.Exists(UserFilePath))
                return false;

            string[] lines = File.ReadAllLines(UserFilePath);
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                if (parts.Length == 2 && parts[0].Trim() == username && parts[1].Trim() == password)
                {
                    return true;
                }
            }
            return false;
        }

        public bool AddUser(string username, string password)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(UserFilePath, true))
                {
                    writer.WriteLine($"\n{username},{password}");
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
