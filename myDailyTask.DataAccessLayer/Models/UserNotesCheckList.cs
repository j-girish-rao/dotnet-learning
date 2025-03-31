namespace myDailyTask.DataAccessLayer.Models;

public partial class UserNotesCheckList
{
    public Guid Id { get; set; }

    public Guid ParentUserNotesId { get; set; }

    public string? Name { get; set; }

    public bool IsCompleted { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime ModifiedDate { get; set; }

    public virtual UserNote ParentUserNotes { get; set; } = null!;
}
