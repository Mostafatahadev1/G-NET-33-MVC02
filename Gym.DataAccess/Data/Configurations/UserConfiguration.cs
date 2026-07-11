using Gym.DataAccess.Entities;
using Gym.DataAccess.Entities.ValueObject;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.DataAccess.Data.Configurations;

public class UserConfiguration<T> : IEntityTypeConfiguration<T>
    where T : User
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasDiscriminator<string>("UserType")
            .HasValue<Member>("Member")
            .HasValue<Trainer>("Trainer");

        builder.Property(u => u.Name)
            .HasMaxLength(100);

        builder.Property(u => u.Email)
           .HasMaxLength(100);

        builder.Property(u => u.Phone)
          .HasMaxLength(20);


        builder.OwnsOne(x=>x.Address,a=>
            {
                 a.Property(a => a.Street)
                 .HasColumnName("Street")
                 .HasMaxLength(100);


                 a.Property(a => a.City)
                .HasColumnName("City")
                .HasMaxLength(100);

                 a.Property(a => a.BuildingNumber)
                 .HasColumnName("BuildingNumber");

            });

        builder.HasIndex(u => u.Email)
            .IsUnique();


        builder.HasIndex(u => u.Phone)
          .IsUnique();




        //Phone Format


        builder.ToTable(t =>
        {
            t.HasCheckConstraint("User_Phone_CK", "LEN([Phone]) = 11 AND[Phone] LIKE 01[0125]%'");
        });


        // users.tolist(); // softdeleted

        builder.HasQueryFilter(u => !u.IsDeleted);

        // enums integer 0 1






    }
}