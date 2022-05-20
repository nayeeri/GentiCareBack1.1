using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IPlanesService
    {
        Task<List<PlanesDto>> GetAllAsync();
        Task<PlanesDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(PlanesDto obj);
        Task<bool> UpdateAsync(PlanesDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
