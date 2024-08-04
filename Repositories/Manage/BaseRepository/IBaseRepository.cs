using Dapper;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Repositories
{
    public interface IBaseRepository
    {
        /// <summary>
        /// Lấy nhiều danh sách bản ghi
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns>Danh sách bản ghi và tổng số bản ghi</returns>
        Task<bool> GetMultipleList(string procedureName, object parameters, Action<GridReader> callback);
        /// <summary>
        /// Lấy danh sách bản ghi
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns>Danh sách bản ghi và tổng số bản ghi</returns>
        Task<List<T>> GetList<T>(string procedureName, object parameters = null);
        /// <summary>
        /// Lấy bản ghi đầu tiên
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns>Bản ghi đầu tiên</returns>
        Task<T> GetFirst<T>(string procedureName, object parameters = null);
        /// <summary>
        /// Lấy danh sách bản ghi
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <returns>Danh sách bản ghi và tổng số bản ghi</returns>
        Task<T> GetValue<T>(string procedureName, object parameters = null);
        /// <summary>
        /// Thực thi thủ tục trả về giá trị
        /// </summary>
        /// <param name="procedureName"></param>
        /// <param name="parameters"></param>
        /// <param name="resultParameter"></param>
        /// <returns>Giá trị trả về</returns>
        Task<T> ReturnValue<T>(string procedureName, DynamicParameters parameters, string resultParameter);
    }
}
