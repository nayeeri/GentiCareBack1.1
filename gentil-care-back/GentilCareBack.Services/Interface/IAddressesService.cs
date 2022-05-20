using GentilCareBack.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Interface
{
    public interface IAddressesService
    {
        Task<List<AddressesDto>> GetAllAsync();
        Task<AddressesDto> GetByIdAsync(object id);
        Task<bool>InsertAsync(AddressesDto obj);
        Task<bool> UpdateAsync(AddressesDto obj);
        Task<bool> DeleteAsync(object id);

        Task<List<AddressesDto>> getListAddressUser(long idUser);
    }
}
