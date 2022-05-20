using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class SintomasGeneralesRepository : ISintomasGeneralesRepository<SintomasGenerales>
    {
        private IGenericRepository<SintomasGenerales> repository = null;

        public SintomasGeneralesRepository()
        {
            this.repository = new GenericRepository<SintomasGenerales>();
        }

        public async Task<List<SintomasGenerales>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<SintomasGenerales> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(SintomasGenerales obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(SintomasGenerales obj)
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
