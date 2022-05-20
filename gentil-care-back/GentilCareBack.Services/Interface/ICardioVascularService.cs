using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface ICardioVascularService
    {
        Task<List<CardioVascularDto>> GetAllAsync();
        Task<CardioVascularDto> GetByIdAsync(object id);
        Task<bool> InsertAsync(CardioVascularDto obj);
        Task<bool> UpdateAsync(CardioVascularDto obj);
        Task<bool> DeleteAsync(object id);
    }
}
