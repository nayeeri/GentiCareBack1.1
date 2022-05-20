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
    [Route("api/Preguntas")]
    public class PreguntasController : ControllerBase
    {
        private readonly IPreguntasService _preguntasService;
        public PreguntasController(IPreguntasService preguntasService)
        {
            this._preguntasService = preguntasService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _preguntasService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _preguntasService.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(PreguntasDto preguntasDto)
        {
            return Ok(await _preguntasService.InsertAsync(preguntasDto));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(PreguntasDto preguntasDto)
        {
            return Ok(await _preguntasService.UpdateAsync(preguntasDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _preguntasService.GetByIdAsync(id));
        }
    }
}
