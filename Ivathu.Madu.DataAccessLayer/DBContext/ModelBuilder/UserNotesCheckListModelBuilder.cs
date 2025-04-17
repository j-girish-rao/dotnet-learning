using Ivathu.Madu.DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace Ivathu.Madu.DataAccessLayer
{
    internal static partial class UserNotesCheckListModelBuilder
    {
        public static void AddUserNotesCheckListModelBuilder(this ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<UserNotesCheckList>(entity =>
            {
                entity.ToTable("UserNotesCheckList");

                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");
                entity.Property(e => e.Name).HasMaxLength(256);

                entity.HasOne(d => d.ParentUserNotes).WithMany(p => p.UserNotesCheckLists)
                    .HasForeignKey(d => d.ParentUserNotesId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserNotesCheckList_UserNotes");
            });
        }
    }
}