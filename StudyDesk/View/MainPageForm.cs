using StudyDesk.Controller;

namespace StudyDesk.View
{
    /// <summary>
    /// The main page form.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainPageForm : Form
    {
        private const string? NotImplementedYet = "Not implemented yet.";
        private MainPageController controller;
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageForm"/> class.
        /// </summary>
        /// <param name="userId">The id of the logged-in user.</param>
        public MainPageForm(string userId)
        {
            this.InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.controller = new MainPageController(userId);
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(NotImplementedYet);
        }

        private void indexListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.indexListView.SelectedItems.Count > 0)
            {
                this.deleteButton.Enabled = true;
            }
            else
            {
                this.deleteButton.Enabled = false;
            }

        }

        private void indexListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var sourceForm = new SourceForm();
            sourceForm.ShowDialog();
        }
    }
}
