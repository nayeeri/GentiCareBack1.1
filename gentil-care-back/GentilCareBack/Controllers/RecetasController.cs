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
    [Route("api/Recetas")]
    public class RecetasController : ControllerBase
    {
        private readonly IRecetasService _recetas;
        public RecetasController(IRecetasService recetas)
        {
            this._recetas = recetas;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _recetas.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _recetas.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(RecetasDto recetasDto)
        {
            return Ok(await _recetas.InsertAsync(recetasDto));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(RecetasDto recetasDto)
        {
            return Ok(await _recetas.UpdateAsync(recetasDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _recetas.GetByIdAsync(id));
        }
    }
}
