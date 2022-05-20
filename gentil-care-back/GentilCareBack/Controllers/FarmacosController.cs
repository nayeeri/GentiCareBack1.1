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
    [Route("api/Farmacos")]
    public class FarmacosController : ControllerBase
    {
        private readonly IFarmacosService _farmacosService;
        public FarmacosController(IFarmacosService farmacosService)
        {
            this._farmacosService = farmacosService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _farmacosService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _farmacosService.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(FarmacosDto farmacosDto)
        {
            return Ok(await _farmacosService.InsertAsync(farmacosDto));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(FarmacosDto farmacosDto)
        {
            return Ok(await _farmacosService.UpdateAsync(farmacosDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _farmacosService.GetByIdAsync(id));
        }
    }
}
