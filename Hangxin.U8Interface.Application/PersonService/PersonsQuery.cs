using System.Collections.Generic; 
using Hangxin.U8Interface.Application.Models;
using MediatR; 

namespace Hangxin.U8Interface.Application.PersonService
{
    public class PersonsQuery : IRequest<IEnumerable<PersonDto>>
    { 
        //public string UserName { get; private set; }

    }
}
