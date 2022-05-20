using AutoMapper;
using GentilCareBack.Data.Implements;
using GentilCareBack.Data.Interface;
using GentilCareBack.Dto;
using GentilCareBack.Models.Entity;
using GentilCareBack.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GentilCareBack.Services.Implements
{
    public class CardioVascularService : ICardioVascularService
    {
        private ICardioVascularRepository<CardioVascular> repository = null;
        private readonly IMapper _mapper;

        public CardioVascularService(IMapper mapper)
        {
            this.repository = new CardioVascularRepository();
            this._mapper = mapper;
        }

        public async Task<List<CardioVascularDto>> GetAllAsync()
        {
            var result = await repository.GetAllAsync();
            var resp = _mapper.Map<List<CardioVascularDto>>(result);
            return resp;
        }
        public async Task<CardioVascularDto> GetByIdAsync(object id)
        {
            var result = await repository.GetByIdAsync(id);
            var resp = _mapper.Map<CardioVascularDto>(result);
            return resp;
        }
        public async Task<bool> InsertAsync(CardioVascularDto obj)
        {
            try
            {
                var req = _mapper.Map<CardioVascular>(obj);
                await repository.InsertAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        public async Task<bool> UpdateAsync(CardioVascularDto obj)
        {
            try
            {
                var req = _mapper.Map<CardioVascular>(obj);
                await repository.UpdateAsync(req);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DeleteAsync(object id)
        {
            try
            {
                await repository.DeleteAsync(id);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}
