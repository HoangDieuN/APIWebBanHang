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
    public class DMModuleRepository : IDMModuleRepository
    {
        private readonly IBaseRepository _baseRepository;
        public DMModuleRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<int> Creat(DMModule requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@ModuleName", requestModel.ModuleName);
                parameters.Add("@MoTa", requestModel.MoTa);
                parameters.Add("@TenViet", requestModel.TenViet);
                string moduleCode = StringHelper.FilterChar(requestModel.TenViet);
                parameters.Add("@ModuleCode", moduleCode);
                parameters.Add("@CreatedBy", requestModel.CreatedBy);
                var result = await _baseRepository.GetValue<int>("DMModule_Creat", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMModuleRepository Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> Update(DMModule requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", requestModel.Id);
                parameters.Add("@ModuleName", requestModel.ModuleName);
                parameters.Add("@TenViet", requestModel.TenViet);
                string moduleCode = StringHelper.FilterChar(requestModel.TenViet);
                parameters.Add("@ModuleCode", moduleCode);
                parameters.Add("@UpdatedBy", requestModel.UpdatedBy);
                parameters.Add("@MoTa", requestModel.MoTa);
                var result = await _baseRepository.GetValue<int>("DMModule_Update", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMModuleRepository Error: {ex.Message}");
                return 0;
            }
        }

        public async Task<DMModulePaging> GetAll(DMModuleRequest requestModel)
        {
            try
            {
                DMModulePaging pagedResult = new DMModulePaging();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Keywords", requestModel.Keywords);             
                parameters.Add("@Start", requestModel.Start);
                parameters.Add("@Length", requestModel.Length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList("DM_Module_GetAll", parameters, read =>
                {
                    pagedResult.ListModule = read.Read<DMModule>().ToList();
                    pagedResult.Total = parameters.Get<int>("@Count");
                });
                return pagedResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMModuleRepository Error: {ex.Message}");
                return new DMModulePaging();
            }
        }
        public async Task<DMModulePaging> GetAllActive(DMModuleRequest requestModel)
        {
            try
            {
                DMModulePaging pagedResult = new DMModulePaging();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Keywords", requestModel.Keywords);
                parameters.Add("@Start", requestModel.Start);
                parameters.Add("@Length", requestModel.Length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList("DM_Module_GetAllActive", parameters, read =>
                {
                    pagedResult.ListModule = read.Read<DMModule>().ToList();
                    pagedResult.Total = parameters.Get<int>("@Count");
                });
                return pagedResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMModuleRepository Error: {ex.Message}");
                return new DMModulePaging();
            }
        }
        public async Task<DMModule> GetById(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Id", id);
                var result = await _baseRepository.GetList<DMModule>("DMModule_GetById", parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMModuleRepository Error: {ex.Message}");
                return null;
            }
        }
        public async Task<int> Delete(DMModuleRequest requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Ids", requestModel.Ids);
                parameters.Add("@DeletedBy", requestModel.UpdatedBy);

                var result = await _baseRepository.GetValue<int>("DMModule_Delete", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMModuleRepository Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<int> UpdateActive(DMModuleRequest requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Ids", requestModel.Ids);
                parameters.Add("@IsActive", requestModel.IsActive);
                parameters.Add("@PhanHoi", requestModel.PhanHoi);
                parameters.Add("@UpdatedBy", requestModel.UpdatedBy);
                var result = await _baseRepository.GetValue<int>("DMModule_UpdateActive", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DMModuleRepository Error: {ex.Message}");
                throw;
            }
        }
    }
}
