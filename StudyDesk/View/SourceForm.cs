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
            this.StartPosition = FormStartPosition.CenterScreen;
            this.loadNotes();
            // this.loadSource(source);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceForm"/> class.
        /// This constructor is currently unused.
        /// </summary>
        /// <param name="source">The source to display.</param>
        // public SourceForm(Source source)
        // {
        //     this.InitializeComponent();
        //     this.handleType(source.Type);
        //     this.controller = new SourceFormController(source);
        // }

        private void loadNotes()
        {
            this.noteGridView.Rows.Clear();
            foreach (var note in this.controller.Notes)
            {
                this.noteGridView.Rows.Add(note.Text);
            }
        }

        private void loadSource(Source source)
        {
            this.documentControl1.SetDocument(source.Link);
        }

        private void handleType(SourceType type)
        {
            switch (type)
            {
                case SourceType.Video:
                case SourceType.VideoLink:
                    this.addVideoControl();
                    break;
                case SourceType.Pdf:
                case SourceType.PdfLink:
                    this.addDocumentControl();
                    break;
                case SourceType.Image:
                    this.addImageControl();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }

        private void addVideoControl()
        {
            var videoControl = new VideoControl();
            this.splitContainer1.Panel2.Controls.Add(videoControl);
        }

        private void addDocumentControl()
        {
            var documentControl = new DocumentControl();
            this.splitContainer1.Panel2.Controls.Add(documentControl);
        }
        private void addImageControl()
        {
            var imageControl = new ImageControl();
            this.splitContainer1.Panel2.Controls.Add(imageControl);
        }

        private void noteGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var noteIndex = e.RowIndex;
            if (noteIndex < 0)
            {
                return;
            }
            if (this.noteGridView.Rows[noteIndex].Cells[0] is null)
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
                this.controller.AddNote(noteText!);
            }
            
        }
    }
}
