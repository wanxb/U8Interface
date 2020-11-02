using Hangxin.U8Interface.Application.Models;
using Hangxin.U8Interface.Domain;
using Hangxin.U8Interface.Infrastructure.AspectCore;
using Hangxin.U8Interface.Infrastructure.AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using StackExchange.Profiling;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;


namespace Hangxin.U8Interface.Application.FitemService
{
    public class FitemsQueryHandler : IRequestHandler<FitemsQuery, IEnumerable<FitemDto>>
    {
        IFitemDomain _fitemDomain { get; set; }
        public FitemsQueryHandler(IFitemDomain fitemDomain)
        {
            this._fitemDomain = fitemDomain;
        }

        [SystemLogs]
        public Task<IEnumerable<FitemDto>> Handle(FitemsQuery request, CancellationToken cancellationToken)
        {
            using (MiniProfiler.Current.Step("Fitem"))
            {
                var fitems = _fitemDomain.GetAll();
                return Task.FromResult(fitems.MapTo<IEnumerable<FitemDto>>());
            }
        }
    }
}
