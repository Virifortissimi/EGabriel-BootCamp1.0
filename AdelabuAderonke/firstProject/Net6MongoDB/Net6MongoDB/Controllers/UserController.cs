using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Net6MongoDB.Models;
using Net6MongoDB.Repository;

namespace Net6MongoDB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo UserRepo)
        {
            _userRepo = UserRepo;
        }
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            if (user == null)
                return BadRequest("User must not be null");
            await _userRepo.CreateUser(user);
            return Ok(user);
        }
        [HttpGet("/get-all")]

        public async Task<IActionResult> GetAll()
        {
            var allUsers =  await _userRepo.GetAll();
            return Ok(allUsers);
        }
        [HttpGet("/get")]
        public async Task<IActionResult> GetOne(string Id)
        {
            var user = await _userRepo.Get(Id);
            return Ok(user);
        }
        [HttpPut]
        public async Task<IActionResult> Update(string Id, User user)
        {
            var updated = await _userRepo.Update(Id, user);
            return Ok(user);
        }
    }
}
