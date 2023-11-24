using Microsoft.EntityFrameworkCore;
using WeatherMoscow.Models;

namespace WeatherMoscow.Database
{
    public partial class WeatherMoscowContext : DbContext
    {
        public WeatherMoscowContext()
        {
        }

        public WeatherMoscowContext(DbContextOptions<WeatherMoscowContext> options)
            : base(options)
        {
        }

        public virtual DbSet<WeatherRecord> WeatherRecord { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WeatherRecord>(entity =>
            {
                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.DewPoint).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Humidity).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Temperature).HasColumnType("decimal(6, 3)");

                entity.Property(e => e.Time)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.WeatherConditions).HasMaxLength(100);

                entity.Property(e => e.WindDirection).HasMaxLength(30);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
