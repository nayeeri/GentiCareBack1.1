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
    public class AddressesRepository: GenericRepository<Addresses> , IAddressesRepository<Addresses>
    {

        private IGenericRepository<Addresses> repository = null;

        public AddressesRepository()
        {
            this.repository = new GenericRepository<Addresses>();
        }

        public async new Task<List<Addresses>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async new Task<Addresses> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }

        [Obsolete]
        public async new Task InsertAsync(Addresses obj)
        {
            
            var result = await _context.Database.ExecuteSqlCommandAsync("INSERT Addresses(UsersId,calle,exterior,interior,colonia,municipio,ciudad,estado,cp) VALUES ('" +
                    obj.Users.UsersId + "','" + obj.calle + "','" + obj.exterior + "','" + obj.interior+ "','" + obj.colonia + "','" + obj.municipio + "','" + obj.ciudad + "','" + obj.estado + "','" + obj.cp + "')");
           

            //var tem = await _context.Users.Where(x => x.UsersId == obj.Users.UsersId).FirstOrDefaultAsync();

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
        public async new Task UpdateAsync(Addresses obj)
        {
            repository.UpdateAsync(obj);
            await repository.SaveAsync();
        }
        public async new Task DeleteAsync(object id)
        {
            await repository.DeleteAsync(id);
            await repository.SaveAsync();
        }

        public async Task<List<Addresses>> getListAddressUser(long idUser) {
            return await _context.Addresses.Where(x => x.Users.UsersId == idUser).ToListAsync();
        }

    }
}
