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
    public class SignosvitalesService: ISignosvitalesService
    {
        private ISignosvitalesRepository<Signosvitales> repository = null;
        private readonly IMapper _mapper;

        public SignosvitalesService(IMapper mapper)
        {
            this.repository = new SignosvitalesRepository();
            this._mapper = mapper;
        }

        public async Task<List<SignosvitalesDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<SignosvitalesDto>>(result);
            return resp;
        }
        public async Task<SignosvitalesDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<SignosvitalesDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(SignosvitalesDto obj)
        {
            try
            {
                var req = _mapper.Map<Signosvitales>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(SignosvitalesDto obj)
        {
            try
            {
                var req = _mapper.Map<Signosvitales>(obj);
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
