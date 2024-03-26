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
        ///   Occurs when [add tag button clicked].
        /// </summary>
        public event NoteEventHandler AddTagButtonClicked;

        /// <summary>
        ///   Occurs when [save notes changes button click].
        /// </summary>
        public event NoteEventHandler SaveNotesChangesButtonClick;

        public event NoteEventHandler DeleteTagButtonClick;

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
        ///   Sets the note tags.
        /// </summary>
        /// <param name="tags">The tags.</param>
        public void SetNoteTags(List<string> tags)
        {
            this.tagsLlistView.Items.Clear();
            foreach (var currTag in tags)
            {
                this.tagsLlistView.Items.Add(new ListViewItem(currTag));
            }
        }

        /// <summary>
        ///   Called when [delete note button clicked].
        /// </summary>
        protected virtual void OnDeleteNoteButtonClicked()
        {
            DeleteNoteButtonClicked?.Invoke(this, new NoteEventArgs(this.NoteIndex));
        }

        /// <summary>
        ///   Called when [add tag button clicked].
        /// </summary>
        protected virtual void OnAddTagButtonClicked()
        {
            using (AddTagForm addTagForm = new AddTagForm())
            {
                var dialogResult = addTagForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    string newTag = addTagForm.EnteredTagName;
                    var duplicateTag = false;
                    foreach (ListViewItem currItem in this.tagsLlistView.Items)
                    {
                        var itemString = currItem.Text;
                        if (itemString == "<" + newTag + ">")
                        {
                            duplicateTag = true;
                        }
                    }
                    if (!duplicateTag)
                    {
                        this.tagsLlistView.Items.Add(new ListViewItem("<" + newTag + ">"));
                        List<string> tags = new List<string>();
                        tags.Add("<" + newTag + ">");
                        AddTagButtonClicked?.Invoke(this, new NoteEventArgs(this.NoteIndex, tags));
                    }
                    else
                    {
                        MessageBox.Show("The tag you entered has already been added to this note.", "Duplicate Tag", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        /// <summary>
        ///   Called when [save changes button click].
        /// </summary>
        protected virtual void OnSaveChangesButtonClick()
        {
            SaveNotesChangesButtonClick?.Invoke(this, new NoteEventArgs(this.NoteIndex, this.noteTextBox.Text));
        }

        /// <summary>
        ///   Called when [delete tag button click].
        /// </summary>
        protected virtual void OnDeleteTagButtonClick()
        {
            if (this.tagsLlistView.SelectedItems.Count > 0)
            {
                DeleteTagButtonClick?.Invoke(this, new NoteEventArgs(this.NoteIndex, this.tagsLlistView.SelectedItems[0].Text));
                this.tagsLlistView.Items.Remove(this.tagsLlistView.SelectedItems[0]);
            }
            else
            {
                var result = MessageBox.Show("Please select a tag to delete.", "No Tag Selected", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void initializeButtons()
        {
            this.deleteNoteButton.Click += (sender, e) => OnDeleteNoteButtonClicked();
            this.addTagButton.Click += (sender, e) => OnAddTagButtonClicked();
            this.saveChangesButton.Click += (sender, e) => OnSaveChangesButtonClick();
            this.deleteTagButton.Click += (sender, e) => OnDeleteTagButtonClick();
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
    }
}
