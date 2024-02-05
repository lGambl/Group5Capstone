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
        /// <summary>
        /// Initializes a new instance of the <see cref="SourceForm"/> class.
        /// </summary>
        public SourceForm()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SourceForm"/> class.
        /// This constructor is currently unused.
        /// </summary>
        /// <param name="type">The type.</param>
        public SourceForm(SourceType type)
        {
            this.InitializeComponent();
            this.handleType(type);
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
            // TODO: This handler will handle changes to notes. 
        }
    }
}
