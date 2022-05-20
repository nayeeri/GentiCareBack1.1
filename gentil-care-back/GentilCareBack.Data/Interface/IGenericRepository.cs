using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Interface
{
    public interface IGenericRepository<T> where T : class
    {
        Task <List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task InsertAsync(T obj);
        void UpdateAsync(T obj);
        Task DeleteAsync(object id);
        Task  SaveAsync();
    }
}
