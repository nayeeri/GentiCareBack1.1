using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class PielTegumentosRepository : IPielTegumentosRepository<PielTegumentos>
    {
        private IGenericRepository<PielTegumentos> repository = null;

        public PielTegumentosRepository()
        {
            this.repository = new GenericRepository<PielTegumentos>();
        }

        public async Task<List<PielTegumentos>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<PielTegumentos> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(PielTegumentos obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(PielTegumentos obj)
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
