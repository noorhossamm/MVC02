using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVC02.Entities;

namespace MVC02.Configurations
{
    public class MembershipConfigurations : IEntityTypeConfiguration<Membership>
    {
        public void Configure(EntityTypeBuilder<Membership> builder)
        {
            builder.HasKey(MS => MS.Id);

            builder.Property(MS => MS.CreatedAt).HasDefaultValueSql("GETDATE()");


            builder.HasOne(MS => MS.Member)
                .WithMany(M => M.MemberSubscriptions)
                .HasForeignKey(MS => MS.MemberId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(MS => MS.Plan)
                .WithMany(P =>P.PlanSubscriptions)
                .HasForeignKey(MS => MS.PlanId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Ignore(MS => MS.Status);



        }
    }
}
