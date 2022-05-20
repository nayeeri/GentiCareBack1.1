using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IMedicamentoService
    {
        Task<List<MedicamentoDto>> GetAllAsync();
        Task<MedicamentoDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(MedicamentoDto obj);
        Task<bool> UpdateAsync(MedicamentoDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
