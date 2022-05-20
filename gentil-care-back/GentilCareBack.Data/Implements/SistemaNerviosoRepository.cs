using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class SistemaNerviosoRepository: ISistemaNerviosoRepository<SistemaNervioso>
    {
        private IGenericRepository<SistemaNervioso> repository = null;

        public SistemaNerviosoRepository()
        {
            this.repository = new GenericRepository<SistemaNervioso>();
        }

        public async Task<List<SistemaNervioso>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<SistemaNervioso> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(SistemaNervioso obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(SistemaNervioso obj)
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
