namespace myDailyTask.DataAccessLayer.Models;

public partial class SeverityMaster
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;

    public int Priority { get; set; }

    public string Color { get; set; } = null!;

    public virtual ICollection<UserNote> UserNotes { get; set; } = new List<UserNote>();
}
