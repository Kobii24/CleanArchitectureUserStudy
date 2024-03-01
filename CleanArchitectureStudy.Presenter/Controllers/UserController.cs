using CleanArchitectureStudy.Application.Service;
using CleanArchitectureStudy.Application.VM;
using CleanArchitectureStudy.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureStudy.Presenter.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepo;
        private readonly ITokenRepository _tokenRepo;
        //private IMapper _mapper;
        public UserController(IUserRepository userRepo, ITokenRepository tokenRepo/*, IMapper mapper*/)
        {
            _tokenRepo = tokenRepo;
            _userRepo = userRepo;   
            //_mapper = mapper;
        }

        [HttpGet("/api/[controller]/GetAllUser")]
        public List<User> GetAllUser()
        {
            var users = _userRepo.GetAll();
            return users.ToList();
        }

        [HttpGet("/api/[controller]/GetUserByUserId")]
        public IActionResult GetUserById(int id)
        {
            var existedUser = _userRepo.Get(x => x.userId == id);
            if (existedUser == null)
            {
                return BadRequest();
            }
            //var result = _mapper.Map<User, UserVM>(existedUser);
            return Ok(existedUser);
        }
        [HttpPost("/api/[controller]/AddNewUser")]
        public IActionResult AddNewUser(User user)
        {
            var existedUser = _userRepo.Get(u => u.userId == user.userId);
            if (existedUser != null)
            {
                return BadRequest("User has existed!");
            }
            _userRepo.Add(user);
            _userRepo.Save();
            return Ok(_userRepo.GetAll());
        }
        [HttpPut("/api/[controller]/UpdateUser")]
        public IActionResult UpdateUser(User user)
        {
            var existedUser = _userRepo.Get(u => u.userId == user.userId);
            if(existedUser == null)
            {
                return NotFound("User do not existed to update!");
            }
            _userRepo.Update(user);
            _userRepo.Save();
            //var result = _mapper.Map<User, UserVM>(existedUser);
            return Ok(existedUser);  
        }
        [HttpDelete("/api/[controller]/DeleteUser")]
        public IActionResult DeleteUser(int id)
        {
            var existedUser = _userRepo.Get(u => u.userId == id);
            if (existedUser == null)
            {
                return NotFound("Can not foud user to delete!");
            }
            _userRepo.Remove(existedUser);
            _userRepo.Save();
            return Ok(_userRepo.GetAll());
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("authenticate")]
        public IActionResult Authenticate(User user)
        {
            var token = _tokenRepo.Authenticator(user);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }
    }
}
