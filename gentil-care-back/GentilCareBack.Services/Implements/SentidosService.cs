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
    public class SentidosService: ISentidosService
    {
        private ISentidosRepository<Sentidos> repository = null;
        private readonly IMapper _mapper;

        public SentidosService(IMapper mapper)
        {
            this.repository = new SentidosRepository();
            this._mapper = mapper;
        }

        public async Task<List<SentidosDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<SentidosDto>>(result);
            return resp;
        }
        public async Task<SentidosDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<SentidosDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(SentidosDto obj)
        {
            try
            {
                var req = _mapper.Map<Sentidos>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(SentidosDto obj)
        {
            try
            {
                var req = _mapper.Map<Sentidos>(obj);
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
