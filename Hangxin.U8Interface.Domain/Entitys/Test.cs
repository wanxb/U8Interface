using Dapper.Contrib.Extensions;
using Hangxin.U8Interface.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangxin.U8Interface.Domain.Entitys
{

    [Table("test")]
    public class Test : IEntity
    {
        [ExplicitKey]
        public string ID { get; set; }
        public string Title { get; set; }
    }
}
