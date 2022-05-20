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
    public class HoraService : IHoraService
    {
        private IHoraRepository<Horas> repository = null;
        private readonly IMapper _mapper;

        public HoraService(IMapper mapper)
        {
            this.repository = new HoraRepository();
            this._mapper = mapper;
        }

        public async Task<List<HorasDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<HorasDto>>(result);
            return resp;
        }


        public async Task<HorasDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<HorasDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(HorasDto obj, long idSemana)
        {
            try
            {
                var req = _mapper.Map<Horas>(obj);
                await repository.InsertAsync(req, idSemana);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(HorasDto obj)
        {
            try
            {
                var req = _mapper.Map<Horas>(obj);
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
