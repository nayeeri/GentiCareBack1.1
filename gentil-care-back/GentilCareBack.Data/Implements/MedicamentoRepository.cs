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
    public class MedicamentoRepository : GenericRepository<Medicamento>, IMedicamentoRepository<Medicamento>
    {
        private IGenericRepository<Medicamento> repository = null;
        public MedicamentoRepository()
        {
            this.repository = new GenericRepository<Medicamento>();
        }

        public async new Task<List<Medicamento>> GetAllAsync()
        {
            //return await repository.GetAllAsync();
            return await _context.Medicamento.ToListAsync();
        }
        public async new Task<Medicamento> GetByIdAsync(object id)
        {
            //return await repository.GetByIdAsync(id);
            return await _context.Medicamento.Where(x => x.MedicamentoId == long.Parse(id.ToString())).FirstOrDefaultAsync();
        }

        [Obsolete]
        public async new Task InsertAsync(Medicamento obj)
        {
            //await repository.InsertAsync(obj);
            //await repository.SaveAsync();
            try
            {
                _context.Medicamento.Add(obj);
                await _context.SaveChangesAsync();

                //await repository.InsertAsync(obj);
                //await repository.SaveAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public async new Task UpdateAsync(Medicamento obj)
        {
            var tem = await GetByIdAsync(obj.MedicamentoId);

            tem.descripcion = obj.descripcion;
            tem.farmaco = obj.farmaco;
            tem.nombre_quimico = obj.nombre_quimico;

            repository.UpdateAsync(tem);
            await repository.SaveAsync();
        }

        [Obsolete]
        public async new Task DeleteAsync(object id)
        {

            await repository.DeleteAsync(id);
            await repository.SaveAsync();
        }
    }
}
