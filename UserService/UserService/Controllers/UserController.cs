using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UserService.Dtos;
using UserService.Models;

namespace UserService.Controllers
{
    public class UserController : Controller
    {
        private readonly IMapper mapper;

        public UserController(IMapper mapper)
        {
            this.mapper = mapper;
        }

        [HttpPost]
        public IActionResult Post([FromBody]UserDto userDto)
        {
            return Ok(userDto);
        }
    }
}
