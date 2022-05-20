using GentilCareBack.Dto;
using GentilCareBack.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GentilCareBack.Controllers
{
    [ApiController]
    [Route("api/CardioVascular")]
    public class CardioVascularController : ControllerBase
    {
        private readonly ICardioVascularService _cardioVascularService;
        public CardioVascularController(ICardioVascularService cardioVascularService)
        {
            this._cardioVascularService = cardioVascularService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _cardioVascularService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _cardioVascularService.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(CardioVascularDto cardioVascularDto)
        {
            return Ok(await _cardioVascularService.InsertAsync(cardioVascularDto));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(CardioVascularDto cardioVascularDto)
        {
            return Ok(await _cardioVascularService.UpdateAsync(cardioVascularDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _cardioVascularService.GetByIdAsync(id));
        }
    }
}
