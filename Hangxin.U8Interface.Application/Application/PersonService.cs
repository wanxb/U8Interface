using Hangxin.U8Interface.Application.Models;
using Hangxin.U8Interface.Domain;
using Hangxin.U8Interface.Infrastructure.AspectCore;
using Hangxin.U8Interface.Infrastructure.AutoMapper;
using StackExchange.Profiling; 
using System.Collections.Generic; 

namespace Hangxin.U8Interface.Application.Application
{
    public class PersonService : IPersonService
    {
        IPersonDomain _personDomain { get; set; }
        public PersonService(IPersonDomain personDomain)
        {
            this._personDomain = personDomain;
        }

        [Transactional]
        public IEnumerable<PersonDto> GetAll()
        {
            using (MiniProfiler.Current.Step("查询数据"))
            {
                var persons = _personDomain.GetAll();
                return persons.MapTo<IEnumerable<PersonDto>>();
            }
        }
    }
}
