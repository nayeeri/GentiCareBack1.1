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
    [Route("api/Medicamento")]
    public class MedicamentoController : ControllerBase
    {
        private readonly IMedicamentoService _medicamentoService;
        public MedicamentoController(IMedicamentoService medicamentoService)
        {
            this._medicamentoService = medicamentoService;
        }

        [HttpPost("creaMedicamento")]
        public async Task<ActionResult> crearPlan(RequestAddMedicamentoDto medicamentoDto)
        {
            var planes = medicamentoDto.data;

            ResponseGeneralDto gen = new ResponseGeneralDto();
            var tem = await _medicamentoService.InsertAsync(planes);

            if (tem == true)
            {
                gen.status = true;
                gen.msg = "El medicamento fue creado exitosamente";
            }
            else
            {
                gen.status = false;
                gen.msg = "Error al agregar el medicamento";
            }

            return Ok(gen);

        }

        [HttpGet("listaMedicamentos")]
        public async Task<ActionResult> getDatas()
        {
            ResponseMedicamentoListDto response = new ResponseMedicamentoListDto();
            response.lista = await _medicamentoService.GetAllAsync();
            if (response.lista != null)
            {
                response.lista.ForEach(x => x._id = x.MedicamentoId);
                response.status = true;
            }
            else
            {
                response.status = false;
            }


            return Ok(response);

        }

        [HttpDelete("eliminaMedicamento/{id}")]
        public async Task<ActionResult> eliminaMedicamento(long id)
        {

            ResponseGeneralDto gen = new ResponseGeneralDto();
            var tem = await _medicamentoService.DeleteAsync(id);

            if (tem == true)
            {
                gen.status = true;
                gen.msg = "El medicamento fue eliminado exitosamente";
            }
            else
            {
                gen.status = false;
                gen.msg = "Error al eliminar el medicamento";
            }

            return Ok(gen);

        }
        
    }
}
