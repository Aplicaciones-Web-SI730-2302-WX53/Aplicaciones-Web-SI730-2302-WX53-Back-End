namespace Data;

public interface IUserData
{
    Task<User> GetByUsername(string username);
    Task<int> Signup(User user);
}