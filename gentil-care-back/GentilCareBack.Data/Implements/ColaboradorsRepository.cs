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
    public class ColaboradorsRepository : GenericRepository<Colaboradors>, IColaboradorsRepository<Colaboradors>
    {
        private IGenericRepository<Colaboradors> repository = null;

        public ColaboradorsRepository()
        {
            this.repository = new GenericRepository<Colaboradors>();
        }

        public async new Task<List<Colaboradors>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async new Task<Colaboradors> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }

        [Obsolete]
        public async new Task InsertAsync(Colaboradors obj)
        {
            var result = await _context.Database.ExecuteSqlCommandAsync("INSERT Colaboradors(UsersId,costoConsulta,cedula,address_fiscal,rfc,especialidad," +
                "plataforma,tel_fijo,pacientes,observacion) VALUES ('" + obj.Users.UsersId + "','" +
                    obj.costoConsulta + "','" + obj.cedula + "','" + obj.address_fiscal + "','" + obj.rfc + "','" + obj.especialidad + "','" +
                    obj.plataforma + "','" + obj.tel_fijo + "','" + obj.pacientes + "','" + obj.observacion + "')");
            //await repository.InsertAsync(obj);
            //await repository.SaveAsync();
        }
        public async new Task UpdateAsync(Colaboradors obj)
        {
            repository.UpdateAsync(obj);
            await repository.SaveAsync();
        }
        public async new Task DeleteAsync(object id)
        {
            await repository.DeleteAsync(id);
            await repository.SaveAsync();
        }

        public async Task<Colaboradors> getUltimateRegister() {
            return await _context.Colaboradors.OrderByDescending(t => t.ColaboradorsId)
                .FirstOrDefaultAsync();
        }
    }
}
