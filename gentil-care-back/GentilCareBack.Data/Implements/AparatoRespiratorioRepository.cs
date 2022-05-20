using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class AparatoRespiratorioRepository : IAparatoRespiratorioRepository<AparatoRespiratorio>
    {
        private IGenericRepository<AparatoRespiratorio> repository = null;

        public AparatoRespiratorioRepository()
        {
            this.repository = new GenericRepository<AparatoRespiratorio>();
        }

        public async Task<List<AparatoRespiratorio>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<AparatoRespiratorio> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(AparatoRespiratorio obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(AparatoRespiratorio obj)
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
