using Microsoft.EntityFrameworkCore;
using myDailyTask.DataAccessLayer.Models;

namespace myDailyTask.DataAccessLayer
{
    internal static partial class SeverityMasterModelBuilder
    {
        public static void AddSeverityMasterModelBuilder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SeverityMaster>(entity =>
            {
                entity.ToTable("SeverityMaster");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Color).HasMaxLength(16);
                entity.Property(e => e.Name).HasMaxLength(256);
            });
        }
    }
}