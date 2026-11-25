using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC02.Entities;

namespace MVC02.Configurations
{
    public class PlanConfigurations : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.Property(P => P.CreatedAt).HasDefaultValueSql("GETDATE()");
            builder.ToTable(T =>
               {
                   T.HasCheckConstraint("PlanDuration_Check", "DurationDays BETWEEN 1 AND 365");

            });
        }
    }
}
