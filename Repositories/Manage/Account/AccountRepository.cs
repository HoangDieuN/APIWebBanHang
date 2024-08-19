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
    public class AccountRepository : IAccountRepository
    {
        private readonly IBaseRepository _baseRepository;
        public AccountRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }
        public async Task<int> Creat(User requestModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", requestModel.UserName);
                parameters.Add("@HoTen", requestModel.HoTen);
                parameters.Add("@Password", requestModel.Password);
                parameters.Add("@Email", requestModel.Email);
                parameters.Add("@DiaChi", requestModel.DiaChi);
                parameters.Add("@CreatedBy", requestModel.CreatedBy);
                var result = await _baseRepository.GetValue<int>("User_Creat", parameters);
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AccountRepository Error: {ex.Message}");
                return 0;
            }
        }
        public async Task<User> GetUserByUserName(LoginModel loginModel)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserName", loginModel.UserName);
                parameters.Add("@Password", loginModel.Password);
                var result = await _baseRepository.GetList<User>("User_GetByUserName_Password", parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AccountRepository Error: {ex.Message}");
                return null;
            }
        }
        public async Task<UserPaging> GetAll(UserRequest requestModel)
        {
            try
            {
                UserPaging pagedResult = new UserPaging();
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@Keywords", requestModel.Keywords);
                parameters.Add("@Start", requestModel.Start);
                parameters.Add("@Length", requestModel.Length);
                parameters.Add("@Count", dbType: DbType.Int32, direction: ParameterDirection.Output);
                var result = await _baseRepository.GetMultipleList("User_GetAll", parameters, read =>
                {
                    pagedResult.ListTaiKhoan = read.Read<User>().ToList();
                    pagedResult.Total = parameters.Get<int>("@Count");
                });
                return pagedResult;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AccountRepository Error: {ex.Message}");
                return new UserPaging();
            }
        }
        public async Task<User> GetUserByUserId(int id)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@UserId", id);
                var result = await _baseRepository.GetList<User>("User_GetByUserId",parameters);
                return result.FirstOrDefault();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"AccountRepository Error: {ex.Message}");
                return null;
            }
        }

    }
}
