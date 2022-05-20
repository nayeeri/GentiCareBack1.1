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
    public class EspecialidadsService: IEspecialidadsService
    {
        private IEspecialidadsRepository<Especialidads> repository = null;
        private readonly IMapper _mapper;

        public EspecialidadsService(IMapper mapper)
        {
            this.repository = new EspecialidadsRepository();
            this._mapper = mapper;
        }

        public async Task<List<EspecialidadsDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<EspecialidadsDto>>(result);
            return resp;
        }
        public async Task<EspecialidadsDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<EspecialidadsDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(EspecialidadsDto obj)
        {
            try
            {
                var req = _mapper.Map<Especialidads>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(EspecialidadsDto obj)
        {
            try
            {
                var req = _mapper.Map<Especialidads>(obj);
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
