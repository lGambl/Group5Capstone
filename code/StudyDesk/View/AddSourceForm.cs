using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudyDesk.View
{
    /// <summary>
    /// Form for adding a source.
    /// Designed to be used as a dialog.
    /// </summary>
    /// <seealso cref="System.Windows.Forms.Form" />
    public partial class AddSourceForm : Form
    {
        private const string FileExtensionFilters = "PDF Files (*.pdf)|*.pdf";
        private const string FileDialogTitle = "Select a PDF file";
        private const string? PleaseEnterATitleForTheSource = "Please enter a title for the source.";
        private const string? PleaseUploadAFile = "Please upload a file.";
        private const string? PleaseFillInAllFields = "Please fill in all fields.";

        private AddSourceController controller;

        public AddSourceForm()
        {
            this.InitializeComponent();
            this.controller = new AddSourceController();
        }

        private void uploadButton_Click(object sender, EventArgs e)
        {
            var openFileDialog = new OpenFileDialog
            {
                AddExtension = true,
                CheckFileExists = true,
                CheckPathExists = true,
                DefaultExt = "pdf",
                Filter = FileExtensionFilters,
                Multiselect = false,
                Title = FileDialogTitle
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                this.filePathTextBox.Text = openFileDialog.FileName;
            }

        }

        private void addSourceButton_Click(object sender, EventArgs e)
        {
            var conditionsMet = this.checkFields();
            if (conditionsMet)
            {
                this.controller.AddSource(this.titleTextBox.Text, this.filePathTextBox.Text);
                this.Close();
            }
            else
            {
                MessageBox.Show(PleaseFillInAllFields);
            }
        }

        private bool checkFields()
        {
            if (this.titleTextBox.Text == "")
            {
                MessageBox.Show(PleaseEnterATitleForTheSource);
                return false;
            }

            if (this.filePathTextBox.Text == "")
            {
                MessageBox.Show(PleaseUploadAFile);
                return false;
            }
            return true;
        }
    }
}
