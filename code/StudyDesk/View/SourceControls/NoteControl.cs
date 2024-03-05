namespace StudyDesk.View.SourceControls
{
    /// <summary>
    ///   The Note Control class.
    /// </summary>
    public partial class NoteControl : UserControl
    {
        /// <summary>
        ///   Gets the index of the note.
        /// </summary>
        /// <value>The index of the note.</value>
        public int NoteIndex { get; }

        /// <summary>
        ///   The NoteEventHandler delegate
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NoteEventArgs" /> instance containing the event data.</param>
        public delegate void NoteEventHandler(object sender, NoteEventArgs e);

        /// <summary>
        ///   Occurs when [delete note button clicked].
        /// </summary>
        public event NoteEventHandler DeleteNoteButtonClicked;

        /// <summary>
        ///   Occurs when [delete tag button clicked].
        /// </summary>
        public event EventHandler DeleteTagButtonClicked;

        /// <summary>
        ///   Occurs when [add tag button clicked].
        /// </summary>
        public event EventHandler AddTagButtonClicked;

        /// <summary>
        ///   Occurs when [save notes changes button click].
        /// </summary>
        public event NoteEventHandler SaveNotesChangesButtonClick;

        /// <summary>
        ///   Initializes a new instance of the <see cref="NoteControl" /> class.
        /// </summary>
        /// <param name="index">The index.</param>
        public NoteControl(int index)
        {
            this.NoteIndex = index;
            InitializeComponent();
            this.initializeButtons();
        }

        /// <summary>
        ///   Sets the note text.
        /// </summary>
        /// <param name="noteText">The note text.</param>
        public void setNoteText(string noteText)
        {
            this.noteTextBox.Text = noteText;
        }

        /// <summary>
        ///   Called when [delete note button clicked].
        /// </summary>
        protected virtual void OnDeleteNoteButtonClicked()
        {
            DeleteNoteButtonClicked?.Invoke(this, new NoteEventArgs(this.NoteIndex));
        }

        /// <summary>
        ///   Called when [delete tag button clicked].
        /// </summary>
        protected virtual void OnDeleteTagButtonClicked()
        {
            DeleteTagButtonClicked?.Invoke(this, new NoteEventArgs(this.NoteIndex));
        }

        /// <summary>
        ///   Called when [add tag button clicked].
        /// </summary>
        protected virtual void OnAddTagButtonClicked()
        {
            AddTagButtonClicked?.Invoke(this, new NoteEventArgs(this.NoteIndex));
        }

        /// <summary>
        ///   Called when [save changes button click].
        /// </summary>
        protected virtual void OnSaveChangesButtonClick()
        {
            SaveNotesChangesButtonClick?.Invoke(this, new NoteEventArgs(this.NoteIndex, this.noteTextBox.Text));
        }

        private void initializeButtons()
        {
            this.deleteNoteButton.Click += (sender, e) => OnDeleteNoteButtonClicked();
            this.deleteTagButton.Click += (sender, e) => OnDeleteTagButtonClicked();
            this.addTagButton.Click += (sender, e) => OnAddTagButtonClicked();
            this.saveChangesButton.Click += (sender, e) => OnSaveChangesButtonClick();
        }

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
            public string NoteText { get; }

            /// <summary>
            ///   Gets the tags.
            /// </summary>
            /// <value>The tags.</value>
            public List<string> Tags { get; }

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
        }
    }
}
