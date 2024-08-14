using Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IAttachedFileRepository
    {
        Task<int> Create(AttachedFile requestModel);
        Task<int> Delete(AttachedFile requestModel);
        Task<AttachedFilePaging> GetAll(AttachedFileRequest requestModel);
        Task<List<AttachedFile>> GetByGroupProduct(AttachedFileRequest requestModel);
        Task<AttachedFile> GetById(AttachedFile requestModel);
    }
}
