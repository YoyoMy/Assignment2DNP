using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Model;

namespace FileData
{
    public class FileContext
    {
        public IList<Family> Families { get; private set; }
        public IList<Adult> Adults { get; private set; }
        public IList<User> Users { get; set; }

        private readonly string familiesFile = "families.json";
        private readonly string adultsFile = "adults.json";

        private readonly string usersFile = "users.json";

        public FileContext()
        {
            Families = File.Exists(familiesFile) ? ReadData<Family>(familiesFile) : new List<Family>();
            Adults = File.Exists(adultsFile) ? ReadData<Adult>(adultsFile) : new List<Adult>();
            Users = File.Exists(usersFile) ? ReadData<User>(usersFile) : new List<User>();
        }

        private IList<T> ReadData<T>(string s)
        {
            using (var jsonReader = File.OpenText(s))
            {
                return JsonSerializer.Deserialize<List<T>>(jsonReader.ReadToEnd());
            }
        }

        public User ValidateUser(string username, string pass)
        {
            User us = Users.FirstOrDefault(user => user.Username.Equals(username));
            if (us == null)
            {
                throw new Exception("User not found.");
            }
            if (!us.Password.Equals(pass))
            {
                throw new Exception("Incorrect password");
            }
            return us;
        }
        public void SaveUser()
        {
            // storing users
            string jsonUsers = JsonSerializer.Serialize(Users, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(usersFile, false))
            {
                outputFile.Write(jsonUsers);
            }
        }
        public void SaveChanges()
        {
            // storing families
            string jsonFamilies = JsonSerializer.Serialize(Families, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(familiesFile, false))
            {
                outputFile.Write(jsonFamilies);
            }

            // storing persons
            string jsonAdults = JsonSerializer.Serialize(Adults, new JsonSerializerOptions
            {
                WriteIndented = true
            });
            using (StreamWriter outputFile = new StreamWriter(adultsFile, false))
            {
                outputFile.Write(jsonAdults);
            }
        }
    }
}