using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NZWalks.API.Models.DTOs;
using NZWalks.API.Repositories;

namespace NZWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;

        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDTO registerRequestDTO)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDTO.UserName,
                Email = registerRequestDTO.UserName
            };
          var identityResult =   await userManager.CreateAsync(identityUser, registerRequestDTO.Password);
            if (identityResult.Succeeded) 
            {
                // Add Roles
                if (registerRequestDTO.Roles != null && registerRequestDTO.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDTO.Roles);

                    if (identityResult.Succeeded) 
                    {
                        return Ok("User registered. Please login");
                    }
                }
            }
            return BadRequest("Something went wrong");
        }


        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO loginDTO)
        {
          var user =  await userManager.FindByEmailAsync(loginDTO.UserName);
            if (user != null) 
            {
              var checkPasswrodResult =   await userManager.CheckPasswordAsync(user, loginDTO.Password);
                if (checkPasswrodResult)
                {
                    // if successful

                    // Get roles for this user

                    var roles = await userManager.GetRolesAsync(user);

                    if (roles != null) 
                    {
                        // Create Token

                      var jwtToken =  tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDTO
                        {
                            jwtToken = jwtToken,
                        };
                        return Ok(response);
                    }

                }
            }
            return BadRequest("Username or password is incorrect.");
        }
    }
}
