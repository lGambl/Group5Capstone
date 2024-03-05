using StudyDesk.Model;

namespace StudyDesk.Controller
{
    /// <summary>
    /// Interface for the Source Form Controller to interact with the database.
    /// </summary>
    public interface INotesRepository
    {
        /// <summary>
        /// Gets the notes.
        /// </summary>
        /// <returns>A list representing the notes attached to a source.</returns>
        public IList<Note> GetNotes();

        /// <summary>
        /// Adds the note to database.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool AddNoteToDatabase(Note note);

        /// <summary>
        /// Updates the note in database.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool UpdateNoteInDatabase(Note note);

        /// <summary>
        /// Deletes the note from database.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <returns>True if successful, false otherwise</returns>
        public bool DeleteNoteFromDatabase(Note note);

        public bool AddTagToDatabase(NoteTag noteTag);

        public bool DeleteTagFromDatabase(NoteTag noteTag);
    }
}
