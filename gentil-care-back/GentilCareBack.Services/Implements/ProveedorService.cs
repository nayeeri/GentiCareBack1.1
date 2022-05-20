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
    public class ProveedorService : IProveedorService
    {
        private IProveedorRepository<Proveedor> repository = null;
        private readonly IMapper _mapper;

        public ProveedorService(IMapper mapper)
        {
            this.repository = new ProveedorRepository();
            this._mapper = mapper;
        }

        public async Task<List<ProveedorDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<ProveedorDto>>(result);
            return resp;
        }
        public async Task<ProveedorDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<ProveedorDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(ProveedorDto obj)
        {
            try
            {
                var req = _mapper.Map<Proveedor>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateAsync(ProveedorDto obj)
        {
            try
            {
                var req = _mapper.Map<Proveedor>(obj);
                await repository.UpdateAsync(req);
                return true;
            }
            catch (Exception ex)
            {
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
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
