using System.Collections.Generic; 
using Hangxin.U8Interface.Application.Models;
using MediatR; 

namespace Hangxin.U8Interface.Application.CodeService
{
    public class CodesQuery : IRequest<IEnumerable<CodeDto>>
    { 
        //public string UserName { get; private set; }

    }
}
