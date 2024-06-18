using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using api.Models.Domain;

namespace api.Data
{
    public class AuthDbContext : IdentityDbContext<User>
    {

        public DbSet<Event>? Events { get; set; }
        public DbSet<Ticket>? Tickets { get; set; }

        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var normalRoleId = "28d65a5b-a7db-4850-b380-83591f7d7531";
            var adminRoleId = "9740f16c-24a1-4224-a7be-1bb00b7c6892";

            // Create Reader and Writer Role
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Id = normalRoleId,
                    Name = "normal",
                    NormalizedName = "normal".ToUpper(),
                    ConcurrencyStamp = normalRoleId
                },
                new IdentityRole()
                {
                    Id = adminRoleId,
                    Name = "admin",
                    NormalizedName = "admin".ToUpper(),
                    ConcurrencyStamp = adminRoleId
                }
            };

            // Seed the roles
            builder.Entity<IdentityRole>().HasData(roles);


            // Create an Admin User
            var adminUserId = "edc267ec-d43c-4e3b-8108-a1a1f819906d";
            var admin = new User()
            {
                Id = adminUserId,
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                NormalizedEmail = "admin@gmail.com".ToUpper(),
                NormalizedUserName = "admin@gmail.com".ToUpper()
            };

            admin.PasswordHash = new PasswordHasher<User>().HashPassword(admin, "Admin@123");

            builder.Entity<User>().HasData(admin);

            // Give Roles To Admin

            var adminRoles = new List<IdentityUserRole<string>>()
            {
                
                new()
                {
                    UserId = adminUserId,
                    RoleId = adminRoleId
                }
            };

            builder.Entity<IdentityUserRole<string>>().HasData(adminRoles);
        }
    }
}
