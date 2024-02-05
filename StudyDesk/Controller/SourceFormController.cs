using StudyDesk.Model;

namespace StudyDesk.Controller;

/// <summary>
///     Controller for the Source Form. Pushes changes from the form to the database
///     and vice versa.
/// </summary>
public class SourceFormController
{
    #region Data members

    private readonly Source source;

    #endregion

    #region Properties

    /// <summary>
    ///     Gets or sets the notes.
    /// </summary>
    /// <value>
    ///     The notes.
    /// </value>
    public IList<Note> Notes { get; private set; }

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="SourceFormController" /> class.
    /// </summary>
    /// <param name="source">The source.</param>
    public SourceFormController(Source source)
    {
        this.source = source;
        this.Notes = new List<Note>();
        this.loadNotes();
    }

    #endregion

    #region Methods

    /// <summary>
    ///     Adds a note to the source.
    /// </summary>
    /// <param name="noteText">The note text.</param>
    /// <returns>True if successfully added, false otherwise.</returns>
    public bool AddNote(string noteText)
    {
        var note = new Note(0, noteText, this.source.Id, "TBD");
        if (this.addNoteToDb(note))
        {
            this.Notes.Add(note);
            return true;
        }

        return false;
    }

    /// <summary>
    /// Edits the note at a given index.
    /// </summary>
    /// <param name="noteIndex">Index of the note.</param>
    /// <param name="noteText">The new text to add.</param>
    /// <returns>True if successfully edited, false otherwise.</returns>
    public bool EditNote(int noteIndex, string noteText)
    {
        var note = this.Notes[noteIndex];
        var newNote = new Note(note.Id, noteText, note.SourceId, note.Owner);
        if (this.updateNoteInDb(newNote))
        {
            this.Notes[noteIndex] = newNote;
            return true;
        }
        return false;
    }

    /// <summary>
    /// Deletes the note at a given index.
    /// </summary>
    /// <param name="noteIndex">Index of the note.</param>
    /// <returns>True if successfully removed, false otherwise.</returns>
    public bool DeleteNoteAt(int noteIndex)
    {
        var note = this.Notes[noteIndex];
        if (this.deleteNoteFromDb(note))
        {
            this.Notes.RemoveAt(noteIndex);
            return true;
        }

        return false;
    }

    private bool deleteNoteFromDb(Note note)
    {
        throw new NotImplementedException();
    }

    private bool updateNoteInDb(Note note)
    {
        throw new NotImplementedException();
    }

    private bool addNoteToDb(Note note)
    {
        throw new NotImplementedException();
    }

    private void loadNotes()
    {
        throw new NotImplementedException();
    }

    #endregion
}