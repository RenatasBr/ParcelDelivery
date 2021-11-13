using Microsoft.EntityFrameworkCore;
using ParcelDeliveryBE.Models;

namespace ParcelDeliveryBE.DAL
{
    public class DataContext : DbContext
	{
		public DbSet<PostMachine> PostMachines { get; set; }

		public DbSet<Parcel> Parcels { get; set; }

		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<PostMachine>()
				.Property(pm => pm.City)
				.IsRequired()
				.HasMaxLength(55);

			modelBuilder.Entity<PostMachine>()
				.Property(pm => pm.Code)
				.IsRequired()
				.HasMaxLength(20);
			
			modelBuilder.Entity<PostMachine>()
				.HasOne(pm => pm.Parcel)
				.WithMany()
				.OnDelete(DeleteBehavior.Restrict);

			modelBuilder.Entity<Parcel>()
				.Property(p => p.WeightInKg)
				.IsRequired()
				.HasColumnType("decimal")
				.HasPrecision(6, 3);

			modelBuilder.Entity<Parcel>()
				.Property(p => p.Receiver)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<Parcel>()
				.Property(p => p.ReceiverPhoneNo)
				.IsRequired()
				.HasMaxLength(12);

			modelBuilder.Entity<Parcel>()
				.Property(p => p.Description)
				.IsRequired()
				.HasMaxLength(200);
		}

	}
}
