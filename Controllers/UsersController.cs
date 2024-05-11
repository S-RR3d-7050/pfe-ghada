namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;
using WebApi.Services;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private IUserService _userService;
    private IEmploiDuTempsService _emploiDuTempsService;
    private IMapper _mapper;
    private readonly AppSettings _appSettings;

    public UsersController(
        IUserService userService,
        IEmploiDuTempsService emploiDuTempsService,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _userService = userService;
        _emploiDuTempsService = emploiDuTempsService;
        _mapper = mapper;
        _appSettings = appSettings.Value;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);
        return Ok(response);
    }

    [AllowAnonymous]
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest model)
    {
        _userService.Register(model);

        // WE need to return the created user aswell 

        // This is not working


        var user = _userService.GetByUsername(model.Username);

        if (user.Role == Entities.UserRole.Médecin)
        {
            //create a new EmploiDuTemps for the new user
            EmploiDuTemps emploiDuTemps = new EmploiDuTemps();
            emploiDuTemps.KinéId = user.Id;
            _emploiDuTempsService.Create(emploiDuTemps);

        }

        // We return the created user and the success message

        return Ok(new { message = "Registration successful", user = user });

        //return Ok(user);

        //return Ok(new { message = "Registration successful" });
      

    //);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetById(id);
        return Ok(user);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _userService.Update(id, model);
        return Ok(new { message = "User updated successfully" });
    }

    [HttpPut("{id}/activate")]
    public IActionResult Activate(int id)
    {
		_userService.activate(id);
		return Ok(new { message = "User activated successfully" });
	}

    [HttpPut("{id}/deactivate")]
    public IActionResult Deactivate(int id)
    {
        	_userService.deactivate(id);
        return Ok(new { message = "User deactivated successfully" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _userService.Delete(id);
        return Ok(new { message = "User deleted successfully" });
    }


    [AllowAnonymous]
    [HttpGet("medecins")]
    public IActionResult GetAllMédecins()
    {
        var users = _userService.GetAllMédecins();
        return Ok(users);
    }
}