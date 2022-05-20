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
        private readonly IColaboradorsService _colaboradorService;
        private readonly IHoraService _horaService;
        private readonly ISemanaService _semanaService;

        private readonly IPreguntasService _preguntasService;
        public UsersController(IUsersService usersService, IPreguntasService preguntasService, IRolesService rolesService, IAuthsService authsService, IColaboradorsService colaboradorService, IHoraService horaService, ISemanaService semanaService ) 
        {
            this._usersService = usersService;
            this._preguntasService = preguntasService;
            this._authsService = authsService;
            this._rolesService = rolesService;
            this._colaboradorService = colaboradorService;
            this._horaService = horaService;
            this._semanaService = semanaService;
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

            Random random = new Random();
            string PINRan = "";

            for (int i = 0; i < 4; i++)
            {
                PINRan += (random.Next(0, 9) + 1).ToString();
            }

            var preguntas = new PreguntasDto();
            usersDto.pin = PINRan;
            preguntas.Users = usersDto;
            preguntas.respuestaUno = usersDto.preguntaUno != null ? usersDto.preguntaUno : "SIN DATO" ;
            preguntas.respuestaDos = usersDto.preguntaDos != null ? usersDto.preguntaDos : "SIN DATO";
            preguntas.respuestaTres = usersDto.preguntaTres != null ? usersDto.preguntaTres : "SIN DATO";

            var preg = await _preguntasService.InsertAsync(preguntas);

            var auth = new AuthsDto();
            auth.created_at = DateTime.Now;
            auth.username = usersDto.nombre.Substring(0, 3) + usersDto.A_P.Substring(0, 3) + PINRan;
            auth.username = auth.username.Trim();
            auth.acceso = auth.acceso != null ? auth.acceso : auth.username;

            auth.password = usersDto.nombre.Substring(0, 3) + usersDto.A_P.Substring(0, 4) + usersDto.cellphone.Substring(0, 4) + PINRan;

            var idUs = await _usersService.getUltimateRegister();
            auth.UsersId = idUs.UsersId;

            auth.verified = false;
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

            usersDto.pin = PINRan;
            Utils.SendMailPINGmail(PINRan, usersDto.email);

            ResponseUsuarioOne response = new ResponseUsuarioOne();
            response.usuario = usersDto;
            response.status = true;
            response.msg = "Registro dado de alta correctamente";
            return Ok(response);
        }

        [HttpPost("addData")]
        public async Task<ActionResult> addDataUser(requestUser userData)
        {

            Disponible disponible = new Disponible();
            if (userData.disponible != null) {
                disponible.Lunes = userData.disponible[0].Lunes;
                disponible.Martes = userData.disponible[1].Martes;
                disponible.Miercoles = userData.disponible[2].Miercoles;
                disponible.Jueves = userData.disponible[3].Jueves;
                disponible.Viernes = userData.disponible[4].Viernes;
                disponible.Sabado = userData.disponible[5].Sabado;
                disponible.Domingo = userData.disponible[6].Domingo;
            }

            Random random = new Random();
            string PINRan = "";

            for (int i = 0; i < 4; i++)
            {
                PINRan += (random.Next(0, 9) + 1).ToString();
            }

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
            auth.username = usersDto.nombre.Substring(0, 3) + usersDto.A_P.Substring(0, 3) + PINRan;
            auth.username = auth.username.Trim();
            auth.acceso = auth.acceso != null ? auth.acceso : auth.username;

            auth.password = usersDto.nombre.Substring(0, 3) + usersDto.A_P.Substring(0, 4) + PINRan;

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

            if (userData.cola != null) {
                userData.cola.Users = idUs;
                var colaT = await _colaboradorService.InsertAsync(userData.cola);
                var resultColaborador = await _colaboradorService.getUltimateRegister();


                SemanaDto semanaDto = new SemanaDto();
                semanaDto.Colaboradors = resultColaborador;
                await _semanaService.InsertAsync(semanaDto);
                var sem = await _semanaService.getUltimateRegister();

                List<HorasDto> lstHoras = new List<HorasDto>();
                HorasDto hora = null;

                if (disponible.Lunes != null) {
                    hora = new HorasDto();
                    disponible.Lunes.ForEach(x =>
                    {
                        hora.dia = 1;

                        if (x.Equals("8")) {
                            hora.ocho = true;
                        }
                        if (x.Equals("9"))
                        {
                            hora.nueve = true;
                        }
                        if (x.Equals("10"))
                        {
                            hora.diez  = true;
                        }
                        if (x.Equals("11"))
                        {
                            hora.once = true;
                        }
                        if (x.Equals("12"))
                        {
                            hora.doce = true;
                        }
                        if (x.Equals("13"))
                        {
                            hora.trece = true;
                        }
                        if (x.Equals("14"))
                        {
                            hora.catorce = true;
                        }
                        if (x.Equals("15"))
                        {
                            hora.quince = true;
                        }
                        if (x.Equals("16"))
                        {
                            hora.dieciseis = true;
                        }
                        if (x.Equals("17"))
                        {
                            hora.diecisiete = true;
                        }
                        if (x.Equals("18"))
                        {
                            hora.dieciocho = true;
                        }
                        if (x.Equals("19"))
                        {
                            hora.diecinueve = true;
                        }
                        if (x.Equals("20"))
                        {
                            hora.veinte = true;
                        }
                        if (x.Equals("21"))
                        {
                            hora.veintiuno = true;
                        }
                        if (x.Equals("22"))
                        {
                            hora.veintidos = true;
                        }
                        if (x.Equals("23"))
                        {
                            hora.veintitres = true;
                        }
                    });
                    lstHoras.Add(hora);
                }

                if (disponible.Martes != null)
                {
                    hora = new HorasDto();
                    disponible.Martes.ForEach(x =>
                    {
                        hora.dia = 2;

                        if (x.Equals("8"))
                        {
                            hora.ocho = true;
                        }
                        if (x.Equals("9"))
                        {
                            hora.nueve = true;
                        }
                        if (x.Equals("10"))
                        {
                            hora.diez = true;
                        }
                        if (x.Equals("11"))
                        {
                            hora.once = true;
                        }
                        if (x.Equals("12"))
                        {
                            hora.doce = true;
                        }
                        if (x.Equals("13"))
                        {
                            hora.trece = true;
                        }
                        if (x.Equals("14"))
                        {
                            hora.catorce = true;
                        }
                        if (x.Equals("15"))
                        {
                            hora.quince = true;
                        }
                        if (x.Equals("16"))
                        {
                            hora.dieciseis = true;
                        }
                        if (x.Equals("17"))
                        {
                            hora.diecisiete = true;
                        }
                        if (x.Equals("18"))
                        {
                            hora.dieciocho = true;
                        }
                        if (x.Equals("19"))
                        {
                            hora.diecinueve = true;
                        }
                        if (x.Equals("20"))
                        {
                            hora.veinte = true;
                        }
                        if (x.Equals("21"))
                        {
                            hora.veintiuno = true;
                        }
                        if (x.Equals("22"))
                        {
                            hora.veintidos = true;
                        }
                        if (x.Equals("23"))
                        {
                            hora.veintitres = true;
                        }
                    });
                    lstHoras.Add(hora);
                }

                if (disponible.Miercoles != null)
                {
                    hora = new HorasDto();
                    disponible.Miercoles.ForEach(x =>
                    {
                        hora.dia = 3;

                        if (x.Equals("8"))
                        {
                            hora.ocho = true;
                        }
                        if (x.Equals("9"))
                        {
                            hora.nueve = true;
                        }
                        if (x.Equals("10"))
                        {
                            hora.diez = true;
                        }
                        if (x.Equals("11"))
                        {
                            hora.once = true;
                        }
                        if (x.Equals("12"))
                        {
                            hora.doce = true;
                        }
                        if (x.Equals("13"))
                        {
                            hora.trece = true;
                        }
                        if (x.Equals("14"))
                        {
                            hora.catorce = true;
                        }
                        if (x.Equals("15"))
                        {
                            hora.quince = true;
                        }
                        if (x.Equals("16"))
                        {
                            hora.dieciseis = true;
                        }
                        if (x.Equals("17"))
                        {
                            hora.diecisiete = true;
                        }
                        if (x.Equals("18"))
                        {
                            hora.dieciocho = true;
                        }
                        if (x.Equals("19"))
                        {
                            hora.diecinueve = true;
                        }
                        if (x.Equals("20"))
                        {
                            hora.veinte = true;
                        }
                        if (x.Equals("21"))
                        {
                            hora.veintiuno = true;
                        }
                        if (x.Equals("22"))
                        {
                            hora.veintidos = true;
                        }
                        if (x.Equals("23"))
                        {
                            hora.veintitres = true;
                        }
                    });
                    lstHoras.Add(hora);
                }

                if (disponible.Jueves != null)
                {
                    hora = new HorasDto();
                    disponible.Jueves.ForEach(x =>
                    {
                        hora.dia = 4;

                        if (x.Equals("8"))
                        {
                            hora.ocho = true;
                        }
                        if (x.Equals("9"))
                        {
                            hora.nueve = true;
                        }
                        if (x.Equals("10"))
                        {
                            hora.diez = true;
                        }
                        if (x.Equals("11"))
                        {
                            hora.once = true;
                        }
                        if (x.Equals("12"))
                        {
                            hora.doce = true;
                        }
                        if (x.Equals("13"))
                        {
                            hora.trece = true;
                        }
                        if (x.Equals("14"))
                        {
                            hora.catorce = true;
                        }
                        if (x.Equals("15"))
                        {
                            hora.quince = true;
                        }
                        if (x.Equals("16"))
                        {
                            hora.dieciseis = true;
                        }
                        if (x.Equals("17"))
                        {
                            hora.diecisiete = true;
                        }
                        if (x.Equals("18"))
                        {
                            hora.dieciocho = true;
                        }
                        if (x.Equals("19"))
                        {
                            hora.diecinueve = true;
                        }
                        if (x.Equals("20"))
                        {
                            hora.veinte = true;
                        }
                        if (x.Equals("21"))
                        {
                            hora.veintiuno = true;
                        }
                        if (x.Equals("22"))
                        {
                            hora.veintidos = true;
                        }
                        if (x.Equals("23"))
                        {
                            hora.veintitres = true;
                        }
                    });
                    lstHoras.Add(hora);
                }

                if (disponible.Viernes != null)
                {
                    hora = new HorasDto();
                    disponible.Viernes.ForEach(x =>
                    {
                        hora.dia = 5;

                        if (x.Equals("8"))
                        {
                            hora.ocho = true;
                        }
                        if (x.Equals("9"))
                        {
                            hora.nueve = true;
                        }
                        if (x.Equals("10"))
                        {
                            hora.diez = true;
                        }
                        if (x.Equals("11"))
                        {
                            hora.once = true;
                        }
                        if (x.Equals("12"))
                        {
                            hora.doce = true;
                        }
                        if (x.Equals("13"))
                        {
                            hora.trece = true;
                        }
                        if (x.Equals("14"))
                        {
                            hora.catorce = true;
                        }
                        if (x.Equals("15"))
                        {
                            hora.quince = true;
                        }
                        if (x.Equals("16"))
                        {
                            hora.dieciseis = true;
                        }
                        if (x.Equals("17"))
                        {
                            hora.diecisiete = true;
                        }
                        if (x.Equals("18"))
                        {
                            hora.dieciocho = true;
                        }
                        if (x.Equals("19"))
                        {
                            hora.diecinueve = true;
                        }
                        if (x.Equals("20"))
                        {
                            hora.veinte = true;
                        }
                        if (x.Equals("21"))
                        {
                            hora.veintiuno = true;
                        }
                        if (x.Equals("22"))
                        {
                            hora.veintidos = true;
                        }
                        if (x.Equals("23"))
                        {
                            hora.veintitres = true;
                        }
                    });
                    lstHoras.Add(hora);
                }

                if (disponible.Sabado != null)
                {
                    hora = new HorasDto();
                    disponible.Sabado.ForEach(x =>
                    {
                        hora.dia = 6;

                        if (x.Equals("8"))
                        {
                            hora.ocho = true;
                        }
                        if (x.Equals("9"))
                        {
                            hora.nueve = true;
                        }
                        if (x.Equals("10"))
                        {
                            hora.diez = true;
                        }
                        if (x.Equals("11"))
                        {
                            hora.once = true;
                        }
                        if (x.Equals("12"))
                        {
                            hora.doce = true;
                        }
                        if (x.Equals("13"))
                        {
                            hora.trece = true;
                        }
                        if (x.Equals("14"))
                        {
                            hora.catorce = true;
                        }
                        if (x.Equals("15"))
                        {
                            hora.quince = true;
                        }
                        if (x.Equals("16"))
                        {
                            hora.dieciseis = true;
                        }
                        if (x.Equals("17"))
                        {
                            hora.diecisiete = true;
                        }
                        if (x.Equals("18"))
                        {
                            hora.dieciocho = true;
                        }
                        if (x.Equals("19"))
                        {
                            hora.diecinueve = true;
                        }
                        if (x.Equals("20"))
                        {
                            hora.veinte = true;
                        }
                        if (x.Equals("21"))
                        {
                            hora.veintiuno = true;
                        }
                        if (x.Equals("22"))
                        {
                            hora.veintidos = true;
                        }
                        if (x.Equals("23"))
                        {
                            hora.veintitres = true;
                        }
                    });
                    lstHoras.Add(hora);
                }

                if (disponible.Domingo != null)
                {
                    hora = new HorasDto();
                    disponible.Domingo.ForEach(x =>
                    {
                        hora.dia = 7;

                        if (x.Equals("8"))
                        {
                            hora.ocho = true;
                        }
                        if (x.Equals("9"))
                        {
                            hora.nueve = true;
                        }
                        if (x.Equals("10"))
                        {
                            hora.diez = true;
                        }
                        if (x.Equals("11"))
                        {
                            hora.once = true;
                        }
                        if (x.Equals("12"))
                        {
                            hora.doce = true;
                        }
                        if (x.Equals("13"))
                        {
                            hora.trece = true;
                        }
                        if (x.Equals("14"))
                        {
                            hora.catorce = true;
                        }
                        if (x.Equals("15"))
                        {
                            hora.quince = true;
                        }
                        if (x.Equals("16"))
                        {
                            hora.dieciseis = true;
                        }
                        if (x.Equals("17"))
                        {
                            hora.diecisiete = true;
                        }
                        if (x.Equals("18"))
                        {
                            hora.dieciocho = true;
                        }
                        if (x.Equals("19"))
                        {
                            hora.diecinueve = true;
                        }
                        if (x.Equals("20"))
                        {
                            hora.veinte = true;
                        }
                        if (x.Equals("21"))
                        {
                            hora.veintiuno = true;
                        }
                        if (x.Equals("22"))
                        {
                            hora.veintidos = true;
                        }
                        if (x.Equals("23"))
                        {
                            hora.veintitres = true;
                        }
                    });
                    lstHoras.Add(hora);
                }

                if (lstHoras.Count > 0) {

                    foreach (var tm in lstHoras) {
                        await _horaService.InsertAsync(tm, sem.SemanaId);
                    }

                    
                }
                

                //semanaDto.Colaboradors = resultColaborador;
                //semanaDto.Horas = hora;


            }


            usersDto.status = true;
            usersDto.pin = PINRan;
            return Ok(usersDto);
        }

        [HttpPost("registroSocios")]
        public async Task<ActionResult> registroSocios(UsersDto usersDto)
        {

            //var usersDto = userData.data;
            Random random = new Random();
            string PINRan = "";

            for (int i = 0; i < 4; i++)
            {
                PINRan += (random.Next(0, 9) + 1).ToString();
            }

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
            auth.username = usersDto.nombre.Substring(0, 3) + usersDto.A_P.Substring(0, 3) + PINRan;
            auth.username = auth.username.Trim();
            auth.acceso = auth.acceso != null ? auth.acceso : auth.username;

            auth.password = usersDto.nombre.Substring(0, 3) + usersDto.A_P.Substring(0, 4) + PINRan;

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
            usersDto.pin = PINRan;
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
