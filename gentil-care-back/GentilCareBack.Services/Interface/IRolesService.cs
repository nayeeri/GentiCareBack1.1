using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IRolesService
    {
        Task<List<RolesDto>> GetAllAsync();
        Task<RolesDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(RolesDto obj);
        Task<bool> UpdateAsync(RolesDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
