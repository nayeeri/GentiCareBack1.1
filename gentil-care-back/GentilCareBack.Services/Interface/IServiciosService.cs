using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IServiciosService
    {
        Task<List<ServiciosDto>> GetAllAsync();
        Task<ServiciosDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(ServiciosDto obj);
        Task<bool> UpdateAsync(ServiciosDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
