using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Threading;
using System.Threading.Tasks;
using Hangxin.U8Interface.Application.Models;
using Hangxin.U8Interface.Infrastructure.AspectCore;
using IdentityModel;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace Hangxin.U8Interface.Application.JWTService
{
    public class JsonWebTokenHandler : IRequestHandler<JsonWebToken, TokenDto>
    {
        private string _company;
        private SecurityKey _securityKey;
        public JsonWebTokenHandler([FromServices] SymmetricSecurityKey securityKey, IConfiguration configuration)
        {
            this._company = configuration.GetSection("Company").Value;
            this._securityKey = securityKey;
        }
        [SystemLogs]
        public Task<TokenDto> Handle(JsonWebToken request, CancellationToken cancellationToken)
        {
            TokenDto respone = new TokenDto
            {
                Account = request.Company
            };
            //从数据库验证用户名，密码 ,这里从配置文件验证公司名称
            //验证不通过
            if (string.IsNullOrEmpty(request.Company) || request.Company != _company)
                return Task.FromResult(respone);

            //创建claim
            var authClaims = new[] {
                new Claim(JwtClaimTypes.Name,request.Company),
                new Claim(JwtClaimTypes.Role,"user"),//角色
            };
            IdentityModelEventSource.ShowPII = true;
            var token = new JwtSecurityToken(
                   issuer: "Hangxin",//发行方
                   audience: "User",//接收方
                   expires: DateTime.Now.AddHours(8),//有效时间
                   claims: authClaims,
                   signingCredentials: new SigningCredentials(_securityKey, SecurityAlgorithms.HmacSha256)
                   );
            //返回token和过期时间
            respone.Access_token = new JwtSecurityTokenHandler().WriteToken(token);
            respone.Expiration = token.ValidTo.ToLocalTime().ToString("yyyy-MM-dd HH:mm:ss");
            return Task.FromResult(respone);
        }
    }
}
