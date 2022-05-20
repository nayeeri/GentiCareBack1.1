using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class RolesRepository : IRolesRepository<Roles>
    {
        private IGenericRepository<Roles> repository = null;

        public RolesRepository()
        {
            this.repository = new GenericRepository<Roles>();
        }

        public async Task<List<Roles>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<Roles> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(Roles obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(Roles obj)
        {
            repository.UpdateAsync(obj);
            await repository.SaveAsync();
        }
        public async Task DeleteAsync(object id)
        {
            await repository.DeleteAsync(id);
            await repository.SaveAsync();
        }

        
    }
}
