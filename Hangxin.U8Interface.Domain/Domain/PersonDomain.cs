using Hangxin.U8Interface.Domain.Entitys;
using Hangxin.U8Interface.Infrastructure; 
using System.Collections.Generic;
using System.Linq; 

namespace Hangxin.U8Interface.Domain.Domain
{
    public class PersonDomain : IPersonDomain
    {
        IRepository<Person> _Repository;
        public PersonDomain(IRepository<Person> Repository)
        {
            this._Repository = Repository;
        }
        public Person Get(string id)
        {
            return _Repository.Get(id);
        }
        public IEnumerable<Person> GetAll()
        {
            return _Repository.GetAll().OrderBy(c => c.CPersonCode);
        }
    }
}
