using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class MotivosRepository : IMotivosRepository<Motivos>
    {
        private IGenericRepository<Motivos> repository = null;

        public MotivosRepository()
        {
            this.repository = new GenericRepository<Motivos>();
        }

        public async Task<List<Motivos>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<Motivos> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(Motivos obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(Motivos obj)
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
