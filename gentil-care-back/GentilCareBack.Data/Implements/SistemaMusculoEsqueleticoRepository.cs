using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class SistemaMusculoEsqueleticoRepository: ISistemaMusculoEsqueleticoRepository<SistemaMusculoEsqueletico>
    {
        private IGenericRepository<SistemaMusculoEsqueletico> repository = null;

        public SistemaMusculoEsqueleticoRepository()
        {
            this.repository = new GenericRepository<SistemaMusculoEsqueletico>();
        }

        public async Task<List<SistemaMusculoEsqueletico>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<SistemaMusculoEsqueletico> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(SistemaMusculoEsqueletico obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(SistemaMusculoEsqueletico obj)
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
