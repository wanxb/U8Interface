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


namespace Hangxin.U8Interface.Application.CodeService
{
    public class CodesQueryHandler : IRequestHandler<CodesQuery, IEnumerable<CodeDto>>
    {
        ICodeDomain _codeDomain { get; set; } 
        public CodesQueryHandler(ICodeDomain codeDomain)
        {
            this._codeDomain = codeDomain; 
        }

        [SystemLogs]
        public Task<IEnumerable<CodeDto>> Handle(CodesQuery request, CancellationToken cancellationToken)
        {
            using (MiniProfiler.Current.Step("Code"))
            {
                var codes = _codeDomain.GetAll();
                return Task.FromResult(codes.MapTo<IEnumerable<CodeDto>>());
            }
        }
    }
}
