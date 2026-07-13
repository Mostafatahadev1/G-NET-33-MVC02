using Gym.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Gym.DataAccess.Configurations
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Bookings");



            builder.Property(x => x.IsAttended)
                   .HasDefaultValue(false);


            builder.HasIndex(x => new
            {
                x.MemberId,
                x.SessionId
            }).IsUnique();




            builder.ToTable(t =>
            {
                t.HasCheckConstraint(
                    "CK_Booking_Date",
                    "[Date] <= GETDATE()");
            }); 

        }
    }
}
