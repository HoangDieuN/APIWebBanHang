using System.Collections.Generic;

namespace Models
{
    public class AttachedFilePaging : BasePaging
    {
        public List<AttachedFile> ListAttachedFile { get; set; } = new List<AttachedFile>();
    }
}