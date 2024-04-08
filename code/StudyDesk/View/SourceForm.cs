using System.Runtime.CompilerServices;
using StudyDesk.Controller;
using StudyDesk.Model;

namespace StudyDesk.View;

/// <summary>
///     Form for displaying a source.
/// </summary>
/// <seealso cref="System.Windows.Forms.Form" />
public partial class SourceForm : Form
{
    #region Data members

    private readonly SourceFormController controller;

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes a new instance of the <see cref="SourceForm" /> class.
    /// </summary>
    /// <param name="source">The source to display.</param>
    public SourceForm(Source source)
    {
        this.InitializeComponent();
        this.controller = new SourceFormController(source);
        StartPosition = FormStartPosition.CenterScreen;
        this.LoadNotes();
        this.loadSource(source);
        this.documentControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    }

    #endregion

    #region Methods

    /// <summary>
    ///   Loads the notes.
    /// </summary>
    public void LoadNotes()
    {
        this.notesListView.Clear();
        this.controller.RefreshNotes();

        foreach (var currNote in this.controller.Notes)
        {
            this.notesListView.Items.Add(currNote.Text);
        }
    }

    private void loadSource(Source source)
    {
        this.videoControl1.Visible = false;
        this.documentControl1.Visible = false;

        switch (source.Type)
        {
            case SourceType.VideoLink:
                this.setupVideoPlayer(source);
                break;
            case SourceType.PdfLink:
            case SourceType.Pdf:
                _ = this.documentControl1.SetDocument(source.Link).Result;
                this.documentControl1.Visible = true;
                break;
            case SourceType.Image:
            case SourceType.Video:
            default:
                MessageBox.Show("This source type is not supported", "Unsupported Source Type", MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                Close();
                break;
        }
    }

    private void setupVideoPlayer(Source source)
    {
        _ = this.videoControl1.SetVideo(source.Link);
        this.waitForPlayer();
        this.videoControl1.Visible = true;
        this.Closing += (sender, e) => this.videoControl1.StopPlayback();
    }

    private void waitForPlayer()
    {
        MessageBox.Show("Please wait for the video to load", "Loading Video", MessageBoxButtons.OK,
            MessageBoxIcon.Information);
        while (!this.videoControl1.PlayerReady)
        {
            Application.DoEvents();
        }
    }

    private void addNoteButton_Click(object sender, EventArgs e)
    {
        var addNoteForm = new AddNoteForm(this.controller, this);
        addNoteForm.StartPosition = FormStartPosition.CenterParent;
        addNoteForm.ShowDialog();
    }

    private void notesListView_MouseDoubleClick(object sender, MouseEventArgs e)
    {
        var note = this.controller.Notes[this.notesListView.SelectedIndices[0]];
        var noteForm = new NoteForm(note, this.controller, this.notesListView.SelectedIndices[0], this);
        noteForm.StartPosition = FormStartPosition.CenterParent;
        noteForm.ShowDialog();
    }

    #endregion

    // private void handleType(SourceType type)
    // {
    //     switch (type)
    //     {
    //         case SourceType.Video:
    //         case SourceType.VideoLink:
    //             this.addVideoControl();
    //             break;
    //         case SourceType.Pdf:
    //         case SourceType.PdfLink:
    //             this.addDocumentControl();
    //             break;
    //         case SourceType.Image:
    //             this.addImageControl();
    //             break;
    //         default:
    //             throw new ArgumentOutOfRangeException(nameof(type), type, null);
    //     }
    // }

    // private void addVideoControl()
    // {
    //     var videoControl = new VideoControl();
    //     this.splitContainer1.Panel2.Controls.Add(videoControl);
    // }
    //
    // private void addDocumentControl()
    // {
    //     var documentControl = new DocumentControl();
    //     this.splitContainer1.Panel2.Controls.Add(documentControl);
    // }
    // private void addImageControl()
    // {
    //     var imageControl = new ImageControl();
    //     this.splitContainer1.Panel2.Controls.Add(imageControl);
    // }
}