using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IProveedorService
    {
        Task<List<ProveedorDto>> GetAllAsync();
        Task<ProveedorDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(ProveedorDto obj);
        Task<bool> UpdateAsync(ProveedorDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
