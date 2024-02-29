using Gnostice.Core.Viewer;
using StudyDesk.Controller;
using StudyDesk.Model;
using StudyDesk.View.SourceControls;

namespace StudyDesk.View
{
    /// <summary>
    /// Form for displaying a source.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class SourceForm : Form
    {
        private readonly SourceFormController controller;
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceForm"/> class.
        /// </summary>
        /// <param name="source">The source to display.</param>
        public SourceForm(Source source)
        {
            this.InitializeComponent();
            this.controller = new SourceFormController(source);
            StartPosition = FormStartPosition.CenterScreen;
            this.LoadNotes();
            this.LoadSource(source);
            this.documentControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.notesFlowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void LoadNotes()
        {
            this.notesFlowLayoutPanel.Controls.Clear();
            this.controller.RefreshNotes();

            var addNoteControl = new AddNoteControl();
            addNoteControl.BorderStyle = BorderStyle.Fixed3D;
            this.setupAddnoteControlButtons(addNoteControl);
            this.notesFlowLayoutPanel.Controls.Add(addNoteControl);

            var index = 1;
            foreach (var note in this.controller.Notes)
            {
                var noteControl = new NoteControl(index);
                noteControl.BorderStyle = BorderStyle.Fixed3D;
                noteControl.setNoteText(note.Text);
                this.setupNoteControlButtons(noteControl);
                this.notesFlowLayoutPanel.Controls.Add(noteControl);
                index++;
            }
        }

        private void LoadSource(Source source)
        {
            _ = this.documentControl1.SetDocument(source.Link).Result;
        }

        private void setupNoteControlButtons(NoteControl noteControl)
        {
            noteControl.DeleteTagButtonClicked += NoteControl_DeleteTagButtonClicked;
            noteControl.AddTagButtonClicked += NoteControl_AddTagButtonClicked;
            noteControl.DeleteNoteButtonClicked += NoteControl_DeleteNoteButtonClicked;
            noteControl.SaveNotesChangesButtonClick += NoteControl_SaveChangesButtonClicked;
        }

        private void setupAddnoteControlButtons(AddNoteControl addNoteControl)
        {
            addNoteControl.AddNoteButtonClicked += AddNoteControl_AddNoteButtonClicked;
        }

        private void AddNoteControl_AddNoteButtonClicked(object sender, NoteControl.NoteEventArgs e)
        {
            this.controller.AddNote(e.NoteText);

            if (e.Tags is { Count: > 0 })
            {
                MessageBox.Show("Note with tags");
            }

            this.LoadNotes();
        }

        private void NoteControl_DeleteNoteButtonClicked(object sender, NoteControl.NoteEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this note?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (this.controller.DeleteNoteAt(e.NoteIndex - 1))
                {
                    this.notesFlowLayoutPanel.Controls.RemoveAt(e.NoteIndex);
                }
            }
        }

        private void NoteControl_DeleteTagButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("Delete tag");
        }

        private void NoteControl_AddTagButtonClicked(object sender, EventArgs e)
        {
            MessageBox.Show("add tag");
        }

        private void NoteControl_SaveChangesButtonClicked(object sender, NoteControl.NoteEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to save the changes to this note?", "Confirm Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (this.controller.EditNote(e.NoteIndex - 1, e.NoteText))
                {
                    this.notesFlowLayoutPanel.Refresh();
                }
            }
        }

        // private void handleType(SourceType type)
        // {
        //     switch (type)
        //     {
        //         case SourceType.Video:
        //         case SourceType.VideoLink:
        //             this.addVideoControl();
        //             break;
        //         case SourceType.Pdf:
        //         case SourceType.PdfLink:
        //             this.addDocumentControl();
        //             break;
        //         case SourceType.Image:
        //             this.addImageControl();
        //             break;
        //         default:
        //             throw new ArgumentOutOfRangeException(nameof(type), type, null);
        //     }
        // }

        // private void addVideoControl()
        // {
        //     var videoControl = new VideoControl();
        //     this.splitContainer1.Panel2.Controls.Add(videoControl);
        // }
        //
        // private void addDocumentControl()
        // {
        //     var documentControl = new DocumentControl();
        //     this.splitContainer1.Panel2.Controls.Add(documentControl);
        // }
        // private void addImageControl()
        // {
        //     var imageControl = new ImageControl();
        //     this.splitContainer1.Panel2.Controls.Add(imageControl);
        // }





        /*private void noteGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var noteIndex = e.RowIndex;
            if (noteIndex < 0)
            {
                return;
            }
            if (this.noteGridView.Rows[noteIndex].Cells[0].Value is null)
            {
                if (this.controller.DeleteNoteAt(noteIndex))
                {
                    this.noteGridView.Rows.RemoveAt(noteIndex);
                    return;
                }
            }
            var noteText = this.noteGridView.Rows[noteIndex].Cells[0].Value.ToString();
            if (noteIndex < this.controller.Notes.Count)
            {
                _ = this.controller.EditNote(noteIndex, noteText!);
            }
            else
            {
                if (!this.controller.AddNote(noteText!))
                {
                    this.noteGridView.Rows.RemoveAt(noteIndex);
                }
            }
            this.LoadNotes();
        }*/
    }
}
