using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(

                    new User
                    {
                        Id = 1,
                        Name = "Admin",
                        Email = "admin@auction.com",
                        PasswordHash = "$2a$12$k.CAYoiBFeMKOU6wVgeH6eMLtrVlynJBz/kTM1eGAcSkMn3W5WjsO",
                        Role = "admin",
                        IsActive = true
                    },
                    new User
                    {
                        Id = 2,
                        Name = "Anna Svensson",
                        Email = "anna@gmail.com",
                        PasswordHash = "$2a$12$socZ4WBBbqi8WOHeAL5PE.sZo5l9/Z/q2KYID5zp1E6TGg6JCcRh6",
                        Role = "user",
                        IsActive = true
                    }
                ); 
        }
    }
}
