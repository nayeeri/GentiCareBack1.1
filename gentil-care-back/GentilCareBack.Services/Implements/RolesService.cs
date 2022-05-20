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
    public class RolesService : IRolesService
    {
        private IRolesRepository<Roles> repository = null;
        private readonly IMapper _mapper;

        public RolesService(IMapper mapper)
        {
            this.repository = new RolesRepository();
            this._mapper = mapper;
        }

        public async Task<List<RolesDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<RolesDto>>(result);
            return resp;
        }
        public async Task<RolesDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<RolesDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(RolesDto obj)
        {
            try
            {
                var req = _mapper.Map<Roles>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(RolesDto obj)
        {
            try
            {
                var req = _mapper.Map<Roles>(obj);
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
