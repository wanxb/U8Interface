using Hangxin.U8Interface.Domain.Entitys;
using Hangxin.U8Interface.Infrastructure; 
using System.Collections.Generic; 

namespace Hangxin.U8Interface.Domain
{
    public interface ITestDomain : IBaseDomain
    {
        Test Get(string id);

        void Insert(List<Test> list);
    }
}
