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
    public class DatHangRepository :IDatHangRepository
    {
        private readonly IBaseRepository _baseRepository;
        public DatHangRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<int> Creat(DatHang requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@MaDon", requestModel.MaDon);
                parameters.Add("@TenKhachHang", requestModel.TenKhachHang);
                parameters.Add("@SoDT", requestModel.SoDT);
                parameters.Add("@DiaChi", requestModel.DiaChi);
                parameters.Add("@Email", requestModel.Email);
                parameters.Add("@TongDon", requestModel.TongDon);
                parameters.Add("@Quantity", requestModel.Quantity);
                parameters.Add("@Status", requestModel.Status);

                var result = await _baseRepository.GetValue<int>("DatHang_Creat", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DatHangRepository Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> Update(DatHang requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", requestModel.Id);
                parameters.Add("@MaDon", requestModel.MaDon);
                parameters.Add("@TenKhachHang", requestModel.TenKhachHang);
                parameters.Add("@SoDT", requestModel.SoDT);
                parameters.Add("@DiaChi", requestModel.DiaChi);
                parameters.Add("@Email", requestModel.Email);
                parameters.Add("@TongDon", requestModel.TongDon);
                parameters.Add("@Quantity", requestModel.Quantity);
                parameters.Add("@Status", requestModel.Status);
                var result = await _baseRepository.GetValue<int>("DatHang_Update", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DatHangRepository Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<DatHangPaging> GetAll(DatHangRequest requestModel)
        {
            try
            {
                DatHangPaging pagedResult = new DatHangPaging();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Keywords", requestModel.Keywords);
                parameters.Add("@Start", requestModel.Start);
                parameters.Add("@Length", requestModel.Length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList("DatHang_GetAll", parameters, read =>
                {
                    pagedResult.ListDatHang = read.Read<DatHang>().ToList();
                    pagedResult.Total = parameters.Get<int>("@Count");
                });
                return pagedResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DatHangRepository Error: {ex.Message}");
                return new DatHangPaging();
            }
        }
        public async Task<DatHang> GetById(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var result = await _baseRepository.GetList<DatHang>("DatHang_GetById", parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DatHangRepository Error: {ex.Message}");
                return null;
            }
        }
        public async Task<int> Delete(DatHangRequest requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Ids", requestModel.Ids);
                parameters.Add("@DeletedBy", requestModel.UpdatedBy);

                var result = await _baseRepository.GetValue<int>("DatHang_Delete", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DatHangRepository Error: {ex.Message}");
                return 0;
            }
        }
    }
}
