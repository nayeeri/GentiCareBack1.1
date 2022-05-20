using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface ISistemaNerviosoService
    {
        Task<List<SistemaNerviosoDto>> GetAllAsync();
        Task<SistemaNerviosoDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(SistemaNerviosoDto obj);
        Task<bool> UpdateAsync(SistemaNerviosoDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
