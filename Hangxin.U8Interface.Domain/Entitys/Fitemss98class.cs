using System;
using Dapper.Contrib.Extensions;
using Hangxin.U8Interface.Infrastructure;

namespace Hangxin.U8Interface.Domain.Entitys
{
    [Table("Fitemss98class")]
    public partial class Fitemss98class : IEntity
    {
        [Key]
        public int I_Id { get; set; }
        public string CItemCcode { get; set; }
        public string CItemCname { get; set; }
        public byte IItemCgrade { get; set; }
        public bool BItemCend { get; set; }
    }
}
