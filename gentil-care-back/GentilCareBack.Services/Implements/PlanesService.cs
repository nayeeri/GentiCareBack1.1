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
    public class PlanesService : IPlanesService
    {

        private IPlanesRepository<Planes> repository = null;
        private readonly IMapper _mapper;

        public PlanesService(IMapper mapper)
        {
            this.repository = new PlanesRepository();
            this._mapper = mapper;
        }

        public async Task<List<PlanesDto>> GetAllAsync() {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<PlanesDto>>(result);
            return resp;
        }
        public async Task<PlanesDto> GetByIdAsync(object id) {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<PlanesDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(PlanesDto obj) {
            try
            {
                var req = _mapper.Map<Planes>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> UpdateAsync(PlanesDto obj) {
            try
            {
                var req = _mapper.Map<Planes>(obj);
                await repository.UpdateAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(object id) {
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
