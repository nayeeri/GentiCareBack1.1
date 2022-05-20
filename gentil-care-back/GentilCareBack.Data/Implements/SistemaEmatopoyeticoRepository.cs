using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class SistemaEmatopoyeticoRepository: ISistemaEmatopoyeticoRepository<SistemaEmatopoyetico>
    {
        private IGenericRepository<SistemaEmatopoyetico> repository = null;

        public SistemaEmatopoyeticoRepository()
        {
            this.repository = new GenericRepository<SistemaEmatopoyetico>();
        }

        public async Task<List<SistemaEmatopoyetico>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<SistemaEmatopoyetico> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(SistemaEmatopoyetico obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(SistemaEmatopoyetico obj)
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
