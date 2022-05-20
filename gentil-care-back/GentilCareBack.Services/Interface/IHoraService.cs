using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IHoraService
    {
        Task<List<HorasDto>> GetAllAsync();
        Task<HorasDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(HorasDto obj, long idSemana);
        Task<bool> UpdateAsync(HorasDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
