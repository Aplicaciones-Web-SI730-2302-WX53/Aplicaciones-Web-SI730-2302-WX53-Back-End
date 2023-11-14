using Microsoft.EntityFrameworkCore;

namespace Data.DBContext;

public class LearningCenterBDCOntext : DbContext
{

    public LearningCenterBDCOntext()
    {
    }

    public LearningCenterBDCOntext(DbContextOptions<LearningCenterBDCOntext> options) : base(options)
    {
    }

    public DbSet<Tutorial> Tutorials { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<User> Users { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
            optionsBuilder.UseMySql("Server=sql10.freemysqlhosting.net,3306;Uid=sql10659802;Pwd=V35YEbVdq4;Database=sql10659802;", serverVersion);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Tutorial>().ToTable("Tutorial");
        builder.Entity<Tutorial>().HasKey(p => p.Id);
        builder.Entity<Tutorial>().Property(p => p.Title).IsRequired();
        builder.Entity<Tutorial>().Property(p => p.Title).HasMaxLength(60);
        builder.Entity<Tutorial>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Tutorial>().Property(p => p.IsActive).HasDefaultValue(true);
        
        
        builder.Entity<Category>().ToTable("Category");
        builder.Entity<Category>().HasKey(p => p.Id);
        builder.Entity<Category>().Property(p => p.Name).IsRequired();
        builder.Entity<Category>().Property(p => p.Name).HasMaxLength(20);
        builder.Entity<Category>().Property(p => p.DateCreated).HasDefaultValue(DateTime.Now);
        builder.Entity<Category>().Property(p => p.IsActive).HasDefaultValue(true);
        
    }

}