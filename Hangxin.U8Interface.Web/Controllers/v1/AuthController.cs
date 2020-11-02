using System.Threading.Tasks;
using Hangxin.U8Interface.Application.JWTService; 
using MediatR;
using Microsoft.AspNetCore.Mvc; 

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hangxin.U8Interface.Web.Controllers.v1
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IMediator _mediator;
        public AuthController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        /// <summary>
        /// 获取AccessToken
        /// </summary> 
        [HttpPost]
        public async Task<IActionResult> AccessToken([FromBody] JsonWebToken jsonWebToken)
        {
            var tokenDto = await _mediator.Send(jsonWebToken);
            if (tokenDto.Access_token == null)
                return NotFound();
            return Ok(tokenDto);
        }
    }
}
