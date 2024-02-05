using Microsoft.Data.SqlClient;
using StudyDesk.Model;

namespace StudyDesk.Controller;

/// <summary>
///     Controller for the Source Form. Pushes changes from the form to the database
///     and vice versa.
/// </summary>
public class SourceFormController
{
    #region Data members

    private const string ConnectionString =
        "Server=(localdb)\\mssqllocaldb;Database=aspnet-BestPhonebookApp-0fc62a5a-c4b5-4292-9de7-2d743b650400;Trusted_Connection=True;MultipleActiveResultSets=true";

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
        try
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var command = new SqlCommand("DELETE FROM dbo.Note WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@id", note.Id);
            var result = command.ExecuteNonQuery();
            connection.Close();
            return true;
        }
        catch (Exception)
        {
            MessageBox.Show("Failed to delete note from database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }

    }

    private bool updateNoteInDb(Note note)
    {
        try
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var command = new SqlCommand("UPDATE dbo.Note SET Text = @text WHERE Id = @id", connection);
            command.Parameters.AddWithValue("@text", note.Text);
            command.Parameters.AddWithValue("@id", note.Id);
            var result = command.ExecuteNonQuery();
            connection.Close();
            return true;
        }
        catch (Exception)
        {
            MessageBox.Show("Failed to update note in database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    private bool addNoteToDb(Note note)
    {
        try
        {
            var connection = new SqlConnection(ConnectionString);
            connection.Open();
            var command = new SqlCommand("INSERT INTO dbo.Note (Text, SourceId, Owner) VALUES (@text, @sourceId, @owner)", connection);
            command.Parameters.AddWithValue("@text", note.Text);
            command.Parameters.AddWithValue("@sourceId", note.SourceId);
            command.Parameters.AddWithValue("@owner", note.Owner);
            var result = command.ExecuteNonQuery();
            connection.Close();
            return true;
        }
        catch (Exception)
        {
            MessageBox.Show("Failed to add note to database", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    private void loadNotes()
    {
        var notes = new List<Note>();
        var connection = new SqlConnection(ConnectionString);
        connection.Open();
        var command = new SqlCommand("SELECT * FROM dbo.Note WHERE SourceId = @sourceId", connection);
        command.Parameters.AddWithValue("@sourceId", this.source.Id);
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            var id = reader.GetInt32(0);
            var text = reader.GetString(1);
            var sourceId = reader.GetInt32(2);
            var owner = reader.GetString(3);
            notes.Add(new Note(id, text, sourceId, owner));
        }
        connection.Close();
        this.Notes = notes;
    }

    #endregion
}