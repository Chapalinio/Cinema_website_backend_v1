using homework10WEB_API.Models.DTO;
using homework10WEB_API.Services;
using Microsoft.AspNetCore.Mvc;

namespace homework10WEB_API.Controllers;

[Route("api/auth")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly UserService _userService;
    public UserController(UserService service)
    {
        _userService = service;
    }

    [HttpPost("register")]
    public ActionResult<bool> Register([FromBody] UserRegisterDTO user)
    {
        var isValid = _userService.Register(user);
        if (isValid)
        {
            return Ok(isValid);
        }
        else
        {
            return BadRequest(isValid);
        }
    }

    [HttpPost("login")]
    public ActionResult<bool> Login([FromBody] UserLoginDTO user)
    {
        var isValid = _userService.Login(user);
        if (isValid)
        {
            return Ok(isValid);
        }
        else
        {
            return BadRequest(isValid);
        }
    }
}
