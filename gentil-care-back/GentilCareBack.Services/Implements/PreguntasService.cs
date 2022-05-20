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
    public class PreguntasService : IPreguntasService
    {
        private IPreguntasRepository<Preguntas> repository = null;
        private readonly IMapper _mapper;

        public PreguntasService(IMapper mapper)
        {
            this.repository = new PreguntasRepository();
            this._mapper = mapper;
        }

        public async Task<List<PreguntasDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<PreguntasDto>>(result);
            return resp;
        }
        public async Task<PreguntasDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<PreguntasDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(PreguntasDto obj)
        {
            try
            {
                var req = _mapper.Map<Preguntas>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(PreguntasDto obj)
        {
            try
            {
                var req = _mapper.Map<Preguntas>(obj);
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
