using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilities;

namespace Repositories
{
    public class AttachedFileRepository :IAttachedFileRepository
    {
        private readonly IBaseRepository _baseRepository;

        public AttachedFileRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<int> Create(AttachedFile requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("ListFiles", ParamsHelper.AttachedFileParams(requestModel.ListAttachedFile));
                parameters.Add("CreatedBy", requestModel.CreatedBy);
                int result = await _baseRepository.GetValue<int>("AttachedFile_Insert", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AttachedFileRepository Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<int> Delete(AttachedFile requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                parameters.Add("DeletedBy", requestModel.UpdatedBy);
                int result = await _baseRepository.GetValue<int>("AttachedFile_Delete", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AttachedFileRepository Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<AttachedFilePaging> GetAll(AttachedFileRequest requestModel)
        {
            try
            {
                AttachedFilePaging pagedResult = new AttachedFilePaging();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Keywords", requestModel.Keywords);
                parameters.Add("FileGroupID", requestModel.FileGroupID);
                parameters.Add("Start", requestModel.Start);
                parameters.Add("Length", requestModel.Length);
                parameters.Add("Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList("AttachedFile_GetAll", parameters, reader => {
                    pagedResult.ListAttachedFile = reader.Read<AttachedFile>().ToList();
                    pagedResult.Total = parameters.Get<int>("@Count");
                });
                return pagedResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AttachedFileRepository Error: {ex.Message}");
                return new AttachedFilePaging();
            }
        }

        public async Task<List<AttachedFile>> GetByGroupProduct(AttachedFileRequest requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("FileGroupCode", requestModel.FileGroupCode);
                parameters.Add("ProductIds", requestModel.ProductIds);
                List<AttachedFile> result = await _baseRepository.GetList<AttachedFile>("AttachedFile_GetByGroupProduct", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AttachedFileRepository Error: {ex.Message}");
                return new List<AttachedFile>();
            }
        }

        public async Task<AttachedFile> GetById(AttachedFile requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("Id", requestModel.Id);
                List<AttachedFile> result = await _baseRepository.GetList<AttachedFile>("AttachedFile_GetById", parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AttachedFileRepository Error: {ex.Message}");
                return null;
            }
        }
    }
}
