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
    [Route("api/SintomasGenerales")]
    public class SintomasGeneralesController : ControllerBase
    {
        private readonly ISintomasGeneralesService _sintomasGeneralesService;
        public SintomasGeneralesController(ISintomasGeneralesService sintomasGeneralesService)
        {
            this._sintomasGeneralesService = sintomasGeneralesService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _sintomasGeneralesService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _sintomasGeneralesService.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(SintomasGeneralesDto sintomasGeneralesDto)
        {
            return Ok(await _sintomasGeneralesService.InsertAsync(sintomasGeneralesDto));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(SintomasGeneralesDto sintomasGeneralesDto)
        {
            return Ok(await _sintomasGeneralesService.UpdateAsync(sintomasGeneralesDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _sintomasGeneralesService.GetByIdAsync(id));
        }
    }
}
