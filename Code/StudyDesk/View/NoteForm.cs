using StudyDesk.Controller;
using StudyDesk.Model;

namespace StudyDesk.View
{
    /// <summary>
    ///   The form for viewing a note.
    /// </summary>
    public partial class NoteForm : Form
    {
        private readonly SourceFormController controller;
        private readonly Note note;
        private readonly int noteIndex;
        private readonly SourceForm sourceForm;

        /// <summary>
        ///   Initializes a new instance of the <see cref="NoteForm" /> class.
        /// </summary>
        /// <param name="note">The note.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="index">The index.</param>
        public NoteForm(Note note, SourceFormController controller, int index, SourceForm sourceForm)
        {
            InitializeComponent();
            this.note = note;
            this.controller = controller;
            this.noteIndex = index;
            this.sourceForm = sourceForm;
            this.displayNoteDetails(note);
        }

        private void displayNoteDetails(Note note)
        {
            this.noteTextBox.Text = note.Text;
            this.loadNoteTags(note);
        }

        private void loadNoteTags(Note note)
        {
            tagsListView.Items.Clear();
            foreach (var currTag in note.NoteTags)
            {
                this.tagsListView.Items.Add(currTag);
            }
        }

        private void deleteNoteButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this note?", "Confirm Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.controller.DeleteNoteAt(this.noteIndex);
                this.Close();
                this.sourceForm.LoadNotes();
            }
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to save the changes to this note?", "Confirm Changes",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.controller.EditNote(this.noteIndex, this.noteTextBox.Text);
                this.sourceForm.LoadNotes();
            }
        }

        private void addTagButton_Click(object sender, EventArgs e)
        {
            using (AddTagForm addTagForm = new AddTagForm())
            {
                var dialogResult = addTagForm.ShowDialog();
                if (dialogResult == DialogResult.OK)
                {
                    string newTag = "<" + addTagForm.EnteredTagName + ">";
                    var duplicateTag = false;
                    foreach (ListViewItem currItem in this.tagsListView.Items)
                    {
                        var itemString = currItem.Text;
                        if (itemString == newTag)
                        {
                            duplicateTag = true;
                        }
                    }
                    if (!duplicateTag)
                    {
                        this.tagsListView.Items.Add(new ListViewItem(newTag));
                        this.controller.AddTagToExistingNote(this.noteIndex + 1, newTag);
                    }
                    else
                    {
                        MessageBox.Show("The tag you entered has already been added to this note.", "Duplicate Tag", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }

        private void deleteTagButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this tag?", "Confirm Deletion",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.controller.DeleteNoteTag(this.noteIndex, this.tagsListView.SelectedItems[0].Text);
                this.loadNoteTags(this.note);
            }
        }
    }
}
