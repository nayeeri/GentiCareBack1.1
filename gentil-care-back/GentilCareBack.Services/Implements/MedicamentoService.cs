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
    public class MedicamentoService : IMedicamentoService
    {
        private IMedicamentoRepository<Medicamento> repository = null;
        private readonly IMapper _mapper;
        public MedicamentoService(IMapper mapper) {
            this.repository = new MedicamentoRepository();
            this._mapper = mapper;
        }

        public async Task<List<MedicamentoDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<MedicamentoDto>>(result);
            return resp;
        }
        public async Task<MedicamentoDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<MedicamentoDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(MedicamentoDto obj)
        {
            try
            {
                var req = _mapper.Map<Medicamento>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(MedicamentoDto obj)
        {
            try
            {
                var req = _mapper.Map<Medicamento>(obj);
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
