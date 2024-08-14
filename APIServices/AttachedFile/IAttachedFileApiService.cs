using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APIServices
{
    public interface IAttachedFileApiService
    {
        Task<int> Create(AttachedFile requestModel);
        Task<int> Delete(AttachedFile requestModel);
        Task<AttachedFilePaging> GetAll(AttachedFileRequest requestModel);
        Task<List<AttachedFile>> GetByGroupProduct(AttachedFileRequest requestModel);
        Task<AttachedFile> GetById(AttachedFile requestModel);
    }
}
