using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IUsersService
    {
        Task<List<UsersDto>> GetAllAsync();
        Task<UsersDto> GetByIdAsync(object id);
        Task<UsersDto> InsertAsync(UsersDto obj);
        Task<bool> UpdateAsync(UsersDto obj);
        Task<bool> DeleteAsync(object id);
        Task<UsersDto> getUltimateRegister();

        Task<List<UsersDto>> GetAllColaboratorAsync();
        Task<List<UsersDto>> GetAllFamiliaresAsync(string id);

        Task<UsersDto> GetByPinAndCorreoAsync(string pin, string email);
    }
}
