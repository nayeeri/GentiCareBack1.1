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
    public class AuthsService : IAuthsService
    {
        private IAuthsRepository<Auths> repository = null;
        private readonly IMapper _mapper;

        public AuthsService(IMapper mapper)
        {
            this.repository = new AuthsRepository();
            this._mapper = mapper;
        }

        public async Task<List<AuthsDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<AuthsDto>>(result);
            return resp;
        }
        public async Task<AuthsDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<AuthsDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(AuthsDto obj)
        {
            try
            {
                var req = _mapper.Map<Auths>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(AuthsDto obj)
        {
            try
            {
                var req = _mapper.Map<Auths>(obj);
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

        public async Task<AuthsDto> validateUser(AuthsDto dto) {
            try
            {
                var res = _mapper.Map<Auths>(dto);
                var result =  repository.validateUser(res);
                if (result != null) {
                    var resp = _mapper.Map<AuthsDto>(result);
                    resp.status = true;
                    resp.token = "SKRUT5254";
                    return resp;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
