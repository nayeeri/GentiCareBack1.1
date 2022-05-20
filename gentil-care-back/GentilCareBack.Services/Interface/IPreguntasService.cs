using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IPreguntasService
    {
        Task<List<PreguntasDto>> GetAllAsync();
        Task<PreguntasDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(PreguntasDto obj);
        Task<bool> UpdateAsync(PreguntasDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
