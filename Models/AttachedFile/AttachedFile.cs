using System;
using System.Collections.Generic;

namespace Models
{
    public class AttachedFile
    {
        public int Stt { get; set; }
        public Guid? Id { get; set; }
        public string FileGroupCode { get; set; }
        public int ProductID { get; set; }
        public string FileKey { get; set; }
        public string FileName { get; set; }
        public string FileType { get; set; }
        public int FileSize { get; set; }
        public string FilePath { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }

        #region extend properties
        public string UserCode { get; set; }
        public string UserFullName { get; set; }
        public string ModuleName { get; set; }
        public int IsUploaded { get; set; }
        public string TempCode { get; set; }
        public List<AttachedFile> ListAttachedFile { get; set; }
        #endregion extend properties
    }
}