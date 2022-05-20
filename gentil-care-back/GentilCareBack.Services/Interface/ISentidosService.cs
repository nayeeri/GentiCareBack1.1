using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface ISentidosService
    {
        Task<List<SentidosDto>> GetAllAsync();
        Task<SentidosDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(SentidosDto obj);
        Task<bool> UpdateAsync(SentidosDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
