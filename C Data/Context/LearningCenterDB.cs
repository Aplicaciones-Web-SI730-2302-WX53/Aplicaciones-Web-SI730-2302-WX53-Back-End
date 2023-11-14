using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class LearningCenterDB: DbContext
{
    public LearningCenterDB()
    {
        
    }
    
    public LearningCenterDB(DbContextOptions<LearningCenterDB> options) : base(options)
    {
    }
    public DbSet<Tutorial> Tutorials { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=127.0.0.1,3306;Uid=root;Pwd=LaUpc123*;Database=learningCenterConnection;", serverVersion);
        }
    }
    
}