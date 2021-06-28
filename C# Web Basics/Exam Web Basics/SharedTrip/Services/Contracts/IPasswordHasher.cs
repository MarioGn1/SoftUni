namespace SharedTrip.Services.Contracts
{
    public interface IPasswordHasher
    {
        public string HashPassword(string password);
    }
}
