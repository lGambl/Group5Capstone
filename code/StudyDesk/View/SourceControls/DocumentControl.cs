using PdfiumViewer;

namespace StudyDesk.View.SourceControls;

/// <summary>
///     UserControl for displaying a document.
/// </summary>
/// <seealso cref="System.Windows.Forms.UserControl" />
public partial class DocumentControl : UserControl
{

    private double zoomFactor = 1.0;
    private string filePath;

    /// <summary>
    ///     Initializes a new instance of the <see cref="DocumentControl" /> class.
    /// </summary>
    public DocumentControl()
    {
        this.InitializeComponent();
        this.filePath = "";
        flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
    }

    /// <summary>
    ///     Sets the document.
    /// </summary>
    /// <param name="filename">The filename.</param>
    public Task<bool> SetDocument(string filename)
    {
        try
        {
            var trimmedFile = filename.Split("/")[^1];
            var trimmedFilename = trimmedFile.Substring(8);

            var temp = Path.Combine(Path.GetTempPath(), trimmedFilename);
            if (DownloadFileAsync(filename, temp).Result)
            {
                this.filePath = temp;
                this.RenderPdf();
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }


    private void RenderPdf()
    {
        flowLayoutPanel1.Controls.Clear();

        using var document = PdfDocument.Load(this.filePath);
        for (int pageIndex = 0; pageIndex < document.PageCount; pageIndex++)
        {
            var image = document.Render(pageIndex, (int)(300 * zoomFactor), (int)(300 * zoomFactor), true);
            var pictureBox = new PictureBox
            {
                Image = image,
                SizeMode = PictureBoxSizeMode.Zoom,
                Width = flowLayoutPanel1.ClientSize.Width,
                Height = (int)(image.Height * ((double)flowLayoutPanel1.ClientSize.Width / image.Width)),
                Margin = new Padding(0)
            };
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Controls.Add(pictureBox);
        }
    }


    private static async Task<bool> DownloadFileAsync(string fileUrl, string destinationPath)
    {
        try
        {

            using var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(fileUrl).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                var directory = Path.GetDirectoryName(destinationPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory!);
                }

                var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write);


                await response.Content.CopyToAsync(fileStream);
                fileStream.Close();
            }
            else
            {
                throw new Exception($"Failed to download the file. Status code: {response.StatusCode}");
            }

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    /// <summary>
    ///     Zooms the in the pdf.
    /// </summary>
    public void ZoomIn()
    {
        zoomFactor *= 1.1;
        if (flowLayoutPanel1.Controls.Count > 0)
        {
            RenderPdf();
        }
    }

    /// <summary>
    ///     Zooms the out the pdf.
    /// </summary>
    public void ZoomOut()
    {
        zoomFactor /= 1.1;
        if (flowLayoutPanel1.Controls.Count > 0)
        {
            RenderPdf();
        }
    }

    private void zoomInButton_Click(object sender, EventArgs e)
    {
        this.ZoomIn();
    }

    private void zoomOutButton_Click(object sender, EventArgs e)
    {
        this.ZoomOut();
    }
}