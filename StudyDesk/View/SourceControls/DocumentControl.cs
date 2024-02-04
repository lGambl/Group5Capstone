namespace StudyDesk.View.SourceControls
{
    /// <summary>
    /// UserControl for displaying a document.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.UserControl" />
    public partial class DocumentControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DocumentControl"/> class.
        /// </summary>
        public DocumentControl()
        {
            this.InitializeComponent();
            this.documentViewer1.PerformAutoScale();
        }

        /// <summary>
        /// Sets the document.
        /// </summary>
        /// <param name="filename">The filename.</param>
        public void SetDocument(string filename)
        {
            this.documentViewer1.LoadDocument(filename);
        }
    }
}
