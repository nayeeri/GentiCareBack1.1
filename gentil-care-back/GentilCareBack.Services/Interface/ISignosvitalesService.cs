using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface ISignosvitalesService
    {
        Task<List<SignosvitalesDto>> GetAllAsync();
        Task<SignosvitalesDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(SignosvitalesDto obj);
        Task<bool> UpdateAsync(SignosvitalesDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
