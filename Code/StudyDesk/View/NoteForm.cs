using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using StudyDesk.Controller;
using StudyDesk.Model;

namespace StudyDesk.View
{
    public partial class NoteForm : Form
    {
        private SourceFormController controller;
        private int noteIndex;

        public NoteForm(Note note, SourceFormController controller, int index)
        {
            InitializeComponent();
            this.controller = controller;
            this.noteIndex = index;
            this.displayNoteDetails(note);
        }

        private void displayNoteDetails(Note note)
        {
            this.noteTextBox.Text = note.Text;
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
                //TODO: update notes in source explorer
            }
        }

        private void saveChangesButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to save the changes to this note?", "Confirm Changes",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.controller.EditNote(this.noteIndex, this.noteTextBox.Text);
                //TODO: update notes in source explorer
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
                //TODO: update notes in source explorer
            }
        }
    }
}
