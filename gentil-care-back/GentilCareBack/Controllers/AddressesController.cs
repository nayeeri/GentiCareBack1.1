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
    [Route("api/Addresses")]
    public class AddressesController : ControllerBase
    {
        private readonly  IAddressesService _addressesService; 
        public AddressesController(IAddressesService addressesService) {
            this._addressesService = addressesService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas() {
            return Ok( await _addressesService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _addressesService.GetByIdAsync(id));
        }

        [HttpGet("listaDirecciones/{id}")]
        public async Task<ActionResult> listaDirecciones(long id)
        {
            ResponseListAddress response = new ResponseListAddress();
            response.lista = await _addressesService.getListAddressUser(id);
            if (response.lista != null) {
                response.lista.ForEach(x =>
                {
                    x._id = x.AddressesId;
                });
            }
            
            response.status = true;
            return Ok(response);
        }

        [HttpPost("add")]
        [HttpPost("agregarDireccion/{id}")]
        public async Task<ActionResult> add(AddressesDto addressesDto, long id)
        {
            UsersDto user = new UsersDto();
            user.UsersId = id;
            addressesDto.Users = user;
            return Ok(await _addressesService.InsertAsync(addressesDto));
        }

        [HttpPut("edit")]
        public async Task<ActionResult> edit(AddressesDto addressesDto)
        {
            return Ok(await _addressesService.UpdateAsync(addressesDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            var tem = await _addressesService.DeleteAsync(id);

            ResponseGeneralDto gen = new ResponseGeneralDto();

            if (tem == true)
            {
                gen.status = true;
                gen.msg = "Direccion eliminada correctamente";
            }
            else
            {
                gen.status = false;
                gen.msg = "Error al eliminar la direccion";
            }
            return Ok(gen);

            //return Ok();
        }
    }
}
