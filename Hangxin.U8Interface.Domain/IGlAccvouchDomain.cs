using Hangxin.U8Interface.Domain.Entitys;
using Hangxin.U8Interface.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangxin.U8Interface.Domain
{
    public interface IGlAccvouchDomain : IBaseDomain
    {
        IEnumerable<GlAccvouch> GetAll();
        void Insert(List<GlAccvouch> list);
    }
}
