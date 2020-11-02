using Hangxin.U8Interface.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangxin.U8Interface.Domain.Models
{
    public class ItemDto: IEntity
    {
        public string cItemCode { get; set; }
        public string cItemName { get; set; }
        public string cItemCCode { get; set; }
        public string cItemCName { get; set; }
    }
}
