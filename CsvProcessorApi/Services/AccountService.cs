using CsvProcessorApi.Models;
using CsvProcessorApi.Models.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace CsvProcessorApi.Services
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IConfiguration _configuration;

        public AccountService(
            UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IConfiguration configuration
            )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
        }

        public async Task<AuthResponse> UserValidate(LoginModel login)
        {
            var resultado = await _signInManager.PasswordSignInAsync(login.Email, login.Password,
            isPersistent: false, lockoutOnFailure: false);
            if (resultado.Succeeded)
            {
                return await ConstruirToken(login);
            }
            else
            {
                throw new Exception("Login incorrecto");
            }
        }

        public async Task<AuthResponse> UserCreate(LoginModel login)
        {
            var usuario = new IdentityUser { UserName = login.Email, Email = login.Email };
            var resultado = await _userManager.CreateAsync(usuario, login.Password);

            if (resultado.Succeeded)
            {
                return await ConstruirToken(login);
            }
            else
            {
                throw new Exception($"Error creado el usurio: {resultado.Errors.FirstOrDefault()}");
            }
        }

        public async Task<IdentityUser> AdminRolCreate(string userName)
        {
            var usuario = await _userManager.FindByEmailAsync(userName);
            var resultado = await _userManager.AddClaimAsync(usuario, new Claim("role", "admin"));
            if (resultado.Succeeded)
            {
                return usuario;
            }
            else
            {
                throw new Exception($"Error asignando el rol Admin: {resultado.Errors.FirstOrDefault()}");
            }
        }

        public async Task<IdentityUser> AdminRolRemove(string usuarioId)
        {
            var usuario = await _userManager.FindByIdAsync(usuarioId);
            var resultado = await _userManager.RemoveClaimAsync(usuario, new Claim("role", "admin"));
            if (resultado.Succeeded)
            {
                return usuario;
            }
            else
            {
                throw new Exception($"Error removiendo el rol Admin: {resultado.Errors.FirstOrDefault()}");
            }
        }

        private async Task<AuthResponse> ConstruirToken(LoginModel login)
        {
            var claims = new List<Claim>()
            {
                new Claim("email", login.Email)
            };

            var usuario = await _userManager.FindByEmailAsync(login.Email);
            var claimsDB = await _userManager.GetClaimsAsync(usuario);

            claims.AddRange(claimsDB);

            var llave = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["LlaveJWT"]));
            var creds = new SigningCredentials(llave, SecurityAlgorithms.HmacSha256);

            var expiracion = DateTime.UtcNow.AddYears(1);

            var token = new JwtSecurityToken(issuer: null, audience: null, claims: claims,
                expires: expiracion, signingCredentials: creds);

            return new AuthResponse()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiracion = expiracion
            };
        }
    }
}
