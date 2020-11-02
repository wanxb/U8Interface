using System;
using Dapper.Contrib.Extensions;
using Hangxin.U8Interface.Infrastructure;

namespace Hangxin.U8Interface.Domain.Entitys
{
    [Table("Fitemss98")]
    public partial class Fitemss98 : IEntity
    {
        [Key]
        public int I_Id { get; set; }
        public string Citemcode { get; set; }
        public string Citemname { get; set; }
        public bool? Bclose { get; set; }
        public string Citemccode { get; set; }
        public int? Iotherused { get; set; }
        public string CDirection { get; set; }
    }
}
