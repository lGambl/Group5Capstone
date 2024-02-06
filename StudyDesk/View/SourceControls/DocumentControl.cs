namespace StudyDesk.View.SourceControls;

/// <summary>
///     UserControl for displaying a document.
/// </summary>
/// <seealso cref="System.Windows.Forms.UserControl" />
public partial class DocumentControl : UserControl
{
    /// <summary>
    ///     Initializes a new instance of the <see cref="DocumentControl" /> class.
    /// </summary>
    public DocumentControl()
    {
        InitializeComponent();
        documentViewer1.PerformAutoScale();
    }

    /// <summary>
    ///     Sets the document.
    /// </summary>
    /// <param name="filename">The filename.</param>
    public async Task<bool> SetDocument(string filename)
    {
        try
        {
            var temp = Path.Combine(Path.GetTempPath(), "peepee.pdf");
            DownloadFileAsync(filename, temp);
            var stream = new FileStream(temp, FileMode.Open, FileAccess.Read);
            documentViewer1.LoadDocument(stream);

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private async Task<bool> DownloadFileAsync(string fileUrl, string destinationPath)
    {
        try
        {

            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(fileUrl).ConfigureAwait(false);
                if (response.IsSuccessStatusCode)
                {
                    var directory = Path.GetDirectoryName(destinationPath);
                    if (!Directory.Exists(directory)) Directory.CreateDirectory(directory);


                    var fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write);


                    await response.Content.CopyToAsync(fileStream);
                }
                else
                {
                    throw new Exception($"Failed to download the file. Status code: {response.StatusCode}");
                }
            }

            return true;
        }
        catch (Exception)
        {

            return false;
        }
    }
}