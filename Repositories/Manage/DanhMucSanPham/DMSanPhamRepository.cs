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
    public class DMSanPhamRepository : IDMSanPhamRepository
    {
        private readonly IBaseRepository _baseRepository;
        public DMSanPhamRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<int> Creat(DanhMucSanPham requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenDanhMucSP", requestModel.TenDanhMucSP);
                parameters.Add("@MoTa", requestModel.MoTa);
                parameters.Add("@MaDanhMucSP", requestModel.MaDanhMucSP);
                parameters.Add("@IsActive", requestModel.IsActive);
                parameters.Add("@CreatedBy", requestModel.CreatedBy);
                var result = await _baseRepository.GetValue<int>("DanhMucSanPham_Creat", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMSanPhamRepository Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> Update(DanhMucSanPham requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", requestModel.Id);
                parameters.Add("@TenDanhMucSP", requestModel.TenDanhMucSP);
                parameters.Add("@MoTa", requestModel.MoTa);
                parameters.Add("@MaDanhMucSP", requestModel.MaDanhMucSP);
                parameters.Add("@IsActive", requestModel.IsActive);
                parameters.Add("@UpdatedBy", requestModel.UpdatedBy);
                var result = await _baseRepository.GetValue<int>("DanhMucSanPham_Update", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMSanPhamRepository Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<DanhMucSanPhamPaging> GetAll(DanhMucSanPhamRequest requestModel)
        {
            try
            {
                DanhMucSanPhamPaging pagedResult = new DanhMucSanPhamPaging();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Keywords", requestModel.Keywords);
                parameters.Add("@Start", requestModel.Start);
                parameters.Add("@Length", requestModel.Length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList("DanhMucSanPham_GetAll", parameters, read =>
                {
                    pagedResult.ListDanhMucSanPham = read.Read<DanhMucSanPham>().ToList();
                    pagedResult.Total = parameters.Get<int>("@Count");
                });
                return pagedResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMSanPhamRepository Error: {ex.Message}");
                return new DanhMucSanPhamPaging();
            }
        }
        public async Task<DanhMucSanPham> GetById(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var result = await _baseRepository.GetList<DanhMucSanPham>("DanhMucSanPham_GetById", parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMSanPhamRepository Error: {ex.Message}");
                return null;
            }
        }
        public async Task<int> Delete(DanhMucSanPhamRequest requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Ids", requestModel.Ids);
                parameters.Add("@DeletedBy", requestModel.UpdatedBy);

                var result = await _baseRepository.GetValue<int>("DanhMucSanPham_Delete", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMSanPhamRepository Error: {ex.Message}");
                return 0;
            }
        }
    }
}
