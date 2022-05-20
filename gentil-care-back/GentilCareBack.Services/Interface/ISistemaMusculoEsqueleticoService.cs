using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface ISistemaMusculoEsqueleticoService
    {
        Task<List<SistemaMusculoEsqueleticoDto>> GetAllAsync();
        Task<SistemaMusculoEsqueleticoDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(SistemaMusculoEsqueleticoDto obj);
        Task<bool> UpdateAsync(SistemaMusculoEsqueleticoDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
