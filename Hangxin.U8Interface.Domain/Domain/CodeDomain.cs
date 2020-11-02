using Hangxin.U8Interface.Domain.Entitys;
using Hangxin.U8Interface.Infrastructure; 
using System.Collections.Generic;
using System.Linq; 

namespace Hangxin.U8Interface.Domain.Domain
{
    public class CodeDomain : ICodeDomain
    {
        IRepository<Code> _Repository;
        public CodeDomain(IRepository<Code> Repository)
        {
            this._Repository = Repository;
        }
        public Code Get(string id)
        {
            return _Repository.Get(id);
        }
        public IEnumerable<Code> GetAll()
        {
            return _Repository.GetAll().OrderBy(c => c.Ccode);
        }
    }
}
