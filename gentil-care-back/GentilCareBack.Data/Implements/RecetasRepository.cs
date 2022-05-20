using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class RecetasRepository : IRecetasRepository<Recetas>
    {
        private IGenericRepository<Recetas> repository = null;

        public RecetasRepository()
        {
            this.repository = new GenericRepository<Recetas>();
        }

        public async Task<List<Recetas>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<Recetas> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(Recetas obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(Recetas obj)
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
