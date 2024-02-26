using StudyDesk.Controller;
using StudyDesk.Model;

namespace StudyDesk.View;

/// <summary>
///     Form for adding a source.
///     Designed to be used as a dialog.
/// </summary>
/// <seealso cref="System.Windows.Forms.Form" />
public partial class AddSourceForm : Form
{
    #region Data members

    private const string FileExtensionFilters = "PDF Files (*.pdf)|*.pdf";
    private const string FileDialogTitle = "Select a file";
    private const string? PleaseEnterATitleForTheSource = "Please enter a title for the source.";
    private const string? PleaseUploadAFile = "Please upload a file.";
    private const string? PleaseFillInAllFields = "Please fill in all fields.";
    private const string? FailedToAddSource = "Failed to add source.";
    private const string? InvalidSourceType = "Invalid Source Type";
    private const string? PleaseSelectASourceType = "Please select a source type.";

    private AddSourceController controller;

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="AddSourceForm" /> class.
    /// </summary>
    public AddSourceForm(AuthService authService)
    {
        this.InitializeComponent();
        this.CenterToScreen();
        this.controller = new AddSourceController(authService);
        this.populateSourceTypeBox();
    }

    #endregion

    #region Methods

    private void populateSourceTypeBox()
    {
        this.sourceTypeComboBox.Items.Add("Pdf");
    }
    private void uploadButton_Click(object sender, EventArgs e)
    {
        var openFileDialog = new OpenFileDialog
        {
            AddExtension = true,
            CheckFileExists = true,
            CheckPathExists = true,
            Multiselect = false,
            Title = FileDialogTitle
        };

        switch (this.sourceTypeComboBox.SelectedItem)
        {
            case "Pdf":
                openFileDialog.Filter = FileExtensionFilters;
                break;
            default:
                MessageBox.Show(PleaseSelectASourceType, InvalidSourceType);
                return;
        }


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
            if (this.controller.AddSource(this.titleTextBox.Text, this.filePathTextBox.Text))
            {
                Close(); 
            }
            else
            {
                MessageBox.Show(FailedToAddSource);
                return;
            }
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

    #endregion
}