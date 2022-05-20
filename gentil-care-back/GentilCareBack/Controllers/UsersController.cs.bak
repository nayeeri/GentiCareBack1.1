using GentilCareBack.Dto;
using GentilCareBack.Services.Interface;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GentilCareBack.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _usersService;
        private readonly IRolesService _rolesService;
        private readonly IAuthsService _authsService;

        private readonly IPreguntasService _preguntasService;
        public UsersController(IUsersService usersService, IPreguntasService preguntasService, IRolesService rolesService, IAuthsService authsService)
        {
            this._usersService = usersService;
            this._preguntasService = preguntasService;
            this._authsService = authsService;
            this._rolesService = rolesService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _usersService.GetAllAsync());
        }

        [HttpGet("listaFamiliares/{id}")]
        public async Task<ActionResult> listaFamiliares(string id)
        {
            ResponseVerFamiliares response = new ResponseVerFamiliares();
            response.status = true;
            response.familiares = await _usersService.GetAllFamiliaresAsync(id);
            return Ok(response);
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _usersService.GetByIdAsync(id));
        }


        [HttpGet("muestraUsuario/{id}")]
        public async Task<ActionResult> muestraUsuario(long id)
        {
            ResponseFamiliarOne response = new ResponseFamiliarOne();
            response.familiar = await _usersService.GetByIdAsync(id);
            response.status = true;
            return Ok(response);
        }


        [HttpPut("editarUsuario/{id}")]
        public async Task<ActionResult> editarUsuario(UsersDto usersDto, long id)
        {
            var tem = await _usersService.GetByIdAsync(id);
            tem.email = usersDto.email;
            tem.cellphone = usersDto.cellphone;
            tem.auth.password = usersDto.password;


            var res = await _authsService.UpdateAsync(tem.auth);
            return Ok(await _usersService.UpdateAsync(tem));
        }

        [HttpPost("add")]
        public async Task<ActionResult> add(UsersDto usersDto)
        {
            //var result =  await _usersService.InsertAsync(usersDto);
            var preguntas = new PreguntasDto();
            preguntas.Users = usersDto;
            preguntas.respuestaUno = usersDto.preguntaUno != null ? usersDto.preguntaUno : "SIN DATO" ;
            preguntas.respuestaDos = usersDto.preguntaDos != null ? usersDto.preguntaDos : "SIN DATO";
            preguntas.respuestaTres = usersDto.preguntaTres != null ? usersDto.preguntaTres : "SIN DATO";

            var preg = await _preguntasService.InsertAsync(preguntas);

            var auth = new AuthsDto();
            auth.created_at = DateTime.Now;
            auth.username = usersDto.nombre.Substring(0, 3) + usersDto.A_P.Substring(0, 3) + "8546";
            auth.username = auth.username.Trim();
            auth.acceso = auth.acceso != null ? auth.acceso : auth.username;

            auth.password = usersDto.nombre.Substring(0, 3) + usersDto.A_P.Substring(0, 4) + usersDto.cellphone.Substring(0, 4);

            var idUs = await _usersService.getUltimateRegister();
            auth.UsersId = idUs.UsersId;

            auth.verified = true;
            if (usersDto.tipo != null)
            {
                var role = await _rolesService.GetByIdAsync(usersDto.tipo);
                auth.Roles = role;
                
            }
            else {
                var role = await _rolesService.GetByIdAsync(long.Parse("6"));
                auth.Roles = role;
            }
            

            usersDto.auth = auth;

            var insertAu = await _authsService.InsertAsync(auth);


            usersDto.status = true;
            usersDto.pin = "1234";
            return Ok(usersDto);
        }

        [HttpPost("addData")]
        public async Task<ActionResult> addDataUser(requestUser userData)
        {
            
            var usersDto = userData.data;

            usersDto.cellphone = usersDto.cellphone != null ? usersDto.cellphone : usersDto.tel_part;

            //var result =  await _usersService.InsertAsync(usersDto);
            var preguntas = new PreguntasDto();
            preguntas.Users = usersDto;
            preguntas.respuestaUno = usersDto.preguntaUno != null ? usersDto.preguntaUno : "SIN DATO";
            preguntas.respuestaDos = usersDto.preguntaDos != null ? usersDto.preguntaDos : "SIN DATO";
            preguntas.respuestaTres = usersDto.preguntaTres != null ? usersDto.preguntaTres : "SIN DATO";

            var preg = await _preguntasService.InsertAsync(preguntas);

            var auth = new AuthsDto();
            auth.created_at = DateTime.Now;
            auth.username = usersDto.nombre.Substring(0, 3) + usersDto.A_P.Substring(0, 3) + "8546";
            auth.username = auth.username.Trim();
            auth.acceso = auth.acceso != null ? auth.acceso : auth.username;

            auth.password = usersDto.nombre.Substring(0, 3) + usersDto.A_P.Substring(0, 4) + usersDto.cellphone.Substring(0, 4);

            var idUs = await _usersService.getUltimateRegister();
            auth.UsersId = idUs.UsersId;

            auth.verified = true;
            if (usersDto.tipo != null)
            {
                var role = await _rolesService.GetByIdAsync(long.Parse(usersDto.tipo));
                auth.Roles = role;
            }
            else
            {
                var role = await _rolesService.GetByIdAsync(long.Parse("6"));
                auth.Roles = role;
            }


            usersDto.auth = auth;

            var insertAu = await _authsService.InsertAsync(auth);


            usersDto.status = true;
            usersDto.pin = "1234";
            return Ok(usersDto);
        }

        [HttpPost("registroSocios")]
        public async Task<ActionResult> registroSocios(UsersDto usersDto)
        {

            //var usersDto = userData.data;

            usersDto.cellphone = usersDto.cellphone != null ? usersDto.cellphone : usersDto.tel_part;

            //var result =  await _usersService.InsertAsync(usersDto);
            var preguntas = new PreguntasDto();
            preguntas.Users = usersDto;
            preguntas.respuestaUno = usersDto.preguntaUno != null ? usersDto.preguntaUno : "SIN DATO";
            preguntas.respuestaDos = usersDto.preguntaDos != null ? usersDto.preguntaDos : "SIN DATO";
            preguntas.respuestaTres = usersDto.preguntaTres != null ? usersDto.preguntaTres : "SIN DATO";

            var preg = await _preguntasService.InsertAsync(preguntas);

            var auth = new AuthsDto();
            auth.created_at = DateTime.Now;
            auth.username = usersDto.nombre.Substring(0, 3) + usersDto.A_P.Substring(0, 3) + "8546";
            auth.username = auth.username.Trim();
            auth.acceso = auth.acceso != null ? auth.acceso : auth.username;

            auth.password = usersDto.nombre.Substring(0, 3) + usersDto.A_P.Substring(0, 4) + usersDto.cellphone.Substring(0, 4);

            var idUs = await _usersService.getUltimateRegister();
            auth.UsersId = idUs.UsersId;

            auth.verified = true;
            if (usersDto.tipo != null)
            {
                var role = await _rolesService.GetByIdAsync(long.Parse(usersDto.tipo));
                auth.Roles = role;
            }
            else
            {
                var role = await _rolesService.GetByIdAsync(long.Parse("6"));
                auth.Roles = role;
            }


            usersDto.auth = auth;

            var insertAu = await _authsService.InsertAsync(auth);


            usersDto.status = true;
            usersDto.pin = "1234";
            return Ok(usersDto);
        }

        [HttpPost("agregarFamiliar/{id}")]
        public async Task<ActionResult> agregarFamiliar(UsersDto usersDto, string id)
        {

            //var usersDto = userData.data;

            usersDto.cellphone = usersDto.cellphone != null ? usersDto.cellphone : usersDto.tel_part;
            usersDto.customerID = id;

            //var result =  await _usersService.InsertAsync(usersDto);
            var preguntas = new PreguntasDto();
            preguntas.Users = usersDto;
            preguntas.respuestaUno = usersDto.preguntaUno != null ? usersDto.preguntaUno : "SIN DATO";
            preguntas.respuestaDos = usersDto.preguntaDos != null ? usersDto.preguntaDos : "SIN DATO";
            preguntas.respuestaTres = usersDto.preguntaTres != null ? usersDto.preguntaTres : "SIN DATO";

            var preg = await _preguntasService.InsertAsync(preguntas);

            //var auth = new AuthsDto();
            //auth.created_at = DateTime.Now;
            //auth.username = usersDto.nombre.Substring(0, 3) + usersDto.A_P.Substring(0, 3) + "8546";
            //auth.username = auth.username.Trim();
            //auth.acceso = auth.acceso != null ? auth.acceso : auth.username;

            //auth.password = usersDto.nombre.Substring(0, 3) + usersDto.A_P.Substring(0, 4) + usersDto.cellphone.Substring(0, 4);

            //var idUs = await _usersService.getUltimateRegister();
            //auth.UsersId = idUs.UsersId;

            //auth.verified = true;
            //if (usersDto.tipo != null)
            //{
            //    var role = await _rolesService.GetByIdAsync(long.Parse(usersDto.tipo));
            //    auth.Roles = role;
            //}
            //else
            //{
            //    var role = await _rolesService.GetByIdAsync(long.Parse("6"));
            //    auth.Roles = role;
            //}


            //usersDto.auth = auth;

            //var insertAu = await _authsService.InsertAsync(auth);


            usersDto.status = true;
            usersDto.pin = "1234";
            return Ok(usersDto);
        }

        

        [HttpPut("edit")]
        public async Task<ActionResult> edit(UsersDto usersDto)
        {
            return Ok(await _usersService.UpdateAsync(usersDto));
        }

        [HttpDelete("eliminar/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _usersService.DeleteAsync(id));
        }

        [HttpGet("listaColaboradores")]
        public async Task<ActionResult> listaColaboradores()
        {
            ResponseVerColaboradores responseVerColaboradores = new ResponseVerColaboradores();
            responseVerColaboradores.doctores = await _usersService.GetAllColaboratorAsync();
            responseVerColaboradores.status = true;
            return Ok(responseVerColaboradores);
        }
        //
    }
}
