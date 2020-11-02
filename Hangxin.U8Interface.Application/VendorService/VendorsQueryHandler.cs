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


namespace Hangxin.U8Interface.Application.VendorService
{
    public class VendorsQueryHandler : IRequestHandler<VendorsQuery, IEnumerable<VendorDto>>
    {
        IVendorDomain _vendorDomain { get; set; }
        public VendorsQueryHandler(IVendorDomain vendorDomain)
        {
            this._vendorDomain = vendorDomain;
        }

        [SystemLogs]
        public Task<IEnumerable<VendorDto>> Handle(VendorsQuery request, CancellationToken cancellationToken)
        {
            var vendors = _vendorDomain.GetAll();
            return Task.FromResult(vendors.MapTo<IEnumerable<VendorDto>>());
        }
    }
}
