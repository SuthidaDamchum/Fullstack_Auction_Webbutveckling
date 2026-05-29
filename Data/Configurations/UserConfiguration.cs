using Domain.Entities;
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
                    },

                    new User
                    {
                        Id = 3,
                        Name = "Suthida Damchum",
                        Email = "suthida@hotmail.com",
                        PasswordHash = "$2a$12$M71HKUQxR3DzFHv57qraSeOrkOXyUbb9QKIbQur.uLRGEpoyhC6NG",
                        Role = "user",
                        IsActive = true
                    },
                     new User
                     {
                         Id = 4,
                         Name = "Rasmus Back",
                         Email = "rasmus@hotmail.com",
                         PasswordHash = "$2a$12$nra4y5TWIclit4uNxe4kB.Cc69sjhrs9M9Xm5QHIiuktsn0KdXwsa",
                         Role = "user",
                         IsActive = true
                     },
                     new User
                     {
                         Id = 5,
                         Name = "Amanda Park",
                         Email = "amanda@hotmail.com",
                         PasswordHash = "$2a$12$7MDFLndGn.n2BiDRw7W3Kem1DAztZUNgpmSbK1zOmyHk7h0VDarBS",
                         Role = "user",
                         IsActive = true
                     }
                ); 
        }
    }
}
