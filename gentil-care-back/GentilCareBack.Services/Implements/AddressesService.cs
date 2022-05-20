using AutoMapper;
using GentilCareBack.Data.Implements;
using GentilCareBack.Data.Interface;
using GentilCareBack.Dto;
using GentilCareBack.Models.Entity;
using GentilCareBack.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Implements
{
    public class AddressesService : IAddressesService
    {
        private IAddressesRepository<Addresses> repository = null;
        private readonly IMapper _mapper;

        public AddressesService(IMapper mapper)
        {
            this.repository = new AddressesRepository();
            this._mapper = mapper;
        }

        public async Task<List<AddressesDto>> GetAllAsync()
        {
            var result =  await repository.GetAllAsync();
            var resp = _mapper.Map<List<AddressesDto>>(result);
            return resp;
        }

        public async Task<List<AddressesDto>> getListAddressUser(long idUser) {
            var result = await repository.getListAddressUser(idUser);
            var resp = _mapper.Map<List<AddressesDto>>(result);
            return resp;
        }
        public async Task<AddressesDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<AddressesDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(AddressesDto obj)
        {
            try
            {
                var req = _mapper.Map<Addresses>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex) {
                return false;
            }
            
        }
        public async Task<bool> UpdateAsync(AddressesDto obj)
        {
            try {
                var req = _mapper.Map<Addresses>(obj);
                await repository.UpdateAsync(req);
                return true;
            }
            catch (Exception ex) {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(object id)
        {
            try
            {
                await repository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex) {
                return false;
            }
            
        }
    }
}
