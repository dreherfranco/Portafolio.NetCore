using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DTOs.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Model.Entities;
using Model.Interface;

namespace PortafolioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepository<User> Repository;

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static readonly User entity = new User("frabco","dreher","asdasd","asdasdas");
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepository<User> repository)
        {
            _logger = logger;
            this.Repository = repository;
        }

        /*[HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }*/

        [HttpPost]
        public ActionResult<IEnumerable<User>> Add([FromBody]UserDTO user)
        {
            var User = new User(user.Name, user.Surname, user.Email, user.Password);
            this.Repository.Add(User);
            
            return Ok(new { Data = user });


        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            var user = this.Repository.GetAll();

            return Ok(new { Data = user });
        }
    }
}
