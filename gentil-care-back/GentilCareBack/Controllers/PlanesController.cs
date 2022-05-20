using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GentilCareBack.Dto;
using GentilCareBack.Services.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace GentilCareBack.Controllers
{
    [ApiController]
    [Route("api/Planes")]
    public class PlanesController : ControllerBase
    {
        private readonly IPlanesService _planesService;
        public PlanesController(IPlanesService planesService)
        {
            this._planesService = planesService;
        }

        
        [HttpPost("crearPlan")]
        public async Task<ActionResult> crearPlan(RequestAddPlanesDto planesDto)
        {
            var planes = planesDto.data;

            ResponseGeneralDto gen = new ResponseGeneralDto();
            var tem = await _planesService.InsertAsync(planes);

            if (tem == true)
            {
                gen.status = true;
                gen.msg = "El plan fue creado exitosamente";
            }
            else
            {
                gen.status = false;
                gen.msg = "Error al agregar el Plan";
            }

            return Ok(gen);

        }

        [HttpGet("listaPlanes")]
        public async Task<ActionResult> getDatas()
        {
            ResponsePlanesListDto response = new ResponsePlanesListDto();
            response.planes = await _planesService.GetAllAsync();
            if (response.planes != null)
            {
                response.planes.ForEach(x => x._id = x.PlanesId);
                response.status = true;
            }
            else
            {
                response.status = false;
            }


            return Ok(response);

        }

        [HttpGet("muestraPlan/{id}")]
        public async Task<ActionResult> muestraPlan(long id)
        {
            //ResponsePlanesOne req = new ResponsePlanesOne();
            //req. = await _especialidadsService.GetByIdAsync(id);
            //req.status = true;
            var tem = await _planesService.GetByIdAsync(id);
            return Ok(tem);
        }

        [HttpDelete("eliminarPlan/{id}")]
        public async Task<ActionResult> eliminarPlan(long id)
        {

            ResponseGeneralDto gen = new ResponseGeneralDto();
            var tem = await _planesService.DeleteAsync(id);

            if (tem == true)
            {
                gen.status = true;
                gen.msg = "El plan fue eliminado exitosamente";
            }
            else
            {
                gen.status = false;
                gen.msg = "Error al eliminado el Plan";
            }

            return Ok(gen);
            
        }
    }
}
