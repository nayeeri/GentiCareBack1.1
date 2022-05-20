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
    [Route("api/Interrogatorios")]
    public class InterrogatoriosController : ControllerBase
    {

        private readonly IInterrogatoriosService _interrogatoriosService;
        public InterrogatoriosController(IInterrogatoriosService interrogatoriosService)
        {
            this._interrogatoriosService = interrogatoriosService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _interrogatoriosService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _interrogatoriosService.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(InterrogatoriosDto interrogatorios)
        {
            return Ok(await _interrogatoriosService.InsertAsync(interrogatorios));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(InterrogatoriosDto interrogatorios)
        {
            return Ok(await _interrogatoriosService.UpdateAsync(interrogatorios));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _interrogatoriosService.GetByIdAsync(id));
        }
    }
}
