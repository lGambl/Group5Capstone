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
            this.loadNotes();
            this.loadSource(source);
            this.documentControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            this.notesFlowLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void loadNotes()
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
                noteControl.SetNoteTags(note.NoteTags);
                this.setupNoteControlButtons(noteControl);
                this.notesFlowLayoutPanel.Controls.Add(noteControl);
                index++;
            }
        }

        private void loadSource(Source source)
        {
            this.videoControl1.Visible = false;
            this.documentControl1.Visible = false;

            switch (source.Type)
            {
                case SourceType.VideoLink:
                    _ = this.videoControl1.SetVideo(source.Link);
                    this.videoControl1.Visible = true;
                    break;
                case SourceType.PdfLink:
                case SourceType.Pdf:
                    _ = this.documentControl1.SetDocument(source.Link).Result;
                    this.documentControl1.Visible = true;
                    break;
                case SourceType.Image:
                case SourceType.Video:
                default:
                    MessageBox.Show("This source type is not supported", "Unsupported Source Type", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Close();
                    break;
            }
        }

        private void setupNoteControlButtons(NoteControl noteControl)
        {
            noteControl.AddTagButtonClicked += NoteControl_AddTagButtonClicked;
            noteControl.DeleteNoteButtonClicked += NoteControl_DeleteNoteButtonClicked;
            noteControl.SaveNotesChangesButtonClick += NoteControl_SaveChangesButtonClicked;
            noteControl.DeleteTagButtonClick += NoteControl_DeleteTagButtonClicked;
        }

        private void setupAddnoteControlButtons(AddNoteControl addNoteControl)
        {
            addNoteControl.AddNoteButtonClicked += AddNoteControl_AddNoteButtonClicked;
        }

        private void AddNoteControl_AddNoteButtonClicked(object sender, NoteControl.NoteEventArgs e)
        {
            if (e.Tags is { Count: > 0 })
            {
                this.controller.AddNoteWithTags(e.NoteText, e.Tags);
            }
            else
            {
                this.controller.AddNote(e.NoteText);
            }

            this.loadNotes();
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

        private void NoteControl_AddTagButtonClicked(object sender, NoteControl.NoteEventArgs e)
        {
            this.controller.AddTagToExistingNote(e.NoteIndex, e.Tags[0]);
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

        private void NoteControl_DeleteTagButtonClicked(object sender, NoteControl.NoteEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to delete this tag?", "Confirm Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.controller.DeleteNoteTag((e.NoteIndex - 1), e.NoteText);
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

    }
}
