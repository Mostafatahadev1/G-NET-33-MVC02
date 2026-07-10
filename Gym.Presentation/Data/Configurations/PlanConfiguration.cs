using Gym.Presentation.Models;
using Microsoft.EntityFrameworkCore;

namespace Gym.Presentation.Data.Configurations
{
    public class PlanConfiguration : IEntityTypeConfiguration<Plan> 
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Plan> builder)
        {
            builder.Property(b => b.Name)
                .HasMaxLength(50);

            builder.Property(b => b.Description)
                .HasMaxLength(200);

            builder.Property(b => b.Price)
                .HasPrecision(18, 2);

            builder.ToTable(tb =>
            {
                tb.HasCheckConstraint("PlanDurationDays",
                    "DurationDays BETWEEN 1 AND 365");

            });

            builder.HasIndex(b => b.Name)
                .IsUnique();

        }
    }
}
