using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class SistemaEndocrinoRepository : ISistemaEndocrinoRepository<SistemaEndocrino>
    {
        private IGenericRepository<SistemaEndocrino> repository = null;

        public SistemaEndocrinoRepository()
        {
            this.repository = new GenericRepository<SistemaEndocrino>();
        }

        public async Task<List<SistemaEndocrino>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<SistemaEndocrino> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(SistemaEndocrino obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(SistemaEndocrino obj)
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
