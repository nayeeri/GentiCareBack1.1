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
    [Route("api/auth")]
    public class AuthsController : ControllerBase
    {
        private readonly IAuthsService _authsService;
        private readonly IUsersService _usersService;

        public AuthsController(IAuthsService authsService, IUsersService usersService)
        {
            this._authsService = authsService;
            this._usersService = usersService;
        }

        [HttpGet("getData")]
        public async Task<ActionResult> getDatas()
        {
            return Ok(await _authsService.GetAllAsync());
        }

        [HttpGet("getData/{id}")]
        public async Task<ActionResult> getDatas(long id)
        {
            return Ok(await _authsService.GetByIdAsync(id));
        }

        [HttpGet("verificaToken/{id}")]
        public async Task<ActionResult> verificaToken(long id)
        {
            return Ok(await _usersService.GetByIdAsync(id));
        }

        [HttpPut("verify")]
        public async Task<ActionResult> verify(UsersDto usersDto)
        {
            //return Ok(await _usersService.GetByIdAsync(long.Parse("1")));
            return Ok("");
        }

        

        [HttpPost("add")]
        public async Task<ActionResult> add(AuthsDto authsDto)
        {
            return Ok(await _authsService.InsertAsync(authsDto));
        }

        [HttpPost("login")]
        public async Task<ActionResult> login(AuthsDto authsDto)
        {
            return Ok(await _authsService.validateUser(authsDto));
        }

        

        [HttpPut("edit")]
        public async Task<ActionResult> edit(AuthsDto authsDto)
        {
            return Ok(await _authsService.UpdateAsync(authsDto));
        }

        [HttpDelete("deleteData/{id}")]
        public async Task<ActionResult> deleteData(long id)
        {
            return Ok(await _authsService.GetByIdAsync(id));
        }
    }
}
