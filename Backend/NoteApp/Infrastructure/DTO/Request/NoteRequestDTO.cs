using System.ComponentModel.DataAnnotations;

namespace NoteApp.Infrastructure.DTO.Request
{
    public class NoteRequestDTO
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(4000)]
        public string Details { get; set; }
    }
}
