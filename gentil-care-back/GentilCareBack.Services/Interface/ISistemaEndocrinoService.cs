using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface ISistemaEndocrinoService
    {
        Task<List<SistemaEndocrinoDto>> GetAllAsync();
        Task<SistemaEndocrinoDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(SistemaEndocrinoDto obj);
        Task<bool> UpdateAsync(SistemaEndocrinoDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
