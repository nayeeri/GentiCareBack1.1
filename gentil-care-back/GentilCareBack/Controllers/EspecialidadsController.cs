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
    [Route("api/admin")]
    public class EspecialidadsController : ControllerBase
    {
        private readonly IEspecialidadsService _especialidadsService;
        public EspecialidadsController(IEspecialidadsService especialidadsService)
        {
            this._especialidadsService = especialidadsService;
        }

        [HttpGet("listaEspecialidades")]
        public async Task<ActionResult> getDatas()
        {
            ResponseEspecialidadsList response = new ResponseEspecialidadsList();
            response.lista = await _especialidadsService.GetAllAsync();
            if (response.lista != null)
            {
                response.lista.ForEach(x => x._id = x.EspecialidadsId);
                response.status = true;
            }
            else
            {
                response.status = false;
            }


            return Ok(response);
            
        }

        [HttpGet("muestraEspecialidad/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            ResponseEspecialidadsOne req = new ResponseEspecialidadsOne();
            req.especialidad = await _especialidadsService.GetByIdAsync(id);
            req.status = true;

            return Ok(req);
        }

        [HttpPost("creaEspecialidad")]
        public async Task<ActionResult> add(RequestEspecialidadsDto especialidadsDto)
        {
            var insert = especialidadsDto.data;
            var tem = await _especialidadsService.InsertAsync(insert);

            ResponseGeneralDto gen = new ResponseGeneralDto();

            if (tem == true)
            {
                gen.status = true;
                gen.msg = "Especialidad creada exitosamente";
            }
            else
            {
                gen.status = false;
                gen.msg = "Error al agregar la Especialidad";
            }

            return Ok(gen);
        }

        [HttpPut("editaEspecialidad/{id}")]
        public async Task<ActionResult> edit(EspecialidadsDto especialidadsDto, long id)
        {
            especialidadsDto.EspecialidadsId = id;
            ResponseGeneralDto gen = new ResponseGeneralDto();

            var tem = await _especialidadsService.UpdateAsync(especialidadsDto);
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

        [HttpDelete("eliminaEspecialidad/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {

            var tem = await _especialidadsService.DeleteAsync(id);
            ResponseGeneralDto gen = new ResponseGeneralDto();

            if (tem == true)
            {
                gen.status = true;
                gen.msg = "Especialidad eliminada correctamente";
            }
            else
            {
                gen.status = false;
                gen.msg = "Error al eliminar la Especialidad";
            }
            return Ok(gen);

        }
    }
}
