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
    [Route("api/Colaboradors")]
    public class ColaboradorsController : ControllerBase
    {
        private readonly IColaboradorsService _colaboradorsService;
        public ColaboradorsController(IColaboradorsService colaboradorsService)
        {
            this._colaboradorsService = colaboradorsService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _colaboradorsService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _colaboradorsService.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(ColaboradorsDto colaboradorsDto)
        {
            return Ok(await _colaboradorsService.InsertAsync(colaboradorsDto));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(ColaboradorsDto colaboradorsDto)
        {
            return Ok(await _colaboradorsService.UpdateAsync(colaboradorsDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _colaboradorsService.GetByIdAsync(id));
        }
    }
}
