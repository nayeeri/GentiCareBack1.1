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
    public class AparatoRespiratorioService : IAparatoRespiratorioService
    {
        private IAparatoRespiratorioRepository<AparatoRespiratorio> repository = null;
        private readonly IMapper _mapper;

        public AparatoRespiratorioService(IMapper mapper)
        {
            this.repository = new AparatoRespiratorioRepository();
            this._mapper = mapper;
        }

        public async Task<List<AparatoRespiratorioDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<AparatoRespiratorioDto>>(result);
            return resp;
        }
        public async Task<AparatoRespiratorioDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<AparatoRespiratorioDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(AparatoRespiratorioDto obj)
        {
            try
            {
                var req = _mapper.Map<AparatoRespiratorio>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(AparatoRespiratorioDto obj)
        {
            try
            {
                var req = _mapper.Map<AparatoRespiratorio>(obj);
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
