using Microsoft.AspNetCore.Mvc;
using userservice.dtos;
using userservice.model;

namespace userservice.Controllers
{
    [ApiController]
    [Route("{controller}")]
    public class UserController : ControllerBase
    {
        private IUserService _userService { get; }
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet]
        public ActionResult<User> GetById([FromQuery] int id)
        {
            User user = this._userService.GetUserById(id);
            return Ok(user);
        }

        [HttpGet]
        public ActionResult<User> GetByName([FromQuery] string name)
        {
            User user = this._userService.GetUserByName(name);
            return Ok(user);
        }

        [HttpGet]
        public ActionResult<User> GetByEmail([FromQuery] string email)
        {
            User user = this._userService.GetUserByEmail(email);
            return Ok(user);
        }

        [HttpPost]
        public ActionResult<User> CreateUser(UserDto user)
        {
            if (user is null)
            {
                return BadRequest("Bad request body");
            }

            User userToCreate = new User
            {
                Birthday = user.Birthday,
                Email = user.Email,
                Name = user.Name,
                Password = BCrypt.Net.BCrypt.HashPassword(user.Password),
                PhoneNumber = user.PhoneNumber
            };

            if (this._userService.GetUserByEmail(userToCreate.Email) is User)
            {
                return NotFound("User with this email already exists");
            }

            User createdUser = this._userService.CreateUser(userToCreate);
            return CreatedAtAction(nameof(CreateUser), new { id = createdUser.Id }, createdUser);
        }

        public ActionResult<User> Login(UserDto user)
        {
            if (user is null)
            {
                return BadRequest("Bad request body");
            }

            if (this._userService.GetUserByEmail(user.Email) is User _user)
            {
                if (BCrypt.Net.BCrypt.Verify(user.Password, _user.Password))
                {
                    return Ok(_user);
                }
            }

            return NotFound("Email not found");
        }
    }
}