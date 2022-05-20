using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IMotivosService
    {
        Task<List<MotivosDto>> GetAllAsync();
        Task<MotivosDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(MotivosDto obj);
        Task<bool> UpdateAsync(MotivosDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
