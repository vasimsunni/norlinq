using NoteApp.Core.Repository;
using NoteApp.Infrastructure.DTO.Request;
using NoteApp.Infrastructure.DTO.Response;

namespace NoteApp.Services.Note
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Core.Entity.Note> noteRepository;

        public NoteService(IRepository<Core.Entity.Note> noteRepository)
        {
            this.noteRepository = noteRepository;
        }

        public async Task<ResponseDTO<IEnumerable<NoteResponseDTO>>> All()
        {
            ResponseDTO<IEnumerable<NoteResponseDTO>> response = new();

            try
            {
                var notes = await noteRepository.AllAsync();

                var noteResponse = notes.Select(x =>
                    new NoteResponseDTO()
                    {
                        Id = x.Id,
                        Details = x.Details,
                        CreatedOn = x.CreatedOn,
                        UpdatedOn = x.UpdatedOn,
                    }).ToList();

                response.Data = noteResponse;
                response.IsSuccess = true;
                response.StatusCode = 200;
                response.Message = "Notes fetched successfully.";
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = "Failed fetching notes";
            }

            return response;
        }

        public async Task<ResponseDTO<NoteResponseDTO>> GetById(Guid id)
        {
            ResponseDTO<NoteResponseDTO> response = new();

            try
            {
                var note = await noteRepository.GetAsync(id);

                if (note != null)
                {

                    var noteResponse =
                        new NoteResponseDTO()
                        {
                            Id = note.Id,
                            Details = note.Details,
                            CreatedOn = note.CreatedOn,
                            UpdatedOn = note.UpdatedOn,
                        };

                    response.Data = noteResponse;
                    response.IsSuccess = true;
                    response.StatusCode = 200;
                    response.Message = "Note fetched successfully.";
                }
                else
                {
                    response.StatusCode = 404;
                    response.Message = "Note not found.";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = "Failed fetching note.";
            }

            return response;

        }

        public ResponseDTO<bool> Add(NoteRequestDTO note)
        {
            ResponseDTO<bool> response = new();

            try
            {
                if (note == null)
                {
                    response.StatusCode = 417;
                    response.Message = "Note data is missing.";

                    return response;
                }

                if (string.IsNullOrEmpty(note.Details))
                {
                    response.StatusCode = 417;
                    response.Message = "Please add note details.";

                    return response;
                }

                var noteEntity = new Core.Entity.Note()
                {
                    Id = Guid.NewGuid(),
                    Details = note.Details,
                    CreatedOn = DateTime.Now
                };

                bool noteAdded = noteRepository.Add(noteEntity);

                if (noteAdded)
                {
                    response.StatusCode = 200;
                    response.Data = noteAdded;
                    response.IsSuccess = true;
                    response.Message = "Note addedd successfully.";
                }
                else
                {
                    response.StatusCode = 503;
                    response.Message = "Note was not added. Please try again.";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = "Failed adding note.";
            }

            return response;
        }

        public ResponseDTO<bool> Update(NoteRequestDTO note)
        {
            ResponseDTO<bool> response = new();

            try
            {
                if (note == null)
                {
                    response.StatusCode = 417;
                    response.Message = "Note data is missing.";

                    return response;
                }

                if (string.IsNullOrEmpty(note.Details))
                {
                    response.StatusCode = 417;
                    response.Message = "Please add note details.";

                    return response;
                }

                var noteToUpdate = noteRepository.Get(note.Id);

                if (noteToUpdate == null)
                {
                    response.StatusCode = 404;
                    response.Message = "Note not found with the Id.";

                    return response;
                }

                noteToUpdate.Details = note.Details;
                noteToUpdate.UpdatedOn = DateTime.Now;

                bool noteUpdated = noteRepository.Update(noteToUpdate);

                if (noteUpdated)
                {
                    response.StatusCode = 200;
                    response.Data = noteUpdated;
                    response.IsSuccess = true;
                    response.Message = "Note updated successfully.";
                }
                else
                {
                    response.StatusCode = 503;
                    response.Message = "Note was not updated. Please try again.";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = "Failed updating note.";
            }

            return response;
        }

        public ResponseDTO<bool> Delete(Guid id)
        {
            ResponseDTO<bool> response = new();

            try
            {
                var noteToDelete = noteRepository.Get(id);

                if (noteToDelete == null)
                {
                    response.StatusCode = 404;
                    response.Message = "Note not found with the Id.";

                    return response;
                }

                bool noteDeleted = noteRepository.Delete(noteToDelete);

                if (noteDeleted)
                {
                    response.StatusCode = 200;
                    response.Data = noteDeleted;
                    response.IsSuccess = true;
                    response.Message = "Note deleted successfully.";
                }
                else
                {
                    response.StatusCode = 503;
                    response.Message = "Note was not deleted. Please try again.";
                }
            }
            catch (Exception ex)
            {
                response.StatusCode = 500;
                response.Message = "Failed deleting note.";
            }

            return response;
        }
    }
}
