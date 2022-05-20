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
    public  class SistemaMusculoEsqueleticoService: ISistemaMusculoEsqueleticoService
    {
        private ISistemaMusculoEsqueleticoRepository<SistemaMusculoEsqueletico> repository = null;
        private readonly IMapper _mapper;

        public SistemaMusculoEsqueleticoService(IMapper mapper)
        {
            this.repository = new SistemaMusculoEsqueleticoRepository();
            this._mapper = mapper;
        }

        public async Task<List<SistemaMusculoEsqueleticoDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<SistemaMusculoEsqueleticoDto>>(result);
            return resp;
        }
        public async Task<SistemaMusculoEsqueleticoDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<SistemaMusculoEsqueleticoDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(SistemaMusculoEsqueleticoDto obj)
        {
            try
            {
                var req = _mapper.Map<SistemaMusculoEsqueletico>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(SistemaMusculoEsqueleticoDto obj)
        {
            try
            {
                var req = _mapper.Map<SistemaMusculoEsqueletico>(obj);
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
