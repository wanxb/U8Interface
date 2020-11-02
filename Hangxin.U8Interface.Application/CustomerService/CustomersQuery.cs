using System.Collections.Generic; 
using Hangxin.U8Interface.Application.Models;
using MediatR; 

namespace Hangxin.U8Interface.Application.CustomerService
{
    public class CustomersQuery : IRequest<IEnumerable<CustomerDto>>
    { 
        //public string UserName { get; private set; }

    }
}
