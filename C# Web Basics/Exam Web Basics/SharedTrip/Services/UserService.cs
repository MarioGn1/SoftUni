using SharedTrip.Data;
using SharedTrip.Data.Models;
using SharedTrip.Services.Contracts;
using System;
using System.Linq;

namespace SharedTrip.Services
{
    public class UserService : IUsersService
    {
        private readonly ApplicationDbContext context;
        private readonly PasswordHasher passwordHasher;

        public UserService(ApplicationDbContext context, PasswordHasher passwordHasher)
        {
            this.context = context;
            this.passwordHasher = passwordHasher;
        }
        public void CreateUser(string username, string email, string password)
        {
            var user = new User()
            {
                Username = username,
                Email = email,
                Password = passwordHasher.HashPassword(password)
            };

            context.Users.Add(user);
            context.SaveChanges();
        }

        public string GetUserId(string username, string password)
        {
            return context.Users
                 .Where(u => u.Username == username && u.Password == passwordHasher.HashPassword(password))
                 .Select(u => u.Id)
                 .FirstOrDefault();
        }

        public bool IsEmailAvailable(string email)
        {
            return context.Users.Any(u => u.Email == email);
        }

        public bool IsUsernameAvailable(string username)
        {
            return context.Users.Any(u => u.Username == username);
        }
    }
}
