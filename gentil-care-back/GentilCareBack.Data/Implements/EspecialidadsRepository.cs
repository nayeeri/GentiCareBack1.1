using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class EspecialidadsRepository : IEspecialidadsRepository<Especialidads>
    {
        private IGenericRepository<Especialidads> repository = null;

        public EspecialidadsRepository()
        {
            this.repository = new GenericRepository<Especialidads>();
        }

        public async Task<List<Especialidads>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<Especialidads> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(Especialidads obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(Especialidads obj)
        {
            var result = await  GetByIdAsync(obj.EspecialidadsId);
            result.especialidad = obj.especialidad;
            result.costo = obj.costo;
            repository.UpdateAsync(result);
            await repository.SaveAsync();
        }
        public async Task DeleteAsync(object id)
        {
            await repository.DeleteAsync(id);
            await repository.SaveAsync();
        }
    }
}
