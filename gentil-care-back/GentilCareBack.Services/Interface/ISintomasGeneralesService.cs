using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface ISintomasGeneralesService
    {
        Task<List<SintomasGeneralesDto>> GetAllAsync();
        Task<SintomasGeneralesDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(SintomasGeneralesDto obj);
        Task<bool> UpdateAsync(SintomasGeneralesDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
