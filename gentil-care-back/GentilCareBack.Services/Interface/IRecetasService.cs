using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IRecetasService
    {
        Task<List<RecetasDto>> GetAllAsync();
        Task<RecetasDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(RecetasDto obj);
        Task<bool> UpdateAsync(RecetasDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
