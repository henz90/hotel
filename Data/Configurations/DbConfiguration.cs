using hotel.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace hotel.Data.Configurations
{
    public class DbConfiguration: IEntityTypeConfiguration<Reservation>
    {
        public void Configure(EntityTypeBuilder<Reservation> builder)
        {
        }

        public void Configure(EntityTypeBuilder<Room> builder)
        {
        }
    }
}