/// <summary>
///   The Note Event Args class
/// </summary>
public class NoteEventArgs : EventArgs
{
    /// <summary>
    ///   Gets the index of the note.
    /// </summary>
    /// <value>The index of the note.</value>
    public int NoteIndex { get; }

    /// <summary>
    ///   Gets the note text.
    /// </summary>
    /// <value>The note text.</value>
    public string? NoteText { get; }

    /// <summary>
    ///   Gets the tags.
    /// </summary>
    /// <value>The tags.</value>
    public List<string>? Tags { get; }

    /// <summary>
    ///   Initializes a new instance of the <see cref="NoteEventArgs" /> class.
    /// </summary>
    /// <param name="noteIndex">Index of the note.</param>
    public NoteEventArgs(int noteIndex)
    {
        NoteIndex = noteIndex;
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="NoteEventArgs" /> class.
    /// </summary>
    /// <param name="noteIndex">Index of the note.</param>
    /// <param name="noteText">The note text.</param>
    public NoteEventArgs(int noteIndex, string noteText)
    {
        NoteIndex = noteIndex;
        NoteText = noteText;
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="NoteEventArgs" /> class.
    /// </summary>
    /// <param name="noteText">The note text.</param>
    public NoteEventArgs(string noteText)
    {
        NoteText = noteText;
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="NoteEventArgs" /> class.
    /// </summary>
    /// <param name="noteText">The note text.</param>
    /// <param name="tags">The tags.</param>
    public NoteEventArgs(string noteText, List<string> tags)
    {
        NoteText = noteText;
        Tags = tags;
    }

    /// <summary>
    ///   Initializes a new instance of the <see cref="NoteEventArgs" /> class.
    /// </summary>
    /// <param name="noteIndex">Index of the note.</param>
    /// <param name="tags">The tags.</param>
    public NoteEventArgs(int noteIndex, List<string> tags)
    {
        NoteIndex = noteIndex;
        Tags = tags;
    }
}
