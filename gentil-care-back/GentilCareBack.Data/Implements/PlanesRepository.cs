using GentilCareBack.Data.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using GentilCareBack.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace GentilCareBack.Data.Implements
{
    public class PlanesRepository: GenericRepository<Planes>, IPlanesRepository<Planes>
    {
        private IGenericRepository<Planes> repository = null;
        private IServiciosRepository<Servicios> repositoryServicios = null;

        public PlanesRepository()
        {
            this.repository = new GenericRepository<Planes>();
            this.repositoryServicios = new ServiciosRepository();
        }

        public async new Task<List<Planes>> GetAllAsync()
        {
            //return await repository.GetAllAsync();
            return await _context.Planes.Include(x => x.Servicios).ToListAsync();
        }
        public async new Task<Planes> GetByIdAsync(object id)
        {
            //return await repository.GetByIdAsync(id);
            return await _context.Planes.Include(x => x.Servicios).Where(x => x.PlanesId == long.Parse(id.ToString())).FirstOrDefaultAsync();
        }

        [Obsolete]
        public async new Task InsertAsync(Planes obj)
        {
            //await repository.InsertAsync(obj);
            //await repository.SaveAsync();
            try
            {
                var result = await _context.Database.ExecuteSqlCommandAsync("INSERT Planes(costo,descripcion,nombre) VALUES ('" +
                    obj.costo + "','" + obj.descripcion + "','" + obj.nombre + "')");

                var r =  await _context.Planes.OrderByDescending(t => t.PlanesId)
                .FirstOrDefaultAsync();

                if (obj.Servicios != null) {

                    foreach (var dat in obj.Servicios) {
                        var res = await _context.Database.ExecuteSqlCommandAsync("UPDATE  Servicios SET PlanesId='" +
                        r.PlanesId + "' WHERE ServiciosId='" + dat.ServiciosId + "'");
                    } 
                }
                

                //await repository.InsertAsync(obj);
                //await repository.SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async new Task UpdateAsync(Planes obj)
        {
            repository.UpdateAsync(obj);
            await repository.SaveAsync();
        }

        [Obsolete]
        public async  new Task DeleteAsync(object id)
        {
            var r = await _context.Planes.Include(x=> x.Servicios).Where(t => t.PlanesId == long.Parse(id.ToString()) )
                .FirstOrDefaultAsync();

            if (r.Servicios != null)
            {

                foreach (var dat in r.Servicios)
                {
                    try
                    {
                        var tem = await _context.Servicios.Include(x => x.Planes).FirstOrDefaultAsync(x => x.ServiciosId == dat.ServiciosId);
                        tem.Planes = null;
                        await _context.SaveChangesAsync();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    
                }
            }

            await repository.DeleteAsync(id);
            await repository.SaveAsync();
        }
    }
}
