using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BaseGuidModel
    {
        public int Stt { get; set; }
        public Guid? Id { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public int Status { get; set; }
    }

    public class BaseModels
    {
        public int start { get; set; }
        public int length { get; set; }
        public int Stt { get; set; }
        public int Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
        public string DeletedBy { get; set; }

    }
    public class BasePaging
    {
        public int Total { get; set; }
    }
    public class BaseRequest
    {
        public string Keywords { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
        public int Draw { get; set; }
        public int Start { get; set; }
        public int Length { get; set; }
        public string UpdatedBy { get; set; }
        public string DeletedBy { get; set; }

    }
    public class BaseModelPhanQuyen
    {
        public int start { get; set; }
        public int length { get; set; }
        public string UserId { get; set; }
        public string Id { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int Status { get; set; }
        public string ModelContent { get; set; }
        public int STT { get; set; }
    }
}
