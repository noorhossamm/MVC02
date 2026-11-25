using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC02.Entities;

namespace MVC02.Configurations
{
    public class SessionConfigurations : IEntityTypeConfiguration<Session>
    {
        public void Configure(EntityTypeBuilder<Session> builder)
        {
            builder.Property(S => S.CreatedAt).HasDefaultValueSql("GETDATE()");

            builder.ToTable(T =>
            {
                T.HasCheckConstraint("Session_CapacityCheck", "Capacity BETWEEN 1 AND 25");
                T.HasCheckConstraint("Session_StartEndCheck","EndDate > StartDate");

            });

            builder.HasOne(T => T.Trainer)
                .WithMany(S => S.Sessions)
                .HasForeignKey(S => S.TrainerId)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
