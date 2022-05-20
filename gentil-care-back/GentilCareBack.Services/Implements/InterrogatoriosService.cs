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
    public class InterrogatoriosService: IInterrogatoriosService
    {
        private IInterrogatoriosRepository<Interrogatorios> repository = null;
        private readonly IMapper _mapper;

        public InterrogatoriosService(IMapper mapper)
        {
            this.repository = new InterrogatoriosRepository();
            this._mapper = mapper;
        }

        public async Task<List<InterrogatoriosDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<InterrogatoriosDto>>(result);
            return resp;
        }
        public async Task<InterrogatoriosDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<InterrogatoriosDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(InterrogatoriosDto obj)
        {
            try
            {
                var req = _mapper.Map<Interrogatorios>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(InterrogatoriosDto obj)
        {
            try
            {
                var req = _mapper.Map<Interrogatorios>(obj);
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
