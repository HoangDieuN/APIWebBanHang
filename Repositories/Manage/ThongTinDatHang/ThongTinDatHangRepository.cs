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
    public class ThongTinDatHangRepository :IThongTinDatHangRepository
    {
        private readonly IBaseRepository _baseRepository;
        public ThongTinDatHangRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<int> Creat(ThongTinDatHang requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DatHangId", requestModel.DatHangId);
                parameters.Add("@SanPhamId", requestModel.SanPhamId);
                parameters.Add("@Gia", requestModel.Gia);
                parameters.Add("@Quantity", requestModel.Quantity);
                var result = await _baseRepository.GetValue<int>("ThongTinDatHang_Creat", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ThongTinDatHangRepository Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> Update(ThongTinDatHang requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", requestModel.Id);
                parameters.Add("@DatHangId", requestModel.DatHangId);
                parameters.Add("@SanPhamId", requestModel.SanPhamId);
                parameters.Add("@Gia", requestModel.Gia);
                parameters.Add("@Quantity", requestModel.Quantity);
                parameters.Add("@UpdatedBy", requestModel.UpdatedBy);
                var result = await _baseRepository.GetValue<int>("ThongTinDatHang_Update", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ThongTinDatHangRepository Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<ThongTinDatHangPaging> GetAll(ThongTinDatHangRequest requestModel)
        {
            try
            {
                ThongTinDatHangPaging pagedResult = new ThongTinDatHangPaging();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Keywords", requestModel.Keywords);
                parameters.Add("@Start", requestModel.Start);
                parameters.Add("@Length", requestModel.Length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList("DanhMucSanPham_GetAll", parameters, read =>
                {
                    pagedResult.ListThongTinDatHang = read.Read<ThongTinDatHang>().ToList();
                    pagedResult.Total = parameters.Get<int>("@Count");
                });
                return pagedResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ThongTinDatHangRepository Error: {ex.Message}");
                return new ThongTinDatHangPaging();
            }
        }
        public async Task<ThongTinDatHang> GetById(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var result = await _baseRepository.GetList<ThongTinDatHang>("ThongTinDatHang_GetById", parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ThongTinDatHangRepository Error: {ex.Message}");
                return null;
            }
        }
        public async Task<int> Delete(ThongTinDatHangRequest requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Ids", requestModel.Ids);
                parameters.Add("@DeletedBy", requestModel.UpdatedBy);

                var result = await _baseRepository.GetValue<int>("ThongTinDatHang_Delete", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"ThongTinDatHangRepository Error: {ex.Message}");
                return 0;
            }
        }
    }
}
