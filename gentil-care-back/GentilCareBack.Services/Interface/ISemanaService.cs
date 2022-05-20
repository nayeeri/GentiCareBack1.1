using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface ISemanaService
    {
        Task<List<SemanaDto>> GetAllAsync();
        Task<SemanaDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(SemanaDto obj);
        Task<bool> UpdateAsync(SemanaDto obj);
        Task<bool> DeleteAsync(object id);
        Task<SemanaDto> getUltimateRegister();
    }
}
