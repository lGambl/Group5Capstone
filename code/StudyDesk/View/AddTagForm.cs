namespace StudyDesk.View
{
    /// <summary>
    ///   The Add Tag Form class.
    /// </summary>
    public partial class AddTagForm : Form
    {
        /// <summary>
        ///   Gets the name of the entered tag.
        /// </summary>
        /// <value>The name of the entered tag.</value>
        public string EnteredTagName
        {
            get { return tagTextBox.Text; }
        }

        /// <summary>
        ///   Initializes a new instance of the <see cref="AddTagForm" /> class.
        /// </summary>
        public AddTagForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void addTagButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.tagTextBox.Text))
            {
                MessageBox.Show("Please enter a tag name.", "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
