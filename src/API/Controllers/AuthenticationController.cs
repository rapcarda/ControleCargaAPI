using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Extensions;
using API.ViewModel.TokenControl;
using API.ViewModel.User;
using Business.Interfaces.Service;
using Business.Interfaces.Shared;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class AuthenticationController : BaseController
    {
        private readonly IUsuarioService _usuarioService;
        private readonly AppSettings _appSettings;

        public AuthenticationController(IUsuarioService usuarioService,
                                        IOptions<AppSettings> appSettings,
                                        INotificator notificator): base(notificator)
        {
            _usuarioService = usuarioService;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginUserViewModel loginUser)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            var user = await _usuarioService.FindUserByLoginAndPassword(loginUser.Login, loginUser.Password);
            
            if (user == null)
            {
                NotifyError("Nenhum usuário encontrado com este login/senha");
                return CustomResponse(loginUser);
            }

            return CustomResponse(await GerarJwt(user));
        }

        private async Task<LoginResponseViewModel> GerarJwt(Usuario user)
        {
            var claims = new List<Claim>();

            /* Adiciona algumas claims para uso interno */
            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())); // ID próprio do token
            claims.Add(new Claim(JwtRegisteredClaimNames.Nbf, ToUnixEpochDate(DateTime.UtcNow).ToString()));
            claims.Add(new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(DateTime.UtcNow).ToString(), ClaimValueTypes.Integer64));

            /* Converte as claims, para o tipo aceito pelo token, que são claims do tipo do identity */
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            /* var para manipular o token */
            var tokenHandler = new JwtSecurityTokenHandler();

            /* Gera uma chave */
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            /* Cria o token */
            var token = tokenHandler.CreateToken(new SecurityTokenDescriptor
            {
                /* Aqui passa as coordenadas para o jwt criar o token */
                Issuer = _appSettings.Emissor,
                Audience = _appSettings.ValidoEm,
                Subject = identityClaims, //passa para o token, todas as claims do usuário
                Expires = DateTime.UtcNow.AddHours(_appSettings.ExpiracaoHoras),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            });

            var encodedToken = tokenHandler.WriteToken(token);

            var response = new LoginResponseViewModel
            {
                AccessToken = encodedToken,
                ExpiresIn = TimeSpan.FromHours(_appSettings.ExpiracaoHoras).TotalSeconds,
                UserToken = new UserTokenViewModel
                {
                    Id = user.Id.ToString(),
                    Username = user.Login,
                    Nome = user.Nome
                }
            };

            return response;
        }

        private static long ToUnixEpochDate(DateTime date)
            => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
    }
}
