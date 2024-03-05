using System.ComponentModel.DataAnnotations;

namespace NoteApp.Core.Entity
{
    public class Note
    {
        [Key]
        public Guid Id { get; set; }
        [MaxLength(4000)]
        public string Details { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
