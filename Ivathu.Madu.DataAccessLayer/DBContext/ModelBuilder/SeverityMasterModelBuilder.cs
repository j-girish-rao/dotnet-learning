using Ivathu.Madu.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Ivathu.Madu.DataAccessLayer
{
    internal static partial class SeverityMasterModelBuilder
    {
        public static void AddSeverityMasterModelBuilder(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<SeverityMaster>(entity =>
            {
                entity.ToTable("SeverityMaster");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Color)
                    .IsRequired()
                    .HasMaxLength(16);
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(256);
            });
        }
    }
}
