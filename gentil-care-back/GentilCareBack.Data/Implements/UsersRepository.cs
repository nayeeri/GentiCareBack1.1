using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GentilCareBack.Data.Implements
{
    public class UsersRepository : GenericRepository<Users>, IUsersRepository<Users>
    {
        private IGenericRepository<Users> repository = null;

        public UsersRepository()
        {
            this.repository = new GenericRepository<Users>();
        }

        public new async Task<List<Users>> GetAllAsync()
        {
            var result = await _context.Users
                .Include(x => x.Auths)
                .Include(x=> x.Auths.Roles) .ToListAsync();
            return result;
            //return await repository.GetAllAsync();
        }

        public  async Task<List<Users>> GetAllColaboratorAsync()
        {
            var result = await _context.Users
                .Include(x => x.Auths)
                .Include(x => x.Auths.Roles).Where(x => x.Auths.Roles.role.Equals("Colaborador")).ToListAsync();
            return result;
            //return await repository.GetAllAsync();
        }

        public async Task<List<Users>> GetAllFamiliaresAsync(string id)
        {
            var result = await _context.Users
                .Include(x => x.Auths)
                .Include(x => x.Auths.Roles).Where(x => x.customerID.Equals(id) ).ToListAsync();
            return result;
            //return await repository.GetAllAsync();
        }

        public async Task<Users> getUltimateRegister() { 
            return await _context.Users
                .Include(x => x.Auths)
                .Include(x => x.Auths.Roles).OrderByDescending(t => t.UsersId)
                .FirstOrDefaultAsync();
        }
        public new async Task<Users> GetByIdAsync(object id)
        {
            //return await repository.GetByIdAsync(id);
            return await _context.Users.Where(x=> x.UsersId == long.Parse( id.ToString()))
                .Include(x => x.Auths)
                .Include(x => x.Auths.Roles)
                .FirstOrDefaultAsync();
        }
        public new async Task InsertAsync(Users obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public new async Task UpdateAsync(Users obj)
        {
            var tem =  await _context.Users.Where(x => x.UsersId == obj.UsersId)
                .Include(x => x.Auths)
                .Include(x => x.Auths.Roles)
                .FirstOrDefaultAsync();

            tem.email = obj.email;
            tem.cellphone = obj.cellphone;
            repository.UpdateAsync(tem);

            await repository.SaveAsync();
        }
        public new async Task DeleteAsync(object id)
        {
            //var tem = await GetByIdAsync(id);
            await repository.DeleteAsync(id);
            await repository.SaveAsync();
        }
    }
}
