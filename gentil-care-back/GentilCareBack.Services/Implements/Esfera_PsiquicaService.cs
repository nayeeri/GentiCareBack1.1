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
    public class Esfera_PsiquicaService : IEsfera_PsiquicaService
    {
        private IEsfera_PsiquicaRepository<Esfera_Psiquica> repository = null;
        private readonly IMapper _mapper;

        public Esfera_PsiquicaService(IMapper mapper)
        {
            this.repository = new Esfera_PsiquicaRepository();
            this._mapper = mapper;
        }

        public async Task<List<Esfera_PsiquicaDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<Esfera_PsiquicaDto>>(result);
            return resp;
        }
        public async Task<Esfera_PsiquicaDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<Esfera_PsiquicaDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(Esfera_PsiquicaDto obj)
        {
            try
            {
                var req = _mapper.Map<Esfera_Psiquica>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(Esfera_PsiquicaDto obj)
        {
            try
            {
                var req = _mapper.Map<Esfera_Psiquica>(obj);
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
