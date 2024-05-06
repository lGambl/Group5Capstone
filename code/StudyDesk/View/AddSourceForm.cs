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
    private const string? PleaseEnterTheLinkInTheFilePathBox = "Please enter the link in the file path box.";

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
        this.sourceTypeComboBox.SelectedIndexChanged += this.SourceType_SelectionChanged;
    }

    #endregion

    #region Methods

    private void populateSourceTypeBox()
    {
        this.sourceTypeComboBox.Items.Add("Pdf");
        this.sourceTypeComboBox.Items.Add("Video Link");
    }
    private void uploadButton_Click(object sender, EventArgs e)
    {
        switch (this.sourceTypeComboBox.SelectedItem)
        {
            case "Pdf":
                this.fileUpload(SourceType.Pdf);
                break;
            case "Video Link":
                this.setupLinkHandling();
                return;
            default:
                MessageBox.Show(PleaseSelectASourceType, InvalidSourceType);
                return;
        }

    }

    private void setupLinkHandling()
    {
        this.filePathTextBox.Text = "";
        this.filePathTextBox.Enabled = true;

        MessageBox.Show(PleaseEnterTheLinkInTheFilePathBox);
    }

    private void fileUpload(SourceType type)
    {
        var openFileDialog = new OpenFileDialog
        {
            Filter = FileExtensionFilters,
            CheckFileExists = true,
            CheckPathExists = true,
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
            var type = this.sourceTypeComboBox.SelectedItem switch
            {
                "Pdf" => SourceType.Pdf,
                "Video Link" => SourceType.VideoLink,
                _ => throw new NotImplementedException()
            };
            if (this.controller.AddSource(this.titleTextBox.Text, this.filePathTextBox.Text, type))
            {
                Close(); 
            }
        }
    }

    private bool checkFields()
    {
        if (this.titleTextBox.Text == "" && this.filePathTextBox.Text == "")
        {
            MessageBox.Show(PleaseFillInAllFields);
            return false;
        }
        
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

    private void SourceType_SelectionChanged(object? sender, EventArgs e)
    {
        var selectedItem = this.sourceTypeComboBox.SelectedItem;
        if (selectedItem != null && selectedItem.Equals("Pdf"))
        {
            this.filePathTextBox.Enabled = false;
        }
        else
        {
            this.filePathTextBox.Enabled = true;
        }
        this.filePathTextBox.Text = "";
    }

    #endregion
}