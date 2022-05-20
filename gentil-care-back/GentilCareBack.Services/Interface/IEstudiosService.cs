using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IEstudiosService
    {
        Task<List<EstudiosDto>> GetAllAsync();
        Task<EstudiosDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(EstudiosDto obj);
        Task<bool> UpdateAsync(EstudiosDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
