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
    public class SistemaDigestivoService : ISistemaDigestivoService
    {
        private ISistemaDigestivoRepository<SistemaDigestivo> repository = null;
        private readonly IMapper _mapper;

        public SistemaDigestivoService(IMapper mapper)
        {
            this.repository = new SistemaDigestivoRepository();
            this._mapper = mapper;
        }

        public async Task<List<SistemaDigestivoDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<SistemaDigestivoDto>>(result);
            return resp;
        }
        public async Task<SistemaDigestivoDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<SistemaDigestivoDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(SistemaDigestivoDto obj)
        {
            try
            {
                var req = _mapper.Map<SistemaDigestivo>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(SistemaDigestivoDto obj)
        {
            try
            {
                var req = _mapper.Map<SistemaDigestivo>(obj);
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
