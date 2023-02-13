using LeaveManagement.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagement.Data.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();
            builder.HasData(
                new Employee
                {
                    Id = "a1e4d073-2b6a-4ad1-9fb2-3ab393b62f46",
                    Email = "admin@test.com",
                    NormalizedEmail = "ADMIN@TEST.COM",
                    Firstname = "System",
                    Lastname = "Admin",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    UserName = "admin@test.com",
                    NormalizedUserName = "ADMIN@TEST.COM",
                    EmailConfirmed = true
                },
                new Employee
                {
                    Id = "u1e4d073-2b6a-4ad1-9fb2-3ab393b62f46",
                    Email = "user@test.com",
                    NormalizedEmail = "USER@TEST.COM",
                    Firstname = "System",
                    Lastname = "User",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    UserName = "user@test.com",
                    NormalizedUserName = "USER@TEST.COM",
                    EmailConfirmed = true
                }
            );
        }
    }
}