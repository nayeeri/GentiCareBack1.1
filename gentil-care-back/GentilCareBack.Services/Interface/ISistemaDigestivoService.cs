using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface ISistemaDigestivoService
    {
        Task<List<SistemaDigestivoDto>> GetAllAsync();
        Task<SistemaDigestivoDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(SistemaDigestivoDto obj);
        Task<bool> UpdateAsync(SistemaDigestivoDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
