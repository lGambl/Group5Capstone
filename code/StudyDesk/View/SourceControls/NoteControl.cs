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
        public event EventHandler DeleteNoteButtonClicked;

        public event EventHandler DeleteTagButtonClicked;

        public event EventHandler AddTagButtonClicked;

        public event EventHandler SaveNotesChangesButtonClick;

        public NoteControl()
        {
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
            DeleteNoteButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDeleteTagButtonClicked()
        {
            DeleteTagButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnAddTagButtonClicked()
        {
            AddTagButtonClicked?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnSaveChangesButtonClick()
        {
            SaveNotesChangesButtonClick?.Invoke(this, EventArgs.Empty);
        }
    }
}
