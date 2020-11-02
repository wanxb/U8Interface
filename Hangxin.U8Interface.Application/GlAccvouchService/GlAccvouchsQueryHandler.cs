using Hangxin.U8Interface.Domain;
using Hangxin.U8Interface.Domain.Entitys;
using Hangxin.U8Interface.Infrastructure.AspectCore;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hangxin.U8Interface.Application.GlAccvouchService
{
    public class GlAccvouchsQueryHandler : IRequestHandler<GlAccvouchsQuery, IEnumerable<GlAccvouch>>
    {
        IGlAccvouchDomain _glAccvouchDomain { get; set; }
        public GlAccvouchsQueryHandler(IGlAccvouchDomain glAccvouchDomain)
        {
            this._glAccvouchDomain = glAccvouchDomain;
        }

        [SystemLogs]
        public Task<IEnumerable<GlAccvouch>> Handle(GlAccvouchsQuery request, CancellationToken cancellationToken)
        {
            var glAccvouchs = _glAccvouchDomain.GetAll();
            return Task.FromResult(glAccvouchs);
        }
    }
}

