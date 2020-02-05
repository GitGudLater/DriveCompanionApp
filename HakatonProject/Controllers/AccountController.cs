using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using HakatonProject.EntityModels;
using HakatonProject.ViewModels.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;

/// <summary>
///Make it in Interface and service realization. Add request for companioninformation
/// </summary>
namespace HakatonProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private CompanionContext db;

        public AccountController(CompanionContext context)
        {
            db = context;
        }


        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromBody]Login model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);
                if (user != null)
                {
                    await Authenticate(model.Email); // аутентификация

                    return Ok(model);
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль");
                return Ok(model);
            }
            else
                return BadRequest(ModelState);

        }

        [HttpPut]
        public async Task<IActionResult> Register([FromBody]Registration model)
        {
            if (ModelState.IsValid)
            {
                User user = await db.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (user == null)
                {
                    // добавляем пользователя в бд
                    db.Users.Add(new User { Email = model.Email, Password = model.Password });
                    await db.SaveChangesAsync();

                    await Authenticate(model.Email); // аутентификация

                    return Ok(model);
                }
                else
                    return BadRequest(ModelState);
            }
            return BadRequest(ModelState);
        }

        private async Task Authenticate(string userName)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName)
            };
            // создаем объект ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // установка аутентификационных куки
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }


        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Ok();
        }

        [HttpGet("userInformation")]
        public async Task<UserInformation> GetUserInformation([FromBody] string userEmail)
        {
            User user = await db.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
            UserInformation information = new UserInformation() { Id = user.Id, Email = user.Email, Description = user.Description };
            return information;
        }

        [HttpGet("companionInfromation")]
        public async Task<CompanionInformation> GetCompanionInformation([FromBody] string userEmail)
        {
            User user = await db.Users.FirstOrDefaultAsync(u => u.Email == userEmail);
            CompanionInformation information = new CompanionInformation() { Id = user.Id, Email = user.Email, UserDescription = user.Description };
            return information;
        }
    }
}