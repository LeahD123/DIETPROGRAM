using DietP.Core.Entities;
using Microsoft.EntityFrameworkCore;

public class DietContext : DbContext
{
    public DbSet<Calendar> calendar {  get; set; }
    public DbSet<FoodsItem> FoodsItem { get; set; }
    public DbSet<Sport> Sport { get; set; }
    public DbSet<User> User { get; set; }

    // בנאי שמקבל DbContextOptions ומעביר אותו לבסיס
    public DietContext(DbContextOptions<DietContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var serverVersion = new MySqlServerVersion(new Version(8, 0, 0)); // שנה את הגרסה לגרסה שלך

            // קריאה למשתנה הסביבתי
            var connectionString = Environment.GetEnvironmentVariable("ConnectionStrings_DefaultConnection");
            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
