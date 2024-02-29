using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyDesk.View.SourceControls
{
    public partial class NoteControl : UserControl
    {
        public int NoteIndex;

        public delegate void NoteEventHandler(object sender, NoteEventArgs e);

        public event NoteEventHandler DeleteNoteButtonClicked;

        public event EventHandler DeleteTagButtonClicked;

        public event EventHandler AddTagButtonClicked;

        public event NoteEventHandler SaveNotesChangesButtonClick;

        public NoteControl(int index)
        {
            this.NoteIndex = index;
            InitializeComponent();
            this.initializeButtons();
        }

        private void initializeButtons()
        {
            this.deleteNoteButton.Click += (sender, e) => OnDeleteNoteButtonClicked();
            this.deleteTagButton.Click += (sender, e) => OnDeleteTagButtonClicked();
            this.addTagButton.Click += (sender, e) => OnAddTagButtonClicked();
            this.saveChangesButton.Click += (sender, e) => OnSaveChangesButtonClick();
        }

        public void setNoteText(string noteText)
        {
            this.noteTextBox.Text = noteText;
        }

        protected virtual void OnDeleteNoteButtonClicked()
        {
            DeleteNoteButtonClicked?.Invoke(this, new NoteEventArgs(this.NoteIndex));
        }

        protected virtual void OnDeleteTagButtonClicked()
        {
            DeleteTagButtonClicked?.Invoke(this, new NoteEventArgs(this.NoteIndex));
        }

        protected virtual void OnAddTagButtonClicked()
        {
            AddTagButtonClicked?.Invoke(this, new NoteEventArgs(this.NoteIndex));
        }

        protected virtual void OnSaveChangesButtonClick()
        {
            SaveNotesChangesButtonClick?.Invoke(this, new NoteEventArgs(this.NoteIndex, this.noteTextBox.Text));
        }

        public class NoteEventArgs : EventArgs
        {
            public int NoteIndex { get; }

            public string NoteText { get; }

            public List<string> Tags { get; }

            public NoteEventArgs(int noteIndex)
            {
                NoteIndex = noteIndex;
            }

            public NoteEventArgs(int noteIndex, string noteText)
            {
                NoteIndex = noteIndex;
                NoteText = noteText;
            }

            public NoteEventArgs(string noteText)
            {
                NoteText = noteText;
            }

            public NoteEventArgs(string noteText, List<string> tags)
            {
                NoteText = noteText;
                Tags = tags;

            }
        }
    }
}
