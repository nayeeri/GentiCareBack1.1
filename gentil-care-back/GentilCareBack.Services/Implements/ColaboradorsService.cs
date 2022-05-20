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
    public class ColaboradorsService : IColaboradorsService
    {
        private IColaboradorsRepository<Colaboradors> repository = null;
        private readonly IMapper _mapper;

        public ColaboradorsService(IMapper mapper)
        {
            this.repository = new ColaboradorsRepository();
            this._mapper = mapper;
        }

        public async Task<List<ColaboradorsDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<ColaboradorsDto>>(result);
            return resp;
        }
        public async Task<ColaboradorsDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<ColaboradorsDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(ColaboradorsDto obj)
        {
            try
            {
                var req = _mapper.Map<Colaboradors>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public async Task<ColaboradorsDto> getUltimateRegister() {
            var result = await repository.getUltimateRegister();
            var resp = _mapper.Map<ColaboradorsDto>(result);
            return resp;
        }
        public async Task<bool> UpdateAsync(ColaboradorsDto obj)
        {
            try
            {
                var req = _mapper.Map<Colaboradors>(obj);
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
