using static StudyDesk.View.SourceControls.NoteControl;

namespace StudyDesk.View.SourceControls
{
    /// <summary>
    ///   The Add Note Control class.
    /// </summary>
    public partial class AddNoteControl : UserControl
    {
        /// <summary>
        ///   The Note Event Handler delegate.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="NoteEventArgs" /> instance containing the event data.</param>
        public delegate void NoteEventHandler(object sender, NoteEventArgs e);

        /// <summary>
        ///   Occurs when [add note button clicked].
        /// </summary>
        public event NoteEventHandler AddNoteButtonClicked;

        /// <summary>
        ///   Initializes a new instance of the <see cref="AddNoteControl" /> class.
        /// </summary>
        public AddNoteControl()
        {
            InitializeComponent();
            this.initializeButtons();
        }

        protected virtual void OnAddNoteButtonClicked()
        {
            if (this.tagsListView.Items.Count == 0)
            {
                AddNoteButtonClicked?.Invoke(this, new NoteEventArgs(this.noteTextBox.Text));
            }
            else
            {
                List<string> tags = this.tagsListView.Items.Cast<string>().ToList();
                AddNoteButtonClicked?.Invoke(this, new NoteEventArgs(this.noteTextBox.Text, tags));
            }
        }

        protected virtual void OnAddTagButtonClicked()
        {
            this.tagsListView.Items.Add("<" + this.tagTextBox.Text + ">");
            this.tagTextBox.Text = string.Empty;
        }

        private void initializeButtons()
        {
            this.addNoteButton.Click += (sender, e) => OnAddNoteButtonClicked();
            this.addTagButton.Click += (sender, e) => OnAddTagButtonClicked();
        }

        private void noteTextBox_Enter(object sender, EventArgs e)
        {
            if (this.noteTextBox.Text == "Enter your note here...")
            {
                this.noteTextBox.Text = string.Empty;
            }
        }

        private void tagTextBox_Enter(object sender, EventArgs e)
        {
            if (this.tagTextBox.Text == "Enter your tag here...")
            {
                this.tagTextBox.Text = string.Empty;
            }
        }

        private void noteTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.noteTextBox.Text))
            {
                this.noteTextBox.Text = "Enter your note here...";
            }
        }

        private void tagTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tagTextBox.Text))
            {
                this.tagTextBox.Text = "Enter your tag here...";
            }
        }
    }
}
