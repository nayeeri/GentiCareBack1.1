using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class EstudiosRepository : IEstudiosRepository<Estudios>
    {
        private IGenericRepository<Estudios> repository = null;

        public EstudiosRepository()
        {
            this.repository = new GenericRepository<Estudios>();
        }

        public async Task<List<Estudios>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<Estudios> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(Estudios obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(Estudios obj)
        {
            var tem = await GetByIdAsync(obj.EstudiosId);
            tem.descripcion = obj.descripcion;
            tem.estudio = obj.estudio;
            tem.nombre = obj.nombre;
            tem.identificador = obj.identificador;
            repository.UpdateAsync(tem);
            await repository.SaveAsync();
        }
        public async Task DeleteAsync(object id)
        {
            await repository.DeleteAsync(id);
            await repository.SaveAsync();
        }
    }
}
