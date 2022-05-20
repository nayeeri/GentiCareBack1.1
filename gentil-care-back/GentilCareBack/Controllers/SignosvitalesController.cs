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
    [Route("api/Signosvitales")]
    public class SignosvitalesController : ControllerBase
    {
        private readonly ISignosvitalesService _signosvitalesService;
        public SignosvitalesController(ISignosvitalesService signosvitalesService)
        {
            this._signosvitalesService = signosvitalesService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _signosvitalesService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _signosvitalesService.GetByIdAsync(id));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(SignosvitalesDto signosvitalesDto)
        {
            return Ok(await _signosvitalesService.InsertAsync(signosvitalesDto));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(SignosvitalesDto signosvitalesDto)
        {
            return Ok(await _signosvitalesService.UpdateAsync(signosvitalesDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _signosvitalesService.GetByIdAsync(id));
        }
    }
}
