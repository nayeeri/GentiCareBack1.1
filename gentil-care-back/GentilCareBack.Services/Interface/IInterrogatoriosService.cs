using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IInterrogatoriosService
    {
        Task<List<InterrogatoriosDto>> GetAllAsync();
        Task<InterrogatoriosDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(InterrogatoriosDto obj);
        Task<bool> UpdateAsync(InterrogatoriosDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
