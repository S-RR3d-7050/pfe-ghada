namespace WebApi.Services;

using AutoMapper;
using BCrypt.Net;
using WebApi.Authorization;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Users;

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);
    void Register(RegisterRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
    void activate(int id);
    void deactivate(int id);
    User GetByUsername(string username);
    IEnumerable<User> GetAllMédecins();
}

public class UserService : IUserService
{
    private DataContext _context;
    private IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public UserService(
        DataContext context,
        IJwtUtils jwtUtils,
        IMapper mapper)
    {
        _context = context;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _context.Users.SingleOrDefault(x => x.Username == model.Username);

        // validate
        if (user == null || !BCrypt.Verify(model.Password, user.PasswordHash))
            throw new AppException("Email or password is incorrect");

        // authentication successful
        var response = _mapper.Map<AuthenticateResponse>(user);
        response.Token = _jwtUtils.GenerateToken(user);
        return response;
    }

    public IEnumerable<User> GetAll()
    {
        return _context.Users;
    }

    public User GetById(int id)
    {
        return getUser(id);
    }

    // Get user by username

    public User GetByUsername(string username)
    {
		var user = _context.Users.SingleOrDefault(x => x.Username == username);
		if (user == null) throw new KeyNotFoundException("User not found");
		return user;
	}

    public void Register(RegisterRequest model)
    {
        // validate
        if (_context.Users.Any(x => x.Username == model.Username))
            throw new AppException("Username '" + model.Username + "' is already taken");

        // map model to new user object
        var user = _mapper.Map<User>(model);

        // hash password
        user.PasswordHash = BCrypt.HashPassword(model.Password);

        var role = model.Role;
        
        // default isActive to false if role != "Admin"
        if (role != UserRole.Admin)
            user.IsActive = false;
        else
			user.IsActive = true;

        // save user
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateRequest model)
    {
        var user = getUser(id);

        // validate
        if (model.Email != user.Email && _context.Users.Any(x => x.Username == model.Username))
            throw new AppException("Username '" + model.Username + "' is already taken");

        // hash password if it was entered
        if (!string.IsNullOrEmpty(model.Password))
            user.PasswordHash = BCrypt.HashPassword(model.Password);

        // copy model to user and save
        _mapper.Map(model, user);
        _context.Users.Update(user);
        _context.SaveChanges();
    }
    
    public void activate(int id)
    {
		var user = getUser(id);
		user.IsActive = true;
		_context.Users.Update(user);
		_context.SaveChanges();
	}

    public void deactivate(int id)
    {
        var user = getUser(id);
		user.IsActive = false;
		_context.Users.Update(user);
		_context.SaveChanges();
    }
    
    public void Delete(int id)
    {
        var user = getUser(id);
        _context.Users.Remove(user);
        _context.SaveChanges();
    }

    // helper methods

    private User getUser(int id)
    {
        var user = _context.Users.Find(id);
        if (user == null) throw new KeyNotFoundException("User not found");
        return user;
    }

    public IEnumerable<User> GetAllMédecins()
    {
        return _context.Users.Where(x => x.Role == UserRole.Médecin);
    }
}