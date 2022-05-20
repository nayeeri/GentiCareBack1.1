using GentilCareBack.Data.Interface;
using GentilCareBack.Models.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Data.Implements
{
    public class CardioVascularRepository : ICardioVascularRepository<CardioVascular>
    {
        private IGenericRepository<CardioVascular> repository = null;

        public CardioVascularRepository()
        {
            this.repository = new GenericRepository<CardioVascular>();
        }

        public async Task<List<CardioVascular>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task<CardioVascular> GetByIdAsync(object id)
        {
            return await repository.GetByIdAsync(id);
        }
        public async Task InsertAsync(CardioVascular obj)
        {
            await repository.InsertAsync(obj);
            await repository.SaveAsync();
        }
        public async Task UpdateAsync(CardioVascular obj)
        {
            repository.UpdateAsync(obj);
            await repository.SaveAsync();
        }
        public async Task DeleteAsync(object id)
        {
            await repository.DeleteAsync(id);
            await repository.SaveAsync();
        }
    }
}
