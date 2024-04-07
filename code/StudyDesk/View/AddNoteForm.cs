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

namespace StudyDesk.View
{
    public partial class AddNoteForm : Form
    {
        private SourceFormController controller;

        public AddNoteForm(SourceFormController controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void addNoteButton_Click(object sender, EventArgs e)
        {
            if (this.tagsListView.Items.Count == 0)
            {
                this.controller.AddNote(this.noteTextBox.Text);
            }
            else
            {
                List<string> tags = this.tagsListView.Items.Cast<ListViewItem>().Select(item => item.Text).ToList();
                this.controller.AddNoteWithTags(this.noteTextBox.Text, tags);
            }
            //TODO: Refresh the notes in the SourceExplorer window.
            this.Close();
        }

        private void addTagButton_Click(object sender, EventArgs e)
        {
            this.tagsListView.Items.Add("<" + this.tagTextBox.Text + ">");
            this.tagTextBox.Text = string.Empty;
        }

        private void noteTextBox_Enter(object sender, EventArgs e)
        {
            if (this.noteTextBox.Text == "Enter your note here...")
            {
                this.noteTextBox.Text = string.Empty;
                this.noteTextBox.ForeColor = Color.Black;
            }
        }

        private void tagTextBox_Enter(object sender, EventArgs e)
        {
            if (this.tagTextBox.Text == "Enter your tag here...")
            {
                this.tagTextBox.Text = string.Empty;
                this.tagTextBox.ForeColor = Color.Black;
            }
        }

        private void noteTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.noteTextBox.Text))
            {
                this.noteTextBox.Text = "Enter your note here...";
                this.noteTextBox.ForeColor = Color.Gray;
            }
        }

        private void tagTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tagTextBox.Text))
            {
                this.tagTextBox.Text = "Enter your tag here...";
                this.tagTextBox.ForeColor = Color.Gray;
            }
        }
    }
}
