using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class ColaboradorsRepository : IColaboradorsRepository<Colaboradors>
    {
        private IGenericRepository<Colaboradors> repository = null;

        public ColaboradorsRepository()
        {
            this.repository = new GenericRepository<Colaboradors>();
        }

        public async Task<List<Colaboradors>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<Colaboradors> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(Colaboradors obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(Colaboradors obj)
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
