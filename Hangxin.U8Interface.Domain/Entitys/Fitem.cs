using System;
using Dapper.Contrib.Extensions;
using Hangxin.U8Interface.Infrastructure;

namespace Hangxin.U8Interface.Domain.Entitys
{
    [Table("Fitem")]
    public partial class Fitem : IEntity
    { 
        public int I_Id { get; set; }
        [Key]
        public string Citem_Class { get; set; }
        public string Citem_Name { get; set; }
        public string Citem_Text { get; set; }
        public string Crule { get; set; }
        public string Ctable { get; set; }
        public string CClasstable { get; set; }
        public byte[] Pubufts { get; set; }
    }
}
