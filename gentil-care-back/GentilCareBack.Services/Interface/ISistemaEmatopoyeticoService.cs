using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface ISistemaEmatopoyeticoService
    {
        Task<List<SistemaEmatopoyeticoDto>> GetAllAsync();
        Task<SistemaEmatopoyeticoDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(SistemaEmatopoyeticoDto obj);
        Task<bool> UpdateAsync(SistemaEmatopoyeticoDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
