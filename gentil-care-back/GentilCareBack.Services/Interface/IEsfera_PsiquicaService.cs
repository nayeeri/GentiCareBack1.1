using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IEsfera_PsiquicaService
    {
        Task<List<Esfera_PsiquicaDto>> GetAllAsync();
        Task<Esfera_PsiquicaDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(Esfera_PsiquicaDto obj);
        Task<bool> UpdateAsync(Esfera_PsiquicaDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
