using System.Collections.Generic;
using Hangxin.U8Interface.Application.Models;
using MediatR; 

namespace Hangxin.U8Interface.Application.FitemService
{
    public class FitemsQuery : IRequest<IEnumerable<FitemDto>>
    {
        //public string cItemClass { get; set; }

    }
}
