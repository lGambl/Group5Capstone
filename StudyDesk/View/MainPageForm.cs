﻿using StudyDesk.Controller;
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
            var sourceForm = new SourceForm();
            sourceForm.ShowDialog();
        }
    }
}
