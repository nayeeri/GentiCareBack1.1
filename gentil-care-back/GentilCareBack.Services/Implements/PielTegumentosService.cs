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
    public class PielTegumentosService: IPielTegumentosService
    {
        private IPielTegumentosRepository<PielTegumentos> repository = null;
        private readonly IMapper _mapper;

        public PielTegumentosService(IMapper mapper)
        {
            this.repository = new PielTegumentosRepository();
            this._mapper = mapper;
        }

        public async Task<List<PielTegumentosDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<PielTegumentosDto>>(result);
            return resp;
        }
        public async Task<PielTegumentosDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<PielTegumentosDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(PielTegumentosDto obj)
        {
            try
            {
                var req = _mapper.Map<PielTegumentos>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(PielTegumentosDto obj)
        {
            try
            {
                var req = _mapper.Map<PielTegumentos>(obj);
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
