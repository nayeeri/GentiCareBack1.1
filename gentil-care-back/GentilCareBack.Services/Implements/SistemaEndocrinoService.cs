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
    public class SistemaEndocrinoService : ISistemaEndocrinoService
    {
        private ISistemaEndocrinoRepository<SistemaEndocrino> repository = null;
        private readonly IMapper _mapper;

        public SistemaEndocrinoService(IMapper mapper)
        {
            this.repository = new SistemaEndocrinoRepository();
            this._mapper = mapper;
        }

        public async Task<List<SistemaEndocrinoDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<SistemaEndocrinoDto>>(result);
            return resp;
        }
        public async Task<SistemaEndocrinoDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<SistemaEndocrinoDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(SistemaEndocrinoDto obj)
        {
            try
            {
                var req = _mapper.Map<SistemaEndocrino>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(SistemaEndocrinoDto obj)
        {
            try
            {
                var req = _mapper.Map<SistemaEndocrino>(obj);
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
