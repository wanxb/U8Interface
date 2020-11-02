using Hangxin.U8Interface.Application.FitemService;
using Hangxin.U8Interface.Application.Models;
using Hangxin.U8Interface.Domain;
using Hangxin.U8Interface.Infrastructure.AspectCore;
using Hangxin.U8Interface.Infrastructure.AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using StackExchange.Profiling;
using System.Threading;
using System.Threading.Tasks;


namespace Hangxin.U8Interface.Application.FitemService
{
    public class FitemQueryOneHandler : IRequestHandler<FitemQueryOne, FitemDto>
    {
        IFitemDomain _fitemDomain { get; set; } 
        public FitemQueryOneHandler(IFitemDomain fitemDomain)
        {
            this._fitemDomain = fitemDomain; 
        }

        [SystemLogs]
        public Task<FitemDto> Handle(FitemQueryOne request, CancellationToken cancellationToken)
        {
            var fitem = _fitemDomain.Get(request.cItemClass);
            return Task.FromResult(fitem.MapTo<FitemDto>());
        }
    }
}
