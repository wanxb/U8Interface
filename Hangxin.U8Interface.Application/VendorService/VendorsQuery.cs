using System.Collections.Generic; 
using Hangxin.U8Interface.Application.Models;
using MediatR; 

namespace Hangxin.U8Interface.Application.VendorService
{
    public class VendorsQuery : IRequest<IEnumerable<VendorDto>>
    { 
        //public string UserName { get; private set; }

    }
}
