using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Persistencia;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        public dbContextDataBase _context = null;
        private DbSet<T> table = null;
        public GenericRepository()
        {
            this._context = new dbContextDataBase();
            table = _context.Set<T>();
        }
        public GenericRepository(dbContextDataBase _context)
        {
            this._context = _context;
            table = _context.Set<T>();
        }
        public async Task<List<T>> GetAllAsync()
        {
            return await table.ToListAsync();
        }
        public async Task<T> GetByIdAsync(object id)
        {
            return await table.FindAsync(id);
        }
        public async Task InsertAsync(T obj)
        {
            await table.AddAsync(obj);
        }
        public void UpdateAsync(T obj)
        {
            table.Attach(obj);
            _context.Entry(obj).State = EntityState.Modified;
        }
        public async Task DeleteAsync(object id)
        {
            T existing = await table.FindAsync(id);
            table.Remove(existing);
        }
        public async Task SaveAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
