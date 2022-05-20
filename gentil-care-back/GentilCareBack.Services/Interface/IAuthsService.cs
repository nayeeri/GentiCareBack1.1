using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IAuthsService
    {
        Task<List<AuthsDto>> GetAllAsync();
        Task<AuthsDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(AuthsDto obj);
        Task<bool> UpdateAsync(AuthsDto obj);
        Task<bool> DeleteAsync(object id);
        Task<AuthsDto> validateUser(AuthsDto obj);
    }
}
