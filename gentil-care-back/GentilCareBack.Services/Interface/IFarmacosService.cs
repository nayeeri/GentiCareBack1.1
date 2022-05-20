using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IFarmacosService
    {
        Task<List<FarmacosDto>> GetAllAsync();
        Task<FarmacosDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(FarmacosDto obj);
        Task<bool> UpdateAsync(FarmacosDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
