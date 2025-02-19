using Microsoft.AspNetCore.Mvc;
using APIshka.DbContexts;
using APIshka.Request;

namespace APIshka.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserLogin : ControllerBase
    {

        [HttpPost] 
        public IActionResult Authorization(UserLoginRequest request)
        {
            string username = request.Username;
            string password = request.Password;

            if (string.IsNullOrWhiteSpace(username))
            {
                return BadRequest("Имя пользователя не может быть пустым");
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return BadRequest("Пароль не может быть пустым");
            }

            AppDbContext dbContext = new AppDbContext ();

            bool isUsernameCorrect = dbContext.Users.Any(u => u.Username == username);
            bool isPasswordCorrect = dbContext.Users.Any(u => u.Password == password);

            if (!isUsernameCorrect || !isPasswordCorrect)
            {
                return NotFound("Не правильный логин или пароль");
            }

            var user = dbContext.Users.SingleOrDefault (u => u.Username == username);
            Memmory.UserId = user.UserId;
            return Ok(user);
        }
    }
}
