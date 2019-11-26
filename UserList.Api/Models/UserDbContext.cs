using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace UserList.Api.Models
{
    public class UserDbContext : DbContext
    {
        
        public UserDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    FirstName = "Fred",
                    FamilyName = "Bloggs",
                    Username = "FBloggs99"
                },
                new User
                {
                    FirstName = "Bob",
                    FamilyName = "Smith",
                    Username = "BSmith"
                },
                new User
                {
                    FirstName = "Billy",
                    FamilyName = "Smith",
                    Username = "Billy99"
                },
                new User
                {
                    FamilyName = "Prince",
                    Username = "Prince"
                });
        }


        public DbSet<User> Users { get; set; }
    }

    public class UserDbContextFactory : IDesignTimeDbContextFactory<UserDbContext>
    {
        public UserDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<UserDbContext>();
            optionsBuilder.UseSqlite("Data Source=Users.db");

            return new UserDbContext(optionsBuilder.Options);
        }
    }
}