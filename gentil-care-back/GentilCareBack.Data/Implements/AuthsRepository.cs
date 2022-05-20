using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Linq;
using System.Data;
using Microsoft.EntityFrameworkCore;

namespace GentilCareBack.Data.Implements
{
    public class AuthsRepository : GenericRepository<Auths>, IAuthsRepository<Auths>
    {
        private IGenericRepository<Auths> repository = null;

        public AuthsRepository()
        {
            this.repository = new GenericRepository<Auths>();
        }

        public async new Task<List<Auths>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async new Task<Auths> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }

        [Obsolete]
        public async new Task InsertAsync(Auths obj)
        {
            try
            {
                var result = await _context.Database.ExecuteSqlCommandAsync("INSERT Auths(RolesId,username,password,verified,UsersId) VALUES ('" +
                    obj.Roles.RolesId + "','" + obj.username + "','" + obj.password + "','" + obj.verified + "','" + obj.UsersId + "')");
                //await repository.InsertAsync(obj);
                //await repository.SaveAsync();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            
        }
        public async new Task UpdateAsync(Auths obj)
        {
            var tem = await GetByIdAsync(obj.AuthsId);
            tem.password = obj.password;
            tem.verified = obj.verified;
            repository.UpdateAsync(tem);
            await repository.SaveAsync();
        }
        public async new Task DeleteAsync(object id)
        {
            //var result = GetByIdAsync(id);
            await repository.DeleteAsync(id);
            await repository.SaveAsync();
        }

        public Auths validateUser(Auths obj)
        {
            var result = _context.Auths.Where(x => x.username.Equals(obj.username) && x.password.Equals(obj.password)).Include(x=>x.Roles)
                .FirstOrDefault();
            return result;
        }
    }
}
