using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class SistemaDigestivoRepository: ISistemaDigestivoRepository<SistemaDigestivo>
    {
        private IGenericRepository<SistemaDigestivo> repository = null;

        public SistemaDigestivoRepository()
        {
            this.repository = new GenericRepository<SistemaDigestivo>();
        }

        public async Task<List<SistemaDigestivo>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<SistemaDigestivo> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(SistemaDigestivo obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(SistemaDigestivo obj)
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
