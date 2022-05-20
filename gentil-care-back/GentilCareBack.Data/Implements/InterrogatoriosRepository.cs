using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class InterrogatoriosRepository : IInterrogatoriosRepository<Interrogatorios>
    {
        private IGenericRepository<Interrogatorios> repository = null;

        public InterrogatoriosRepository()
        {
            this.repository = new GenericRepository<Interrogatorios>();
        }

        public async Task<List<Interrogatorios>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<Interrogatorios> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(Interrogatorios obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(Interrogatorios obj)
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
