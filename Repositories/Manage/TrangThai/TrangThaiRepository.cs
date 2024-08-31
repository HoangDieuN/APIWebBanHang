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
    public class TrangThaiRepository :ITrangThaiRepository
    {
        private readonly IBaseRepository _baseRepository;
        public TrangThaiRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<TrangThaiPaging> GetAll(TrangThaiRequest requestModel)
        {
            try
            {
                TrangThaiPaging pagedResult = new TrangThaiPaging();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Keywords", requestModel.Keywords);
                parameters.Add("@Start", requestModel.Start);
                parameters.Add("@Length", requestModel.Length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList("TrangThai_GetAll", parameters, read =>
                {
                    pagedResult.ListTrangThai = read.Read<TrangThai>().ToList();
                    pagedResult.Total = parameters.Get<int>("@Count");
                });
                return pagedResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"TrangThaiRepository Error: {ex.Message}");
                return new TrangThaiPaging();
            }
        }
        public async Task<TrangThai> GetByDatHangId(TrangThaiRequest requestModel)
        {
            try
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@DatHangId", requestModel.DatHangId);
                var result = await _baseRepository.GetList<TrangThai>("TrangThai_GetByDatHangId", parameter);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"TrangThaiRepository Error: {ex.Message}");
                return null;
            }
        }
        public async Task<int> UpdateTrangThaiDonHang(TrangThaiRequest requestModel)
        {
            try
            {
                DynamicParameters parameter = new DynamicParameters();
                parameter.Add("@DatHangId", requestModel.DatHangId);
                parameter.Add("@StatusId", requestModel.StatusId);
                var result = await _baseRepository.GetValue<int>("TrangThai_Update", parameter);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"TrangThaiRepository Error: {ex.Message}");
                return 0;
            }
        }
    }
}
