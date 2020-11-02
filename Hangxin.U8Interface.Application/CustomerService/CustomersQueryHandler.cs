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


namespace Hangxin.U8Interface.Application.CustomerService
{
    public class CustomersQueryHandler : IRequestHandler<CustomersQuery, IEnumerable<CustomerDto>>
    {
        ICustomerDomain _customerDomain { get; set; } 
        public CustomersQueryHandler(ICustomerDomain customerDomain)
        {
            this._customerDomain = customerDomain; 
        }

        [SystemLogs]
        public Task<IEnumerable<CustomerDto>> Handle(CustomersQuery request, CancellationToken cancellationToken)
        {
            var customers = _customerDomain.GetAll();
            return Task.FromResult(customers.MapTo<IEnumerable<CustomerDto>>());
        }
    }
}
