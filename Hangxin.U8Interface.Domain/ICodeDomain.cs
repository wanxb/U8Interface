using Hangxin.U8Interface.Domain.Entitys;
using Hangxin.U8Interface.Infrastructure; 
using System.Collections.Generic; 

namespace Hangxin.U8Interface.Domain
{
    public interface ICodeDomain : IBaseDomain
    {
        Code Get(string id);
        IEnumerable<Code> GetAll(); 
    }
}
