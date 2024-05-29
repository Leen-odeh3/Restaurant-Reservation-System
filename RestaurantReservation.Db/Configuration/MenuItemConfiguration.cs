using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using RestaurantReservation.Db.Entities;

namespace RestaurantReservation.Db.Configuration
{
    public class MenuItemConfiguration : IEntityTypeConfiguration<MenuItem>
    {
        public void Configure(EntityTypeBuilder<MenuItem> builder)
        {
            builder.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(e => e.Price)
                .IsRequired();

            builder.HasOne(e => e.Restaurant)
                .WithMany(e => e.MenuItems)
                .HasForeignKey(e => e.RestaurantId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
