using AutoMapper;
using DTOs.User;
using Microsoft.AspNetCore.Mvc;
using Model.Entities;
using Model.Interface;
using System;
using System.Collections.Generic;

namespace PortafolioAPI.Controllers
{
    [Route("api/user")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IRepository<User> Repository;
        private readonly IMapper mapper;

        public UserController(IRepository<User> repository, IMapper mapper)
        {
            this.Repository = repository;
            this.mapper = mapper;
        }

        [HttpPost]
        public ActionResult<UserDTO> Post([FromBody] UserDTO value)
        {
            try
            {
                var user = this.mapper.Map<User>(value);
                this.Repository.Add(user);

                return Ok(new { Data = value });
            }catch(Exception)
            {
                return StatusCode(500);
            }


        }

        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> Get()
        {
            var users = this.Repository.GetAll();
            var usersDto = this.mapper.Map<IEnumerable<UserDTO>>(users);

            return Ok(new { Data = usersDto });
        }
    }
}
