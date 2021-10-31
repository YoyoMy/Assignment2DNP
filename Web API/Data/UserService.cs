using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
namespace FileData
{
    public class UserService : IUserService
    {
        private FileContext fileContext = new FileContext();

        public async Task<IList<User>> GetUsersAsync()
        {
            return fileContext.Users;
        }
        public async Task AddUserAsync(User user)
        {
            fileContext.Users.Add(user);
            fileContext.SaveUser();
        }
        public async Task<User> ValidateUser(string username, string password)
        {
            return fileContext.ValidateUser(username, password);
        }
    }
}