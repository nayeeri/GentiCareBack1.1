using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class HoraRepository : GenericRepository<Horas>, IHoraRepository<Horas>
    {
        private IGenericRepository<Horas> repository = null;

        public HoraRepository()
        {
            this.repository = new GenericRepository<Horas>();
        }

        public async new Task<List<Horas>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async new Task<Horas> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }


        [Obsolete]
        public async  Task InsertAsync(Horas obj, long idSemana )
        {
            try
            {
                var result = await _context.Database.ExecuteSqlCommandAsync("INSERT Horas(cero,una,dos,tres,cuatro,cinco," +
                "seis,siete,ocho,nueve,diez,once,doce,trece,catorce,quince,dieciseis,diecisiete,dieciocho,diecinueve,veinte," +
                "veintiuno,veintidos,veintitres,SemanaId,dia) VALUES ('" + obj.cero + "','" +
                    obj.una + "','" + obj.dos + "','" + obj.tres + "','" + obj.cuatro + "','" + obj.cinco + "','" +
                    obj.seis + "','" + obj.siete + "','" + obj.ocho + "','" + obj.nueve + "','" + obj.diez + "','" + obj.once +
                    "','" + obj.doce + "','" + obj.trece + "','" + obj.catorce + "','" + obj.quince + "','" + obj.dieciseis +
                    "','" + obj.diecisiete + "','" + obj.dieciocho + "','" + obj.diecinueve + "','" + obj.veinte + "','" + obj.veintiuno +
                    "','" + obj.veintidos + "','" + obj.veintitres + "','" + idSemana + "','" + obj.dia + "')");
            }
            catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
            
            /*
            _context.Horas.Add(obj);
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
        public async new Task UpdateAsync(Horas obj)
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
