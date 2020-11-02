using Hangxin.U8Interface.Domain.Entitys;
using Hangxin.U8Interface.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangxin.U8Interface.Domain.Domain
{
    public class GlAccvouchDomain : IGlAccvouchDomain
    {
        IRepository<GlAccvouch> _Repository { get; set; }
        public GlAccvouchDomain(IRepository<GlAccvouch> Repository)
        {
            this._Repository = Repository;
        }

        public IEnumerable<GlAccvouch> GetAll()
        {
            return _Repository.GetAll().OrderByDescending(c=>c.Ino_Id);
        }

        public void Insert(List<GlAccvouch> list)
        {
            if (list == null)
                return;
            foreach (var item in list)
                _Repository.Insert(item);
        }
    }
}