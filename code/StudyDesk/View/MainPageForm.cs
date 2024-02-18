using StudyDesk.Controller;
using StudyDesk.Model;

namespace StudyDesk.View
{
    /// <summary>
    /// The main page form.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class MainPageForm : Form
    {
        private const string? NotImplementedYet = "Not implemented yet.";
        private const string? LogoutFailed = "Logout failed";
        private readonly MainPageController controller;
        /// <summary>
        /// Initializes a new instance of the <see cref="MainPageForm"/> class.
        /// </summary>
        public MainPageForm(AuthService auth)
        {
            this.InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            this.controller = new MainPageController(auth);
            this.loadSources();
        }

        private void loadSources()
        {

            this.indexListView.Items.Clear();
            foreach (var source in this.controller.Sources)
            {
                var item = new ListViewItem(source.Title);
                this.indexListView.Items.Add(item);
            }
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
            var source = this.controller.Sources[this.indexListView.SelectedIndices[0]];
            var sourceForm = new SourceForm(source);
            sourceForm.ShowDialog();
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            if (this.controller.Logout())
            {
                var loginForm = new LoginForm();
                loginForm.Show();
                loginForm.Closed += (_, _) => Close();
                Hide();
            }

            else
            {
                MessageBox.Show(LogoutFailed, LogoutFailed, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (this.controller.DeleteSource(this.indexListView.SelectedItems[0].ToString()).Result)
            {
                this.indexListView.SelectedItems[0].Remove();
            }
        }
    }
}