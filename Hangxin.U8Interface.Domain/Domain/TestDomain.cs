using System;
using System.Collections.Generic;
using System.Text;
using Hangxin.U8Interface.Domain.Entitys;
using Hangxin.U8Interface.Infrastructure;

namespace Hangxin.U8Interface.Domain.Domain
{
    public class TestDomain : ITestDomain
    {
        IRepository<Test> _testRepository { get; set; }
        public TestDomain(IRepository<Test> testRepository)
        {
            this._testRepository = testRepository;
        }

        public Test Get(string id)
        {
            return _testRepository.Get(id);
        }

        public void Insert(List<Test> list)
        {
            if (list == null)
                return;
            foreach(var item in list)
                _testRepository.Insert(item);
        }
    }
}
