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
    public class FarmacosService : IFarmacosService
    {
        private IFarmacosRepository<Farmacos> repository = null;
        private readonly IMapper _mapper;

        public FarmacosService(IMapper mapper)
        {
            this.repository = new FarmacosRepository();
            this._mapper = mapper;
        }

        public async Task<List<FarmacosDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<FarmacosDto>>(result);
            return resp;
        }
        public async Task<FarmacosDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<FarmacosDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(FarmacosDto obj)
        {
            try
            {
                var req = _mapper.Map<Farmacos>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(FarmacosDto obj)
        {
            try
            {
                var req = _mapper.Map<Farmacos>(obj);
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
