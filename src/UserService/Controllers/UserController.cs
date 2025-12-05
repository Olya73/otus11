using Domain;
using Infrastructure.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserService.Dtos;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly UserDbContext _userDbContext;
        private readonly ILogger<UserController> _logger;

        public UserController(UserDbContext userDbContext, ILogger<UserController> logger)
        {
            _userDbContext = userDbContext;
            _logger = logger;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var user = await _userDbContext.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userDbContext.Users.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            _userDbContext.Remove(user);
            await _userDbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateRequestDto dto)
        {
            var user = await _userDbContext.Users.AsNoTracking().SingleOrDefaultAsync(x => x.UserName == dto.UserName);

            if (user != null)
            {
                return BadRequest();
            }

            var newUser = new User
            {
                UserName = dto.UserName,
                Email = dto.Email,
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Phone = dto.Phone
            };
            _userDbContext.Add(newUser);
            await _userDbContext.SaveChangesAsync();

            return Ok(new { Id = newUser.Id });
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update(UserUpdateRequestDto dto, long id)
        {
            var user = await _userDbContext.Users.SingleOrDefaultAsync(x => x.Id == id);

            if (user == null)
            {
                return NotFound();
            }

            user.FirstName = dto.FirstName ?? user.FirstName;
            user.LastName = dto.LastName ?? user.LastName;
            user.Phone = dto.Phone ?? user.Phone;
            user.Email = dto.Email ?? user.Email;

            await _userDbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
