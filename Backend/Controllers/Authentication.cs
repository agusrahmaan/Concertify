using Backend.Dto;
using Backend.Interface;
using Backend.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Authentication : ControllerBase
    {
        private readonly IAccount _accountRepo;
        private readonly IConfiguration _config;
        public Authentication(IAccount accountRepo, IConfiguration configuration)
        {
            _accountRepo = accountRepo;
            _config = configuration;
        }

        [HttpPost("Register")]
        public IActionResult Register(Account account)
        {
            var username = _accountRepo.GetAccountByUsername(account.Username);
            var name = _accountRepo.GetAccountByName(account.Name);
            var email = _accountRepo.GetAccountByEmail(account.Email);
            var phone = _accountRepo.GetAccountByPhone(account.Phone);

            if (username != null)
            {
                return BadRequest("Username Already Exist");
            }
            else if(name != null)
            {
                return BadRequest("Name Already Exist");
            }
            else if (email != null)
            {
                return BadRequest("Email Already Exist");
            }
            else if (phone != null)
            {
                return BadRequest("Phone Already Exist");
            }
            else
            {
                string saltPassword = BCrypt.Net.BCrypt.GenerateSalt();
                string hashPassword = BCrypt.Net.BCrypt.HashPassword(account.Password, saltPassword);

                var registerAccount = new Account
                {
                    Username = account.Username,
                    Password = hashPassword,
                    Name = account.Name,
                    Email = account.Email,
                    Phone = account.Phone
                };

                _accountRepo.Register(registerAccount);
                return Ok("Register Success");
            }
        }

        [HttpPost("Login")]
        public IActionResult Login(LoginDto loginDto)
        {
            var checkAccount = _accountRepo.GetAccountByUsername(loginDto.username);

            if (checkAccount == null)
            {
                return BadRequest("Account Not Found");
            }
            else
            {
                if (!BCrypt.Net.BCrypt.Verify(loginDto.password, checkAccount.Password))
                {
                    return BadRequest("Wrong Password");
                }
                string token = CreateToken(checkAccount);
                return Ok(token);
            }
        }

        private string CreateToken(Account account)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, account.Username),
                new Claim(ClaimTypes.NameIdentifier, account.Name),
                new Claim(ClaimTypes.Email, account.Email),
                new Claim(ClaimTypes.MobilePhone, account.Phone)
            };

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("AppSettings:Token").Value!));

            var credential = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddHours(1),
                    signingCredentials: credential
                );
            var sendToken = new JwtSecurityTokenHandler().WriteToken(token);
            return sendToken;
        }
    }
}
