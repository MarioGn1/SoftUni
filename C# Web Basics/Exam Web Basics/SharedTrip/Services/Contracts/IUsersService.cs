﻿namespace SharedTrip.Services.Contracts
{
    public interface IUsersService
    {
        void CreateUser(string username, string email, string password);

        bool IsEmailAvailable(string email);

        string GetUserId(string username, string password);

        bool IsUsernameAvailable(string username);
    }
}
