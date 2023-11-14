using Data.DBContext;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class UserData : IUserData
{
    private LearningCenterBDCOntext _learningCenterDbContext;

    public UserData(LearningCenterBDCOntext learningCenterDbContext)
    {
        _learningCenterDbContext = learningCenterDbContext;
    }

    public async Task<User> GetByUsername(string username)
    {
        return await _learningCenterDbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
    }
    

    public async Task<int> Signup(User user)
    {
        user.DateCreated = DateTime.Now;
        _learningCenterDbContext.Users.Add(user);
        await _learningCenterDbContext.SaveChangesAsync();
        return user.Id;
    }
}