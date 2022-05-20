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
    public class UsersService : IUsersService
    {
        private IUsersRepository<Users> repository = null;
        private IRolesRepository<Roles> repositoryRoles = null;
        private IPreguntasRepository<Preguntas> repositoryPreguntas = null;
        private IAuthsRepository<Auths> repositoryAuth = null;
        private readonly IMapper _mapper;

        public UsersService(IMapper mapper)
        {
            this.repository = new UsersRepository();
            this.repositoryRoles = new RolesRepository();
            this.repositoryPreguntas = new PreguntasRepository();
            this.repositoryAuth = new AuthsRepository();
            this._mapper = mapper;
        }

        public async Task<List<UsersDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<UsersDto>>(result);

            if (resp != null) {
                resp.ForEach(x =>
                {
                    x.status = true;
                });
            }
           

            return resp;
        }

        public async Task<UsersDto> GetByPinAndCorreoAsync(string pin, string email) {
            var tem = await repository.GetByPinAndCorreoAsync(pin, email);
            if (tem != null) {
                var temporal = await repositoryAuth.GetByIdAsync(tem.Auths.AuthsId);
                temporal.verified = true;
                await repositoryAuth.UpdateAsync(temporal);
                var resp = _mapper.Map<UsersDto>(tem);
                

                return resp;
            }
            return null;
        }

        public async Task<List<UsersDto>> GetAllColaboratorAsync() {
            var result = await repository.GetAllColaboratorAsync();
            var resp = _mapper.Map<List<UsersDto>>(result);

            if (resp != null)
            {
                resp.ForEach(x =>
                {
                    x.status = true;
                    x.password = "";
                });
            }
            return resp;
        }

        public async Task<List<UsersDto>> GetAllFamiliaresAsync(string id) {
            var result = await repository.GetAllFamiliaresAsync(id);
            var resp = _mapper.Map<List<UsersDto>>(result);

            if (resp != null)
            {
                resp.ForEach(x =>
                {
                    x._id = x.UsersId;
                    x.status = true;
                    x.password = "";
                });
            }
            return resp;
        }

        public async Task<UsersDto> getUltimateRegister() {
            var result = await repository.getUltimateRegister();
            var req = _mapper.Map<UsersDto>(result);
            return req;
        }
        public async Task<UsersDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<UsersDto>(result);
            resp.name = resp.nombre + " " + resp.A_P;
            resp.status = true;
            resp.token = "SKRUT5254";
           
            if (resp.auth != null)
                resp.role = resp.auth.Roles;

            return resp;
        }
        public async Task<UsersDto> InsertAsync(UsersDto obj)
        {
            try
            {
                var req = _mapper.Map<Users>(obj);
                await repository.InsertAsync(req);
                return obj;
            }
            catch (Exception ex)
            {
                return null;
            }

        }


        public async Task<bool> UpdateAsync(UsersDto obj)
        {
            try
            {
                
                var req = _mapper.Map<Users>(obj);
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
                var result = await GetByIdAsync(id);

                await repositoryAuth.DeleteAsync(result.auth.AuthsId);
                await repositoryPreguntas.DeleteUser(result.UsersId);

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
