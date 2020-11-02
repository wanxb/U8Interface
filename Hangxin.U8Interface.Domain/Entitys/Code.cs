using Dapper.Contrib.Extensions;
using Hangxin.U8Interface.Infrastructure; 

namespace Hangxin.U8Interface.Domain.Entitys
{
    [Table("Code")]
    public partial class Code : IEntity
    { 
        [Key]
        public string Ccode { get; set; }
        public string Ccode_Name { get; set; } 
        public bool Bperson { get; set; }
        public bool Bcus { get; set; }
        public bool Bsup { get; set; }
        public bool Bdept { get; set; }
        public bool Bitem { get; set; }
        public string Cass_Item { get; set; }
        public bool bEnd { get; set; }
    }
}
