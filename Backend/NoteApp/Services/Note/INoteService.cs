using NoteApp.Infrastructure.DTO.Request;
using NoteApp.Infrastructure.DTO.Response;

namespace NoteApp.Services.Note
{
    public interface INoteService
    {
        /// <summary>
        /// Fetch all notes from database
        /// </summary>
        /// <returns></returns>
        Task<ResponseDTO<IEnumerable<NoteResponseDTO>>> All();

        /// <summary>
        /// To find a note by id
        /// </summary>
        /// <param name="id">GUID</param>
        /// <returns></returns>
        Task<ResponseDTO<NoteResponseDTO>> GetById(Guid id);

        /// <summary>
        /// Add a new note
        /// </summary>
        /// <param name="note">Note object</param>
        /// <returns></returns>
        ResponseDTO<bool> Add(NoteRequestDTO note);

        /// <summary>
        /// Update Note to database
        /// </summary>
        /// <param name="note">Note object</param>
        /// <returns></returns>
        ResponseDTO<bool> Update(NoteRequestDTO note);

        /// <summary>
        /// Remove Note from database
        /// </summary>
        /// <param name="id">GUID</param>
        /// <returns></returns>
        ResponseDTO<bool> Delete(Guid id);

    }
}
