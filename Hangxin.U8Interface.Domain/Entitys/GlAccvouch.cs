using Dapper.Contrib.Extensions;
using Hangxin.U8Interface.Infrastructure;
using System;

namespace Hangxin.U8Interface.Domain.Entitys
{
    [Table("Gl_Accvouch")]
    public partial class GlAccvouch : IEntity
    {
        [Key]
        public int I_Id { get; set; }
        public byte Iperiod { get; set; }
        public string Csign { get; set; } = "记";
        public int? Isignseq { get; set; } = 1;
        public short Ino_Id { get; set; }
        public short Inid { get; set; }
        public DateTime Dbill_Date { get; set; }
        public short Idoc { get; set; } = 1;
        public string Cbill { get; set; }
        public string Ccheck { get; set; }
        public string Cbook { get; set; }
        public byte Ibook { get; set; } = 0;
        public string Ccashier { get; set; }
        public byte? Iflag { get; set; }
        public string Ctext1 { get; set; }
        public string Ctext2 { get; set; }
        public string Cdigest { get; set; }
        public string Ccode { get; set; }
        public string Cexch_Name { get; set; }
        public decimal Md { get; set; }
        public decimal Mc { get; set; }
        public decimal Md_F { get; set; } = 0;
        public decimal Mc_F { get; set; } = 0;
        public double Nfrat { get; set; } = 0;
        public double Nd_S { get; set; } = 0;
        public double Nc_S { get; set; } = 0;
        public string Csettle { get; set; }
        public string Cn_Id { get; set; }
        public DateTime? Dt_Date { get; set; }
        public string Cdept_Id { get; set; }
        public string Cperson_Id { get; set; }
        public string Ccus_Id { get; set; }
        public string Csup_Id { get; set; }
        public string Citem_Id { get; set; }
        public string Citem_Class { get; set; }
        public string Cname { get; set; }
        public string Ccode_Equal { get; set; }
        public byte? Iflagbank { get; set; }
        public byte? IflagPerson { get; set; }
        public bool? Bdelete { get; set; } = false;
        public string Coutaccset { get; set; }
        public short? Ioutyear { get; set; }
        public string Coutsysname { get; set; }
        public string Coutsysver { get; set; }
        public DateTime? Doutbilldate { get; set; }
        public byte? Ioutperiod { get; set; }
        public string Coutsign { get; set; }
        public string Coutno_Id { get; set; }
        public DateTime? Doutdate { get; set; }
        public string Coutbillsign { get; set; }
        public string Coutid { get; set; }
        public bool? Bvouchedit { get; set; } = true;
        public bool? BvouchAddordele { get; set; } = false;
        public bool? Bvouchmoneyhold { get; set; } = false;
        public bool? Bvalueedit { get; set; } = true;
        public bool? Bcodeedit { get; set; } = true;
        public string Ccodecontrol { get; set; }
        public bool? BPcsedit { get; set; } = true;
        public bool? BDeptedit { get; set; } = true;
        public bool? BItemedit { get; set; } = true;
        public bool? BCusSupInput { get; set; } = false;
        public string CDefine1 { get; set; }
        public string CDefine2 { get; set; }
        public string CDefine3 { get; set; }
        public DateTime? CDefine4 { get; set; }
        public int? CDefine5 { get; set; }
        public DateTime? CDefine6 { get; set; }
        public double? CDefine7 { get; set; }
        public string CDefine8 { get; set; }
        public string CDefine9 { get; set; }
        public string CDefine10 { get; set; }
        public string CDefine11 { get; set; }
        public string CDefine12 { get; set; }
        public string CDefine13 { get; set; }
        public string CDefine14 { get; set; }
        public int? CDefine15 { get; set; }
        public double? CDefine16 { get; set; }
        public DateTime? DReceive { get; set; }
        public string CWldzflag { get; set; }
        public DateTime? DWldztime { get; set; }
        public bool? BFlagOut { get; set; } = false;
        public int? IBg_OverFlag { get; set; }
        public string CBg_Auditor { get; set; }
        public DateTime? DBg_AuditTime { get; set; }
        public string CBg_AuditOpinion { get; set; }
        public bool? BWh_BgFlag { get; set; }
        public int? Ssxznum { get; set; }
        public string CerrReason { get; set; }
        public string Bg_AuditRemark { get; set; }
        public string CBudgetBuffer { get; set; }
        public short? IBg_ControlResult { get; set; }
        public string NcvouchId { get; set; }
        public DateTime? Daudit_Date { get; set; }
        public string RowGuid { get; set; } = Guid.NewGuid().ToString();
        public string CBankReconNo { get; set; }
        public short? Iyear { get; set; }
        public int? IYperiod { get; set; }
        public DateTime? WllqDate { get; set; }
        public int? WllqPeriod { get; set; }
        public DateTime? Tvouchtime { get; set; } = DateTime.Now;
        public string Cblueoutno_Id { get; set; }
        public string Ccodeexch_Equal { get; set; }
        public string Cpzchcode { get; set; }
    } 
}
