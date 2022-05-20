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
    [Route("api/Servicios")]
    public class ServiciosController : ControllerBase
    {
        private readonly IServiciosService _serviciosService;
        public ServiciosController(IServiciosService serviciosService)
        {
            this._serviciosService = serviciosService;
        }

        [HttpGet("listaServicios")]
        public async Task<ActionResult> getDatas()
        {
            var result = await _serviciosService.GetAllAsync();
            ResponseServiciosDto response = new ResponseServiciosDto();
            response.lista = result;
            response.status = true;
            return Ok(response);
        }

        [HttpGet("muestraServicio/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            var result = await _serviciosService.GetByIdAsync(id);
            ResponseServiciosOne response = new ResponseServiciosOne();
            response.servicio = result;
            response.status = true;
            return Ok(response);
        }

        [HttpPost("crearServicio")]
        public async Task<ActionResult> add(RequestAddServicios serviciosDtoReq)
        {
            var ServiciosDto = serviciosDtoReq.data;
            return Ok(await _serviciosService.InsertAsync(ServiciosDto));
        }

        [HttpPut("editaServicio/{id}")]
        public async Task<ActionResult> edit(ServiciosDto serviciosDto, long id)
        {
            serviciosDto.ServiciosId = id;
            return Ok(await _serviciosService.UpdateAsync(serviciosDto));
        }

        [HttpDelete("eliminarServicio/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _serviciosService.DeleteAsync(id));
        }
    }
}
