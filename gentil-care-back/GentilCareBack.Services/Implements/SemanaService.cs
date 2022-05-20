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
    public class SemanaService : ISemanaService
    {
        private ISemanaRepository<Semana> repository = null;
        private readonly IMapper _mapper;

        public SemanaService(IMapper mapper)
        {
            this.repository = new SemanaRepository();
            this._mapper = mapper;
        }

        public async Task<List<SemanaDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<SemanaDto>>(result);
            return resp;
        }

        
        public async Task<SemanaDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<SemanaDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(SemanaDto obj)
        {
            try
            {
                var req = _mapper.Map<Semana>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<SemanaDto> getUltimateRegister() {
            var result = await repository.getUltimateRegister();
            var resp = _mapper.Map<SemanaDto>(result);
            return resp;
        }


        public async Task<bool> UpdateAsync(SemanaDto obj)
        {
            try
            {
                var req = _mapper.Map<Semana>(obj);
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
