using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly IAppConfiguration _appConfiguration;
        public BaseRepository(IAppConfiguration appConfiguration)
        {
            _appConfiguration = appConfiguration;
        }

        public async Task<bool> GetMultipleList(string procedureName, object parameters, Action<GridReader> callback)
        {
            try
            {
                using var conn = new SqlConnection(_appConfiguration.GetConnectionString());
                var result = await conn.QueryMultipleAsync(procedureName, parameters, commandType: CommandType.StoredProcedure/*, commandTimeout: 360*/);
                callback(result);
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DB Connect Error: {ex.Message}");
                return false;
            }
        }

        public async Task<List<T>> GetList<T>(string procedureName, object parameters = null)
        {
            try
            {
                using var conn = new SqlConnection(_appConfiguration.GetConnectionString());
                return (await conn.QueryAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure/*, commandTimeout: 360*/)).ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DB Connect Error: {ex.Message}");
                return new List<T>();
            }
        }

        public async Task<T> GetValue<T>(string procedureName, object parameters)
        {
            try
            {
                using var conn = new SqlConnection(_appConfiguration.GetConnectionString());
                return await conn.ExecuteScalarAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure, commandTimeout: 600);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DB Connect Error: {ex.Message}");
                return default;
            }
        }

        public async Task<T> ReturnValue<T>(string procedureName, DynamicParameters parameters, string resultParameter)
        {
            try
            {
                using var conn = new SqlConnection(_appConfiguration.GetConnectionString());
                var result = await conn.ExecuteScalarAsync(procedureName, parameters, commandType: CommandType.StoredProcedure/*, commandTimeout: 360*/);
                return parameters.Get<T>(resultParameter);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DB Connect Error: {ex.Message}");
                return default;
            }
        }

        public async Task<T> GetFirst<T>(string procedureName, object parameters = null)
        {
            try
            {
                using var conn = new SqlConnection(_appConfiguration.GetConnectionString());
                T result = (await conn.QueryAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure)).FirstOrDefault();
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"DB Connect Error: {ex.Message}");
                throw;
            }
        }
    }
}
