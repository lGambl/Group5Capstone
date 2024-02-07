
namespace StudyWeb.Models
{

    /// <summary>
    ///   The Error View Model
    /// </summary>
    public class ErrorViewModel
    {

        /// <summary>
        ///   Request ID
        /// </summary>
        public string? RequestId { get; init; }

        /// <summary>
        ///   Show request ID
        /// </summary>
        public bool ShowRequestId => !string.IsNullOrEmpty(this.RequestId);
    }
}
