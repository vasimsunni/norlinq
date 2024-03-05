using Microsoft.AspNetCore.Mvc;
using NoteApp.Infrastructure.DTO.Request;
using NoteApp.Infrastructure.DTO.Response;
using NoteApp.Services.Note;

namespace NoteApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly INoteService noteService;

        public NoteController(INoteService noteService)
        {
            this.noteService = noteService;
        }

        [HttpGet("")]
        public async Task<ResponseDTO<IEnumerable<NoteResponseDTO>>> All()
        {
            return await noteService.All();
        }

        [HttpGet("{id}")]
        public async Task<ResponseDTO<NoteResponseDTO>> Get(Guid id)
        {
            return await noteService.GetById(id);
        }

        [HttpPost]
        public ResponseDTO<bool> Push(NoteRequestDTO note)
        {
            return noteService.Add(note);
        }

        [HttpPut]
        public ResponseDTO<bool> Put(NoteRequestDTO note)
        {
            return noteService.Update(note);
        }

        [HttpDelete("{id}")]
        public ResponseDTO<bool> Delete(Guid id)
        {
            return noteService.Delete(id);
        }
    }
}
