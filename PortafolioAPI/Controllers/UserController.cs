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
        public ActionResult<IEnumerable<User>> Post([FromBody] UserDTO user)
        {
            try
            {
                var User = new User(user.Name, user.Surname, user.Email, user.Password);
                this.Repository.Add(User);

                return Ok(new { Data = user });
            }catch(Exception)
            {
                return StatusCode(500);
            }


        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var user = this.Repository.GetAll();

            return Ok(new { Data = user });
        }
    }
}
