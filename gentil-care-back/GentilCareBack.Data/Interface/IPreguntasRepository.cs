using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Interface
{
    public interface IPreguntasRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task InsertAsync(T obj);
        Task UpdateAsync(T obj);
        Task DeleteAsync(object id);
        Task DeleteUser(object id);
    }
}
