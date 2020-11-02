using Hangxin.U8Interface.Application.Models;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Hangxin.U8Interface.Application.JWTService
{
    public class JsonWebToken : IRequest<TokenDto>
    {
        public JsonWebToken(string company, string account, string password)
        {
            Company = company;
            Account = account;
            Password = password;
        }
        [Required]
        public string Company { get; private set; }
        public string Account { get; private set; }
        public string Password { get; private set; }
    }
}
