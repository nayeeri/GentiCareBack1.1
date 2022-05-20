using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class SentidosRepository : ISentidosRepository<Sentidos>
    {
        private IGenericRepository<Sentidos> repository = null;

        public SentidosRepository()
        {
            this.repository = new GenericRepository<Sentidos>();
        }

        public async Task<List<Sentidos>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<Sentidos> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(Sentidos obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(Sentidos obj)
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
