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
    public class SintomasGeneralesService : ISintomasGeneralesService
    {
        private ISintomasGeneralesRepository<SintomasGenerales> repository = null;
        private readonly IMapper _mapper;

        public SintomasGeneralesService(IMapper mapper)
        {
            this.repository = new SintomasGeneralesRepository();
            this._mapper = mapper;
        }

        public async Task<List<SintomasGeneralesDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<SintomasGeneralesDto>>(result);
            return resp;
        }
        public async Task<SintomasGeneralesDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<SintomasGeneralesDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(SintomasGeneralesDto obj)
        {
            try
            {
                var req = _mapper.Map<SintomasGenerales>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(SintomasGeneralesDto obj)
        {
            try
            {
                var req = _mapper.Map<SintomasGenerales>(obj);
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
