using Hangxin.U8Interface.Domain.Entitys;
using Hangxin.U8Interface.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangxin.U8Interface.Domain.Domain
{
    public class VendorDomain : IVendorDomain
    {
        IRepository<Vendor> _Repository;
        public VendorDomain(IRepository<Vendor> Repository)
        {
            this._Repository = Repository;
        }
        public Vendor Get(string id)
        {
            return _Repository.Get(id);
        }
        public IEnumerable<Vendor> GetAll()
        {
            return _Repository.GetAll().OrderBy(c => c.CVenCode);
        }
    }
}
