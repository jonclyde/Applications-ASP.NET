using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement2K23.Configurations.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "r120303a-bf81-4802-bd34-a90f17ac61ca",
                    UserId = "a1e4d073-2b6a-4ad1-9fb2-3ab393b62f46",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "r220303a-bf81-4802-bd34-a90f17ac61ca",
                    UserId = "u1e4d073-2b6a-4ad1-9fb2-3ab393b62f46",
                }
           );
        }
    }
}