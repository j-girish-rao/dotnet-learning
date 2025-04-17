namespace Ivathu.Madu.DataAccessLayer.Models
{
    public partial class UserNote
    {
        public Guid Id { get; set; }

        public Guid ParentSeverityId { get; set; }

        public string Heading { get; set; }

        public string Content { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual SeverityMaster ParentSeverity { get; set; }

        public virtual ICollection<UserNotesCheckList> UserNotesCheckLists { get; set; } = new List<UserNotesCheckList>();
    }

}