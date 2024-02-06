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
        this.InitializeComponent();
        this.documentViewer1.PerformAutoScale();
    }

    /// <summary>
    ///     Sets the document.
    /// </summary>
    /// <param name="filename">The filename.</param>
    public Task<bool> SetDocument(string filename)
    {
        try
        {
            var temp = Path.Combine(Path.GetTempPath(), "peepee.pdf");
            if (downloadFileAsync(filename, temp).Result)
            {
                var stream = new FileStream(temp, FileMode.Open, FileAccess.Read);
                this.documentViewer1.LoadDocument(stream);
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

    private static async Task<bool> downloadFileAsync(string fileUrl, string destinationPath)
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
}