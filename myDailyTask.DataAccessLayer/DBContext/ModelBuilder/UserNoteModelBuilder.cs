using Microsoft.EntityFrameworkCore;
using myDailyTask.DataAccessLayer.Models;

namespace myDailyTask.DataAccessLayer
{
    internal static partial class UserNoteModelBuilder
    {
        public static void AddUserNoteModelBuilder(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserNote>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Content).HasMaxLength(1024);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.Heading).HasMaxLength(256);
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.HasOne(d => d.ParentSeverity).WithMany(p => p.UserNotes)
                    .HasForeignKey(d => d.ParentSeverityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserNotes_SeverityMaster");
            });
        }
    }
}
