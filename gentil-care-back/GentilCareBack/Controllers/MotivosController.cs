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
    [Route("api/Motivos")]
    public class MotivosController : ControllerBase
    {
        private readonly IMotivosService _motivosService;
        public MotivosController(IMotivosService motivosService)
        {
            this._motivosService = motivosService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _motivosService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _motivosService.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(MotivosDto motivosDto)
        {
            return Ok(await _motivosService.InsertAsync(motivosDto));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(MotivosDto motivosDto)
        {
            return Ok(await _motivosService.UpdateAsync(motivosDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _motivosService.GetByIdAsync(id));
        }
    }
}
