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
    public class PreguntasRepository : GenericRepository<Preguntas>,IPreguntasRepository<Preguntas>
    {
        private IGenericRepository<Preguntas> repository = null;

        public PreguntasRepository()
        {
            this.repository = new GenericRepository<Preguntas>();
        }

        public async new Task<List<Preguntas>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async new Task<Preguntas> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async new Task InsertAsync(Preguntas obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async new Task UpdateAsync(Preguntas obj)
        {
            repository.UpdateAsync(obj);
            await repository.SaveAsync();
        }
        public async new Task  DeleteAsync(object id)
        {
            await repository.DeleteAsync(id);
            await repository.SaveAsync();
        }

        public async Task DeleteUser(object id) {
            var result = await _context.Preguntas.Where(x => x.Users.UsersId == long.Parse(id.ToString())).FirstOrDefaultAsync();
            _context.Preguntas.Remove(result);
            await _context.SaveChangesAsync();
        }

    }
}
