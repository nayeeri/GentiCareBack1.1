using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class ServiciosRepository : GenericRepository<Servicios>,IServiciosRepository<Servicios>
    {
        private IGenericRepository<Servicios> repository = null;

        public ServiciosRepository()
        {
            this.repository = new GenericRepository<Servicios>();
        }

        public async new Task<List<Servicios>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async new Task<Servicios> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }

        [Obsolete]
        public async new Task InsertAsync(Servicios obj)
        {
            //await repository.InsertAsync(obj);
            //await repository.SaveAsync();

            try
            {
                var result = await _context.Database.ExecuteSqlCommandAsync("INSERT Servicios(nombre,costo,descripcion) VALUES ('" +
                    obj.nombre + "','" + obj.costo + "','" + obj.descripcion + "')");
                //await repository.InsertAsync(obj);
                //await repository.SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public async new Task UpdateAsync(Servicios obj)
        {
            var tem = await _context.Servicios.Where(x=> x.ServiciosId == obj.ServiciosId)
                .FirstOrDefaultAsync();

            tem.nombre = obj.nombre;
            tem.costo = obj.costo;
            tem.descripcion = obj.descripcion;

            repository.UpdateAsync(tem);
            await repository.SaveAsync();
        }
        public async new Task DeleteAsync(object id)
        {
            await repository.DeleteAsync(id);
            await repository.SaveAsync();
        }
    }
}
