using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlTypes;
using System.Text;

namespace Hangxin.U8Interface.Application.Models
{
    public class GLAccvouchDto
    {
        /// <summary>
        /// 外部单号
        /// </summary>
        [MaxLength(20)]
        public string cBillCode { get; set; }
        /// <summary>
        /// 摘要 
        /// </summary>
        [Required]
        [MaxLength(120)]
        public string cDigest { get; set; }
        /// <summary>
        /// 科目代码
        /// </summary>
        [Required]
        [MaxLength(15)]
        public string cCode { get; set; }
        /// <summary>
        /// 贷方金额
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal mcMoney { get; set; }
        /// <summary>
        /// 借方金额
        /// </summary>
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal mdMoney { get; set; }
        /// <summary>
        /// 凭证日期
        /// </summary>
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? cBillDate { get; set; }
        /// <summary>
        /// 人员核算编号
        /// </summary>
        [MaxLength(20)]
        public string cPersonCode { get; set; }
        /// <summary>
        /// 部门核算编号
        /// </summary>
        [MaxLength(12)]
        public string cDepCode { get; set; }
        /// <summary>
        /// 客户核算编号
        /// </summary>
        [MaxLength(20)]
        public string cCusCode { get; set; }
        /// <summary>
        /// 供应商核算编号
        /// </summary>
        [MaxLength(20)]
        public string cSupCode { get; set; }
        /// <summary>
        /// 项目核算编号
        /// </summary>
        [MaxLength(20)]
        public string cItemCode { get; set; }
        /// <summary>
        /// 项目大类编号
        /// </summary>
        [MaxLength(2)]
        public string cItemClass { get; set; }
        /// <summary>
        /// 制单人
        /// </summary> 
        [Required]
        [MaxLength(20)]
        public string cBillUser { get; set; }
    }
}
