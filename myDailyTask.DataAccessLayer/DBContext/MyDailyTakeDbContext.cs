using Microsoft.EntityFrameworkCore;
using myDailyTask.DataAccessLayer;
using myDailyTask.DataAccessLayer.Models;

public partial class MyDailyTakeDbContext : DbContext
{
    public MyDailyTakeDbContext()
    {
    }

    public MyDailyTakeDbContext(DbContextOptions<MyDailyTakeDbContext> options) : base(options)
    {
    }

    public virtual DbSet<SeverityMaster> SeverityMasters { get; set; }

    public virtual DbSet<UserNote> UserNotes { get; set; }

    public virtual DbSet<UserNotesCheckList> UserNotesCheckLists { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=GIRISH;Database=myDailyTakeDb;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.AddSeverityMasterModelBuilder();
        modelBuilder.AddUserNoteModelBuilder();
        modelBuilder.AddUserNotesCheckListModelBuilder();
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
