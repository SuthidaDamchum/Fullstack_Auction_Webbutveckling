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
                        PasswordHash = "$2a$12$wawXKUQVTcH3TQb7CJW0QeWlW6ok1wN2C7LLsZZCVVRZuD2E7w7em",
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
                        PasswordHash = "$2a$12$i5PUbFxSc6N7QH1WAHt1i.1S7RVcafYAWiyG36xG42LnCU917dJP",
                        Role = "user",
                        IsActive = true
                    },
                     new User
                     {
                         Id = 4,
                         Name = "Rasmus Back",
                         Email = "rasmus@hotmail.com",
                         PasswordHash = "$2a$12$WQ3NsQgOPjctZwvk/dJu8emIZXV57JWUN0uD.QCYgqsFjneNk7uwG",
                         Role = "user",
                         IsActive = true
                     },
                     new User
                     {
                         Id = 5,
                         Name = "Amanda Park",
                         Email = "amanda@hotmail.com",
                         PasswordHash = "$2a$12$MdZbX9THP5GtTJ/7lEJpcOLComityiZK7FejdUWiRCh1QhCmow4v",
                         Role = "user",
                         IsActive = true
                     }
                ); 
        }
    }
}
