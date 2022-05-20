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
    public class RecetasService : IRecetasService
    {
        private IRecetasRepository<Recetas> repository = null;
        private readonly IMapper _mapper;

        public RecetasService(IMapper mapper)
        {
            this.repository = new RecetasRepository();
            this._mapper = mapper;
        }

        public async Task<List<RecetasDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<RecetasDto>>(result);
            return resp;
        }
        public async Task<RecetasDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<RecetasDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(RecetasDto obj)
        {
            try
            {
                var req = _mapper.Map<Recetas>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(RecetasDto obj)
        {
            try
            {
                var req = _mapper.Map<Recetas>(obj);
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
