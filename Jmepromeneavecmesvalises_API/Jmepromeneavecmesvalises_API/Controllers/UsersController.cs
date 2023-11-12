using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Jmepromeneavecmesvalises_API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Jmepromeneavecmesvalises_API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        readonly UserManager<User> UserManager;

        public UsersController(UserManager<User> userManager)
        {
            UserManager = userManager;
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterDTO DTO)
        {
            if (DTO.Password != DTO.ConfirmPassword)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "Les mots de passe ne correspondent pas." });
            }

            User user = new User()
            {
                UserName = DTO.Email,
                Email = DTO.Email
            };

            IdentityResult result = await UserManager.CreateAsync(user, DTO.Password);

            if (!result.Succeeded)
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "L'utilisateur n'a pas pu être créé." });
            }
            
            LoginDTO loginDTO = new LoginDTO()
            {
                Username = DTO.Email,
                Password = DTO.Password
            };
            
            return await Login(loginDTO);
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginDTO DTO)
        {
            User user = await UserManager.FindByNameAsync(DTO.Username);
            if (user != null && await UserManager.CheckPasswordAsync(user, DTO.Password))
            {
                IList<string> roles = await UserManager.GetRolesAsync(user);
                List<Claim> authClaims = new List<Claim>();
                foreach (string role in roles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, role));
                }

                authClaims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id));

                SymmetricSecurityKey key =
                    new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes("Loo00ongue Phrase SiNoN Ca ne Marchera PaAaAAAaAas"));
                JwtSecurityToken token = new JwtSecurityToken(
                    issuer: "https://localhost:7023",
                    audience: "https://localhost:4200",
                    expires: DateTime.Now.AddHours(1),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature)
                );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            else
            {
                return StatusCode(StatusCodes.Status400BadRequest,
                    new { Message = "Le nom d'utilisateur ou le mot de passe est invaldie." });
            }
        }
    }
}