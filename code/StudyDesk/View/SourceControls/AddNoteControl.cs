using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static StudyDesk.View.SourceControls.NoteControl;

namespace StudyDesk.View.SourceControls
{
    public partial class AddNoteControl : UserControl
    {
        public delegate void NoteEventHandler(object sender, NoteEventArgs e);

        public event NoteEventHandler AddNoteButtonClicked;

        public AddNoteControl()
        {
            InitializeComponent();
            this.initializeButtons();
        }

        private void initializeButtons()
        {
            this.addNoteButton.Click += (sender, e) => OnAddNoteButtonClicked();
            this.addTagButton.Click += (sender, e) => OnAddTagButtonClicked();
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
    }
}
