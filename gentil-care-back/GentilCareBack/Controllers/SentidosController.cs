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
    [Route("api/Sentidos")]
    public class SentidosController : ControllerBase
    {
        private readonly ISentidosService _sentidosService;
        public SentidosController(ISentidosService sentidosService)
        {
            this._sentidosService = sentidosService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _sentidosService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _sentidosService.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(SentidosDto sentidosDto)
        {
            return Ok(await _sentidosService.InsertAsync(sentidosDto));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(SentidosDto sentidosDto)
        {
            return Ok(await _sentidosService.UpdateAsync(sentidosDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _sentidosService.GetByIdAsync(id));
        }
    }
}
