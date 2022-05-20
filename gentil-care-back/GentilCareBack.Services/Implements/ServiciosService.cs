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
    public class ServiciosService : IServiciosService
    {
        private IServiciosRepository<Servicios> repository = null;
        private readonly IMapper _mapper;

        public ServiciosService(IMapper mapper)
        {
            this.repository = new ServiciosRepository();
            this._mapper = mapper;
        }

        public async Task<List<ServiciosDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<ServiciosDto>>(result);
            return resp;
        }
        public async Task<ServiciosDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<ServiciosDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(ServiciosDto obj)
        {
            try
            {
                var req = _mapper.Map<Servicios>(obj);

                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(ServiciosDto obj)
        {
            try
            {
                var req = _mapper.Map<Servicios>(obj);
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
