using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NewslatterWepApi.Dtos;
using NewslatterWepApi.Models;

namespace NewslatterWepApi.Controllers
{
    public class AuthController : Controller
    {
       private readonly NewsLatterDb _newsLatterDb;

        public AuthController(NewsLatterDb newsLatterDb)
        {
            _newsLatterDb = newsLatterDb;
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            var isUserNameExist = await _newsLatterDb.Users.Where(p => p.UsurName == 
            registerDto.UserName).FirstOrDefaultAsync();
            if(isUserNameExist != null)
            {
                return BadRequest("Users already registered!");
            }

            var isUsereEmailExist = await _newsLatterDb.Users.Where(p => p.Email ==
            registerDto.Email).FirstOrDefaultAsync();
            if (isUsereEmailExist != null)
            {
                return BadRequest("Email already registered!");
            };
            User user = new()
            {
                Email = registerDto.Email,
                NameLastName = registerDto.NameLastName,
                Password = registerDto.Password,
                UsurName = registerDto.UserName

            };
            await _newsLatterDb.Users.AddAsync(user);
            await _newsLatterDb.SaveChangesAsync();
            return Ok("Registration completed succesfully");
        }

        [HttpPost("action")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user= await _newsLatterDb.Users.Where(p=>p.UsurName== loginDto.UserName && p.Password ==
            p.Password).FirstOrDefaultAsync();
            if (user == null)
                user = await _newsLatterDb.Users.Where(p => p.Email == loginDto.UserName).FirstOrDefaultAsync();
            if (user == null)
                return BadRequest("Kullanıcı ya da email adresi bulunamadı");
            if (user.Password == loginDto.Password)
                return Ok("Kullanıcı girişi başarılı");
            else
            {
                return BadRequest("Kulanııcı şifresini yanlış girdiniz!");
            }
        }
    }
}
