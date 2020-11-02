using Hangxin.U8Interface.Application.Models;
using Hangxin.U8Interface.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangxin.U8Interface.Application
{
    public interface ITestService : IBaseApplication
    {
        TestDto Get(string id);

        void Insert(List<TestDto> list);
    }
}
