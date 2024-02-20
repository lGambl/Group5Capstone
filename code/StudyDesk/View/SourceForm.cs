using StudyDesk.Controller;
using StudyDesk.Model;

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
            this.noteGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        }

        private void loadNotes()
        {
            this.noteGridView.Rows.Clear();
            this.controller.RefreshNotes();
            foreach (var note in this.controller.Notes)
            {
                this.noteGridView.Rows.Add(note.Text);
            }
        }

        private void  loadSource(Source source)
        {
            _=this.documentControl1.SetDocument(source.Link).Result;
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

        private void noteGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
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
            this.loadNotes();
        }
    }
}
