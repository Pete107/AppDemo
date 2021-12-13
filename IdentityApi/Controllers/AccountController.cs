using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using CoreLibrary.DataTransfer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace IdentityApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<AccountController> _logger;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, ILogger<AccountController> logger)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var res = await _signInManager.PasswordSignInAsync(request.Username, request.Password, false,
                false);
            if (res is null || !res.Succeeded)
                return Unauthorized();
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user is null)
                return Unauthorized();

            return Ok(CreateTokenModel(user));
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel request)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var newUser = new IdentityUser(request.Username)
            {
                Email = request.EmailAddress
            };
            var createRes = await _userManager.CreateAsync(newUser, request.Password);
            if (createRes is null || !createRes.Succeeded)
            {
                return BadRequest();
            }

            await _signInManager.SignInAsync(newUser, false);
            return Ok(CreateTokenModel(newUser));
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get() => Ok();

        [HttpGet("renew-token")]
        [Authorize]
        public async Task<IActionResult> RenewToken()
        {
            if (User.Identity?.IsAuthenticated != true) return Unauthorized();
            var email = User.FindFirst("Email");
            if (email is null)
                return Unauthorized();

            var userFromEmail = await _userManager.FindByEmailAsync(email.Value);
            if (userFromEmail is null)
                return Unauthorized();
            return Ok(CreateTokenModel(userFromEmail));
        }


        private string GenerateAccessToken(IdentityUser user)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim("Email", user.Email),
                new Claim(JwtRegisteredClaimNames.NameId, user.Id)
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_SECRET")));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = Environment.GetEnvironmentVariable("AUDIENCE"),
                Issuer = Environment.GetEnvironmentVariable("ISSUER"),
                IssuedAt = DateTime.UtcNow,
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                Subject = new ClaimsIdentity(claims)
            };
            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(tokenDescriptor);
            return handler.WriteToken(token);
        }

        private TokenModel CreateTokenModel(IdentityUser user)
        {
            return new TokenModel
            {
                Token = GenerateAccessToken(user),
                ExpireTime = DateTime.UtcNow.AddHours(12),
                UserId = user.Id
            };
        }
    }
}
