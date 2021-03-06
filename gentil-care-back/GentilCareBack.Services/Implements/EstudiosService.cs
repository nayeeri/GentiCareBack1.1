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
    public class EstudiosService : IEstudiosService
    {
        private IEstudiosRepository<Estudios> repository = null;
        private readonly IMapper _mapper;

        public EstudiosService(IMapper mapper)
        {
            this.repository = new EstudiosRepository();
            this._mapper = mapper;
        }

        public async Task<List<EstudiosDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<EstudiosDto>>(result);
            return resp;
        }
        public async Task<EstudiosDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<EstudiosDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(EstudiosDto obj)
        {
            try
            {
                var req = _mapper.Map<Estudios>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(EstudiosDto obj)
        {
            try
            {
                var req = _mapper.Map<Estudios>(obj);
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
