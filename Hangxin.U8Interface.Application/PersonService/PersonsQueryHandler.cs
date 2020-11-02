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


namespace Hangxin.U8Interface.Application.PersonService
{
    public class PersonsQueryHandler : IRequestHandler<PersonsQuery, IEnumerable<PersonDto>>
    {
        IPersonDomain _personDomain { get; set; } 
        public PersonsQueryHandler(IPersonDomain personDomain)
        {
            this._personDomain = personDomain; 
        }

        [SystemLogs]
        public Task<IEnumerable<PersonDto>> Handle(PersonsQuery request, CancellationToken cancellationToken)
        {
            var persons = _personDomain.GetAll();
            return Task.FromResult(persons.MapTo<IEnumerable<PersonDto>>());
        }
    }
}
