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
    public class ProveedorRepository : GenericRepository<Proveedor>, IProveedorRepository<Proveedor>
    {
        private IGenericRepository<Proveedor> repository = null;
        private IAddressesRepository<Addresses> repositoryAdress = null;
        public ProveedorRepository() {
            this.repository = new GenericRepository<Proveedor>();
            this.repositoryAdress = new AddressesRepository();
        }

        public async new Task<List<Proveedor>> GetAllAsync()
        {
            //return await repository.GetAllAsync();
            return await _context.Proveedor.ToListAsync();
        }
        public async new Task<Proveedor> GetByIdAsync(object id)
        {
            //return await repository.GetByIdAsync(id);
            return await _context.Proveedor.Include(x=> x.Addresses).Where(x => x.ProveedorId == long.Parse(id.ToString())).FirstOrDefaultAsync();
        }

        [Obsolete]
        public async new Task InsertAsync(Proveedor obj)
        {
            //await repository.InsertAsync(obj);
            //await repository.SaveAsync();
            try
            {
                _context.Proveedor.Add(obj);
                await _context.SaveChangesAsync();

                //await repository.InsertAsync(obj);
                //await repository.SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async new Task UpdateAsync(Proveedor obj)
        {
            var tem = await GetByIdAsync(obj.ProveedorId);

            tem.cellphone = obj.cellphone;
            tem.costo = obj.costo;
            tem.email = obj.email;
            tem.estudio = obj.estudio;
            tem.provedor = obj.provedor;

            repository.UpdateAsync(tem);
            await repository.SaveAsync();
        }

        [Obsolete]
        public async new Task DeleteAsync(object id)
        {
            var tem = await _context.Proveedor.Include(x => x.Addresses).Where(x => x.ProveedorId == long.Parse(id.ToString())).FirstOrDefaultAsync();
            await repository.DeleteAsync(id);
            await repository.SaveAsync();
            await repositoryAdress.DeleteAsync(tem.Addresses.AddressesId);
            await repository.SaveAsync();
        }
    }
}
