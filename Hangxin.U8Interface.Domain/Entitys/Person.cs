using System; 
using Dapper.Contrib.Extensions;
using Hangxin.U8Interface.Infrastructure; 

namespace Hangxin.U8Interface.Domain.Entitys
{
    [Table("Person")]
    public class Person : IEntity
    {
        [Key]
        public string CPersonCode { get; set; }
        public string CPersonName { get; set; }
        public string CDepCode { get; set; }
        public string CPersonProp { get; set; }
        public double? FCreditQuantity { get; set; }
        public int? ICreDate { get; set; }
        public string CCreGrade { get; set; }
        public double? ILowRate { get; set; }
        public string COfferGrade { get; set; }
        public double? IOfferRate { get; set; } 
        public string CPersonEmail { get; set; }
        public string CPersonPhone { get; set; }
        public DateTime? DPvalidDate { get; set; }
        public DateTime? DPinValidDate { get; set; }
    }
}
