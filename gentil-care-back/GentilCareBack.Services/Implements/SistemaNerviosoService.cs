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
    public class SistemaNerviosoService: ISistemaNerviosoService
    {
        private ISistemaNerviosoRepository<SistemaNervioso> repository = null;
        private readonly IMapper _mapper;

        public SistemaNerviosoService(IMapper mapper)
        {
            this.repository = new SistemaNerviosoRepository();
            this._mapper = mapper;
        }

        public async Task<List<SistemaNerviosoDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<SistemaNerviosoDto>>(result);
            return resp;
        }
        public async Task<SistemaNerviosoDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<SistemaNerviosoDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(SistemaNerviosoDto obj)
        {
            try
            {
                var req = _mapper.Map<SistemaNervioso>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(SistemaNerviosoDto obj)
        {
            try
            {
                var req = _mapper.Map<SistemaNervioso>(obj);
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
