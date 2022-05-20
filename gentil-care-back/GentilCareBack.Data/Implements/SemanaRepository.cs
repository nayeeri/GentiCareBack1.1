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
    public class SemanaRepository : GenericRepository<Semana> , ISemanaRepository<Semana>
    {
        private IGenericRepository<Semana> repository = null;

        public SemanaRepository()
        {
            this.repository = new GenericRepository<Semana>();
        }

        public async new Task<List<Semana>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async new Task<Semana> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }

        public async Task<Semana> getUltimateRegister()
        {
            return await _context.Semana.OrderByDescending(t => t.SemanaId)
                .FirstOrDefaultAsync();
        }

        //[Obsolete]
        [Obsolete]
        public async new Task InsertAsync(Semana obj)
        {
            var result = await _context.Database.ExecuteSqlCommandAsync("INSERT Semana(ColaboradorsId) VALUES ('" +
                    obj.Colaboradors.ColaboradorsId + "')");
            /*
            _context.Semana.Add(obj);
            var result = await _context.SaveChangesAsync();
            */

            //obj.Users = tem;
            //_context.Entry(obj).State = EntityState.Detached;

            /*
            await repository.InsertAsync(obj);
            try
            {
                await repository.SaveAsync();
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }*/

        }
        public async new Task UpdateAsync(Semana obj)
        {
            repository.UpdateAsync(obj);
            await repository.SaveAsync();
        }
        public async new Task DeleteAsync(object id)
        {
            await repository.DeleteAsync(id);
            await repository.SaveAsync();
        }

    }
}
