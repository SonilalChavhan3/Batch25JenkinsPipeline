namespace Batch25JenkinsPipeline.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrWhiteSpace(RequestId);
    }
}
