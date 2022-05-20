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
    [Route("api/Estudios")]
    public class EstudiosController : ControllerBase
    {
        private readonly IEstudiosService _estudiosService;
        public EstudiosController(IEstudiosService estudiosService)
        {
            this._estudiosService = estudiosService;
        }

        [HttpGet("listaEstudios")]
        public async Task<ActionResult> getDatas()
        {
            ResponseEstudiosList response = new ResponseEstudiosList();
            
            response.lista = await _estudiosService.GetAllAsync();
            if (response.lista != null)
            {
                response.lista.ForEach(x => x._id = x.EstudiosId);
                response.status = true;
            }
            else {
                response.status = false;
            }

            
            return Ok(response);
        }

        [HttpGet("listaEstudios/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            ResponseEstudiosOne req = new ResponseEstudiosOne();
            req.estudio = await _estudiosService.GetByIdAsync(id);
            req.status = true;
            return Ok(req);
        }

        [HttpPost("crearEstudio")]
        public async Task<ActionResult> add(RequestEstudiosDto estudiosDto)
        {
            var tem = await _estudiosService.InsertAsync(estudiosDto.data);

            ResponseGeneralDto gen = new ResponseGeneralDto();

            if (tem == true)
            {
                gen.status = true;
                gen.msg = "Estudio creado exitosamente";
            }
            else {
                gen.status = false;
                gen.msg ="Error al agregar el estudio";
            }

            return Ok(gen);
        }

        [HttpPut("editaServicio/{id}")]
        public async Task<ActionResult> edit(EstudiosDto estudiosDto, long id)
        {
            estudiosDto.EstudiosId = id;
            var tem = await _estudiosService.UpdateAsync(estudiosDto);
            ResponseGeneralDto gen = new ResponseGeneralDto();

            if (tem == true)
            {
                gen.status = true;
                gen.msg = "Estudio actualizado exitosamente";
            }
            else
            {
                gen.status = false;
                gen.msg = "Error al actualizar el estudio";
            }
            return Ok(gen);
        }

        [HttpDelete("eliminaEstudio/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {

            var tem = await _estudiosService.DeleteAsync(id);

            ResponseGeneralDto gen = new ResponseGeneralDto();

            if (tem == true)
            {
                gen.status = true;
                gen.msg = "Estudio elimnado correctamente";
            }
            else
            {
                gen.status = false;
                gen.msg = "Error al eliminar el estudio";
            }
            return Ok(gen);
        }
    }
}
