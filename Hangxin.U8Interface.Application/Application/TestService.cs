using Hangxin.U8Interface.Application.Models;
using Hangxin.U8Interface.Domain;
using Hangxin.U8Interface.Domain.Entitys;
using StackExchange.Profiling;
using System.Collections.Generic;
using Hangxin.U8Interface.Infrastructure.AspectCore;
using Hangxin.U8Interface.Infrastructure.AutoMapper;

namespace Hangxin.U8Interface.Application.Application
{
    public class TestService : ITestService
    {
        ITestDomain _testDomain { get; set; }
        public TestService(ITestDomain testDomain)
        {
            this._testDomain = testDomain;
        }

        [Transactional]
        public TestDto Get(string id)
        {
            using (MiniProfiler.Current.Step("一个测试"))
            {
                var test = _testDomain.Get(id);
                return test.MapTo<TestDto>();
            }
        }


        [Transactional]
        public void Insert(List<TestDto> list)
        {
            var listTest = list.MapToList<Test>();
            _testDomain.Insert(listTest);
        }
    }
}
