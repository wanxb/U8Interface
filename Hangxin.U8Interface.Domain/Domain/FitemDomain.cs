using Hangxin.U8Interface.Domain.Entitys;
using Hangxin.U8Interface.Infrastructure;
using System.Collections.Generic;
using System.Linq; 

namespace Hangxin.U8Interface.Domain.Domain
{
    public class FitemDomain : IFitemDomain
    {
        IRepository<Fitem> _Repository;
        public FitemDomain(IRepository<Fitem> Repository)
        {
            this._Repository = Repository;
        }
        public Fitem Get(string id)
        {
            return _Repository.Get(id);
        }
        public IEnumerable<Fitem> GetAll()
        {
            return _Repository.GetAll().OrderBy(c => c.Citem_Class);
        }
    }
}
