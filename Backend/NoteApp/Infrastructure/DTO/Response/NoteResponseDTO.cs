namespace NoteApp.Infrastructure.DTO.Response
{
    public class NoteResponseDTO
    {
        public Guid Id { get; set; }
        public string Details { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
