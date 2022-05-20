﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Interface
{
    public interface IUsersRepository<T>
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(object id);
        Task InsertAsync(T obj);
        Task UpdateAsync(T obj);
        Task DeleteAsync(object id);

        Task<T> getUltimateRegister();

        Task<List<T>> GetAllColaboratorAsync();
        Task<List<T>> GetAllFamiliaresAsync(string id);

        Task<T> GetByPinAndCorreoAsync(string pin, string email);
    }
}
