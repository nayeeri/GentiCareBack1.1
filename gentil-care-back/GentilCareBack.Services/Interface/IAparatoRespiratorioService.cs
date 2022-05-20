using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IAparatoRespiratorioService
    {
        Task<List<AparatoRespiratorioDto>> GetAllAsync();
        Task<AparatoRespiratorioDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(AparatoRespiratorioDto obj);
        Task<bool> UpdateAsync(AparatoRespiratorioDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
