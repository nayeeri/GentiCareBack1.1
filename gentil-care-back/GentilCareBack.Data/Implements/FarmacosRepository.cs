using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class FarmacosRepository : IFarmacosRepository<Farmacos>
    {
        private IGenericRepository<Farmacos> repository = null;

        public FarmacosRepository()
        {
            this.repository = new GenericRepository<Farmacos>();
        }

        public async Task<List<Farmacos>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<Farmacos> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(Farmacos obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(Farmacos obj)
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
