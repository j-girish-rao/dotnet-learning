namespace Ivathu.Madu.DataAccessLayer.Models 
{
    public partial class SeverityMaster
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Priority { get; set; }

        public string Color { get; set; }

        public virtual ICollection<UserNote> UserNotes { get; set; } = new List<UserNote>();
    }
}
