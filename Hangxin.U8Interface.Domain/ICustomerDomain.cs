using Hangxin.U8Interface.Domain.Entitys;
using Hangxin.U8Interface.Infrastructure; 
using System.Collections.Generic; 

namespace Hangxin.U8Interface.Domain
{
    public interface ICustomerDomain : IBaseDomain
    {
        Customer Get(string id);
        IEnumerable<Customer> GetAll(); 
    }
}
