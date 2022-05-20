using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IColaboradorsService
    {
        Task<List<ColaboradorsDto>> GetAllAsync();
        Task<ColaboradorsDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(ColaboradorsDto obj);
        Task<bool> UpdateAsync(ColaboradorsDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
