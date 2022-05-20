using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IPielTegumentosService
    {
        Task<List<PielTegumentosDto>> GetAllAsync();
        Task<PielTegumentosDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(PielTegumentosDto obj);
        Task<bool> UpdateAsync(PielTegumentosDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
