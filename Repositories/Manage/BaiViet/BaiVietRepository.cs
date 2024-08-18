using Dapper;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BaiVietRepository : IBaiVietRepository
    {
        private readonly IBaseRepository _baseRepository;
        public BaiVietRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<int> Creat(BaiViet requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenBaiViet", requestModel.TenBaiViet);
                parameters.Add("@MoTa", requestModel.MoTa);
                parameters.Add("@ThongTin", requestModel.ThongTin);
                parameters.Add("@NoiDung", requestModel.NoiDung);
                parameters.Add("@IsActive", requestModel.IsActive);
                parameters.Add("@CreatedBy", requestModel.CreatedBy);
                var result = await _baseRepository.GetValue<int>("BaiViet_Creat", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"BaiVietRepository Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> Update(BaiViet requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", requestModel.Id);
                parameters.Add("@TenBaiViet", requestModel.TenBaiViet);
                parameters.Add("@MoTa", requestModel.MoTa);
                parameters.Add("@ThongTin", requestModel.ThongTin);
                parameters.Add("@NoiDung", requestModel.NoiDung);    
                parameters.Add("@IsActive", requestModel.IsActive);
                parameters.Add("@UpdatedBy", requestModel.UpdatedBy);
                var result = await _baseRepository.GetValue<int>("BaiViet_Update", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"BaiVietRepository Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<BaiVietPaging> GetAll(BaiVietRequest requestModel)
        {
            try
            {
                BaiVietPaging pagedResult = new BaiVietPaging();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Keywords", requestModel.Keywords);
                parameters.Add("@Start", requestModel.Start);
                parameters.Add("@Length", requestModel.Length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList("BaiViet_GetAll", parameters, read =>
                {
                    pagedResult.ListBaiViet = read.Read<BaiViet>().ToList();
                    pagedResult.Total = parameters.Get<int>("@Count");
                });
                return pagedResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"BaiVietRepository Error: {ex.Message}");
                return new BaiVietPaging();
            }
        }
        public async Task<BaiViet> GetById(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var result = await _baseRepository.GetList<BaiViet>("BaiViet_GetById", parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"BaiVietRepository Error: {ex.Message}");
                return null;
            }
        }
        public async Task<int> Delete(BaiVietRequest requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Ids", requestModel.Ids);
                parameters.Add("@DeletedBy", requestModel.DeletedBy);

                var result = await _baseRepository.GetValue<int>("BaiViet_Delete", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"BaiVietRepository Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> UpdateActive(BaiVietRequest requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Ids", requestModel.Ids);
                parameters.Add("@IsActive", requestModel.IsActive);
                parameters.Add("@PhanHoi", requestModel.PhanHoi);
                parameters.Add("@UpdatedBy", requestModel.UpdatedBy);
                var result = await _baseRepository.GetValue<int>("BaiViet_UpdateActive", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"BaiVietRepository Error: {ex.Message}");
                throw;
            }
        }
    }
}
