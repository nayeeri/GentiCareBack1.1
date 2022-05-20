using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IEspecialidadsService
    {
        Task<List<EspecialidadsDto>> GetAllAsync();
        Task<EspecialidadsDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(EspecialidadsDto obj);
        Task<bool> UpdateAsync(EspecialidadsDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
