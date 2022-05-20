using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class SignosvitalesRepository: ISignosvitalesRepository<Signosvitales>
    {
        private IGenericRepository<Signosvitales> repository = null;

        public SignosvitalesRepository()
        {
            this.repository = new GenericRepository<Signosvitales>();
        }

        public async Task<List<Signosvitales>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<Signosvitales> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(Signosvitales obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(Signosvitales obj)
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
