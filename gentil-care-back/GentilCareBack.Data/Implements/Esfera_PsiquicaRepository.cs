using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class Esfera_PsiquicaRepository: IEsfera_PsiquicaRepository<Esfera_Psiquica>
    {
        private IGenericRepository<Esfera_Psiquica> repository = null;

        public Esfera_PsiquicaRepository()
        {
            this.repository = new GenericRepository<Esfera_Psiquica>();
        }

        public async Task<List<Esfera_Psiquica>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<Esfera_Psiquica> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(Esfera_Psiquica obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(Esfera_Psiquica obj)
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
