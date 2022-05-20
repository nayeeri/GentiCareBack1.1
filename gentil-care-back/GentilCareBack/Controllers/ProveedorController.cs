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
    [Route("api/Proveedor")]
    public class ProveedorController : ControllerBase
    {
        private readonly IProveedorService _proveedorService;
        public ProveedorController(IProveedorService proveedorService)
        {
            this._proveedorService = proveedorService;
        }

        [HttpPost("creaProvedor")]
        public async Task<ActionResult> creaProvedor(RequestAddProveedorDto planesDto)
        {
            var planes = planesDto.data;

            ResponseGeneralDto gen = new ResponseGeneralDto();
            var tem = await _proveedorService.InsertAsync(planes);

            if (tem == true)
            {
                gen.status = true;
                gen.msg = "El proveedor fue creado exitosamente";
            }
            else
            {
                gen.status = false;
                gen.msg = "Error al agregar el proveedor";
            }

            return Ok(gen);

        }

        [HttpGet("listaProveedores")]
        public async Task<ActionResult> getDatas()
        {
            ResponseProveedorListDto response = new ResponseProveedorListDto();
            response.lista = await _proveedorService.GetAllAsync();
            if (response.lista != null)
            {
                response.lista.ForEach(x => x._id = x.ProveedorId);
                response.status = true;
            }
            else
            {
                response.status = false;
            }


            return Ok(response);

        }

        [HttpGet("muestraProvedor/{id}")]
        public async Task<ActionResult> muestraProvedor(long id)
        {
            ResponseProveedorOne req = new ResponseProveedorOne();
            req.provedor = await _proveedorService.GetByIdAsync(id);
            req.status = true;
            
            return Ok(req);
        }

        //
        [HttpPut("editaProvedor/{id}")]
        public async Task<ActionResult> edit(ProveedorDto especialidadsDto, long id)
        {
            especialidadsDto.ProveedorId = id;
            ResponseGeneralDto gen = new ResponseGeneralDto();

            var tem = await _proveedorService.UpdateAsync(especialidadsDto);
            if (tem == true)
            {
                gen.status = true;
                gen.msg = "Proveedor actualizado exitosamente";
            }
            else
            {
                gen.status = false;
                gen.msg = "Error al actualizar el Proveedor";
            }
            return Ok(gen);
        }

        [HttpDelete("eliminaProvedor/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {

            var tem = await _proveedorService.DeleteAsync(id);
            ResponseGeneralDto gen = new ResponseGeneralDto();

            if (tem == true)
            {
                gen.status = true;
                gen.msg = "Proveedor eliminado correctamente";
            }
            else
            {
                gen.status = false;
                gen.msg = "Error al eliminar el proveedor";
            }
            return Ok(gen);

        }
        
    }
}
