namespace Models
{
    public class AttachedFileRequest : BaseRequest
    {
        public int FileGroupID { get; set; }
        public string FileGroupCode { get; set; }
        public string ProductIds { get; set; }
    }
}