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
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly IBaseRepository _baseRepository;
        public SanPhamRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<int> Creat(SanPham requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@TenSanPham", requestModel.TenSanPham);
                parameters.Add("@DanhMucId", requestModel.DanhMucId);
                parameters.Add("@Nam", requestModel.Nam);
                parameters.Add("@MaSanPham", requestModel.MaSanPham);
                parameters.Add("@MoTa", requestModel.MoTa);
                parameters.Add("@ThongTin", requestModel.ThongTin);
                parameters.Add("@GiaGoc", requestModel.GiaGoc);
                parameters.Add("@PhanTramGiam", requestModel.PhanTramGiam);
                parameters.Add("@IsSale", requestModel.IsSale);
                //parameters.Add("@IsActive", requestModel.IsActive);
                parameters.Add("@CreatedBy", requestModel.CreatedBy);
                var result = await _baseRepository.GetValue<int>("SanPham_Creat", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SanPhamRepository Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> Update(SanPham requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", requestModel.Id);
                parameters.Add("@TenSanPham", requestModel.TenSanPham);
                parameters.Add("@DanhMucId", requestModel.DanhMucId);
                parameters.Add("@Nam", requestModel.Nam);
                parameters.Add("@MaSanPham", requestModel.MaSanPham);
                parameters.Add("@MoTa", requestModel.MoTa);
                parameters.Add("@ThongTin", requestModel.ThongTin);
                parameters.Add("@GiaGoc", requestModel.GiaGoc);
                parameters.Add("@PhanTramGiam", requestModel.PhanTramGiam);
                parameters.Add("@IsSale", requestModel.IsSale);
                parameters.Add("@IsActive", requestModel.IsActive);
                parameters.Add("@UpdatedBy", requestModel.UpdatedBy);
                var result = await _baseRepository.GetValue<int>("SanPham_Update", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SanPhamRepository Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<SanPhamPaging> GetAll(SanPhamRequest requestModel)
        {
            try
            {
                SanPhamPaging pagedResult = new SanPhamPaging();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Keywords", requestModel.Keywords);
                parameters.Add("@DanhMucId", requestModel.DanhMucId);
                parameters.Add("@Nam", requestModel.Nam);
                parameters.Add("@Start", requestModel.Start);
                parameters.Add("@Length", requestModel.Length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList("SanPham_GetAll", parameters, read =>
                {
                    pagedResult.ListSanPham = read.Read<SanPham>().ToList();
                    pagedResult.Total = parameters.Get<int>("@Count");
                });
                return pagedResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SanPhamRepository Error: {ex.Message}");
                return new SanPhamPaging();
            }
        }
        public async Task<SanPham> GetById(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var result = await _baseRepository.GetList<SanPham>("SanPham_GetById", parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SanPhamRepository Error: {ex.Message}");
                return null;
            }
        }
        public async Task<int> Delete(SanPhamRequest requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Ids", requestModel.Ids);
                parameters.Add("@DeletedBy", requestModel.UpdatedBy);

                var result = await _baseRepository.GetValue<int>("SanPham_Delete", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SanPhamRepository Error: {ex.Message}");
                return 0;
            }
        }
    }
}
