using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC02.Entities;

namespace MVC02.Configurations
{
    public class GymUserConfigurations<T> : IEntityTypeConfiguration<T> where T : GymUser
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            builder.Property(U => U.Name)
                .HasColumnType("varchar")
                .HasMaxLength(50);


            builder.Property(U => U.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100);


            builder.Property(U => U.Phone)
                .HasColumnType("varchar")
                .HasMaxLength(11);

            builder.HasIndex(U => U.Phone).IsUnique();
            builder.HasIndex(U => U.Email).IsUnique();

            builder.ComplexProperty(U => U.Address);

            builder.ToTable(T =>
            {

                T.HasCheckConstraint("EmailFormat_Check","Email LIKE '%_@_%._%'");
                T.HasCheckConstraint("PhoneFormat_Check","LEN(Phone) = 11 AND (Phone LIKE '010%' OR Phone LIKE '011%' OR Phone LIKE '012%' OR Phone LIKE '015%')");

            });
        }
    }
}
