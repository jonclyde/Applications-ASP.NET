using LeaveManagement.Common.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configurations.Entities
{
    public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                   new IdentityRole
                   {
                       Id = "r120303a-bf81-4802-bd34-a90f17ac61ca",
                       Name = Roles.Administrator,
                       NormalizedName = Roles.Administrator.ToUpper()
                   },
                   new IdentityRole
                   {
                       Id = "r220303a-bf81-4802-bd34-a90f17ac61ca",
                       Name = Roles.User,
                       NormalizedName = Roles.User.ToUpper()
                   }
                );
        }
    }
}