using Hangxin.U8Interface.Domain.Entitys;
using Hangxin.U8Interface.Infrastructure; 
using System.Collections.Generic;
using System.Linq; 

namespace Hangxin.U8Interface.Domain.Domain
{
    public class CustomerDomain : ICustomerDomain
    {
        IRepository<Customer> _Repository;
        public CustomerDomain(IRepository<Customer> Repository)
        {
            this._Repository = Repository;
        }
        public Customer Get(string id)
        {
            return _Repository.Get(id);
        }
        public IEnumerable<Customer> GetAll()
        {
            return _Repository.GetAll().OrderBy(c => c.CCusCode);
        }
    }
}
