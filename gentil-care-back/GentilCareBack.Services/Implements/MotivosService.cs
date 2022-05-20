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
    public class MotivosService : IMotivosService
    {
        private IMotivosRepository<Motivos> repository = null;
        private readonly IMapper _mapper;

        public MotivosService(IMapper mapper)
        {
            this.repository = new MotivosRepository();
            this._mapper = mapper;
        }

        public async Task<List<MotivosDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<MotivosDto>>(result);
            return resp;
        }
        public async Task<MotivosDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<MotivosDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(MotivosDto obj)
        {
            try
            {
                var req = _mapper.Map<Motivos>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(MotivosDto obj)
        {
            try
            {
                var req = _mapper.Map<Motivos>(obj);
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
