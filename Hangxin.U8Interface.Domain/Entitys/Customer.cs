﻿using System;
using Dapper.Contrib.Extensions;
using Hangxin.U8Interface.Infrastructure;

namespace Hangxin.U8Interface.Domain.Entitys
{
    [Table("Customer")]
    public partial class Customer : IEntity
    {
        [Key]
        public string CCusCode { get; set; }
        public string CCusName { get; set; }
        public string CCusAbbName { get; set; }
        public string CCccode { get; set; }
        public string CDccode { get; set; }
        public string CTrade { get; set; }
        public string CCusAddress { get; set; }
        public string CCusPostCode { get; set; }
        public string CCusRegCode { get; set; }
        public string CCusBank { get; set; }
        public string CCusAccount { get; set; }
        public DateTime? DCusDevDate { get; set; }
        public string CCusLperson { get; set; }
        public string CCusEmail { get; set; }
        public string CCusPerson { get; set; }
        public string CCusPhone { get; set; }
        public string CCusFax { get; set; }
        public string CCusBp { get; set; }
        public string CCusHand { get; set; }
        public string CCusPperson { get; set; }
        public double? ICusDisRate { get; set; }
        public string CCusCreGrade { get; set; }
        public double? ICusCreLine { get; set; }
        public int? ICusCreDate { get; set; }
        public string CCusPayCond { get; set; }
        public string CCusOaddress { get; set; }
        public string CCusOtype { get; set; }
        public string CCusHeadCode { get; set; }
        public string CCusWhCode { get; set; }
        public string CCusDepart { get; set; }
        public double? IArmoney { get; set; }
        public DateTime? DLastDate { get; set; }
        public double? ILastMoney { get; set; }
        public DateTime? DLrdate { get; set; }
        public double? ILrmoney { get; set; }
        public DateTime? DEndDate { get; set; }
        public int? IFrequency { get; set; }
        public string CCusDefine1 { get; set; }
        public string CCusDefine2 { get; set; }
        public string CCusDefine3 { get; set; }
        public short? ICostGrade { get; set; }
        public string CCreatePerson { get; set; }
        public string CModifyPerson { get; set; }
        public DateTime? DModifyDate { get; set; }
        public string CRelVendor { get; set; }
        public string IId { get; set; }
        public string CPriceGroup { get; set; }
        public string COfferGrade { get; set; }
        public double? IOfferRate { get; set; }
        public string CCusDefine4 { get; set; }
        public string CCusDefine5 { get; set; }
        public string CCusDefine6 { get; set; }
        public string CCusDefine7 { get; set; }
        public string CCusDefine8 { get; set; }
        public string CCusDefine9 { get; set; }
        public string CCusDefine10 { get; set; }
        public int? CCusDefine11 { get; set; }
        public int? CCusDefine12 { get; set; }
        public double? CCusDefine13 { get; set; }
        public double? CCusDefine14 { get; set; }
        public DateTime? CCusDefine15 { get; set; }
        public DateTime? CCusDefine16 { get; set; }
        public byte[] Pubufts { get; set; }
        public string CInvoiceCompany { get; set; }
        public bool? BCredit { get; set; }
        public bool? BCreditDate { get; set; }
        public bool? BCreditByHead { get; set; }
        public bool? BLicenceDate { get; set; }
        public DateTime? DLicenceSdate { get; set; }
        public DateTime? DLicenceEdate { get; set; }
        public int? ILicenceAdays { get; set; }
        public bool? BBusinessDate { get; set; }
        public DateTime? DBusinessSdate { get; set; }
        public DateTime? DBusinessEdate { get; set; }
        public int? IBusinessAdays { get; set; }
        public bool? BProxy { get; set; }
        public DateTime? DProxySdate { get; set; }
        public DateTime? DProxyEdate { get; set; }
        public int? IProxyAdays { get; set; }
        public string CMemo { get; set; }
        public bool? BLimitSale { get; set; }
        public Guid? CCusContactCode { get; set; }
        public string CCusCountryCode { get; set; }
        public string CCusEnName { get; set; }
        public string CCusEnAddr1 { get; set; }
        public string CCusEnAddr2 { get; set; }
        public string CCusEnAddr3 { get; set; }
        public string CCusEnAddr4 { get; set; }
        public string CCusPortCode { get; set; }
        public string CPrimaryVen { get; set; }
        public double? FCommisionRate { get; set; }
        public double? FInsueRate { get; set; }
        public bool? BHomeBranch { get; set; }
        public string CBranchAddr { get; set; }
        public string CBranchPhone { get; set; }
        public string CBranchPerson { get; set; }
        public string CCusTradeCcode { get; set; }
        public string CustomerKcode { get; set; }
        public bool? BCusState { get; set; }
        public short? BShop { get; set; }
        public string CCusBankCode { get; set; }
        public string CCusExch_Name { get; set; }
        public short ICusGsptype { get; set; }
        public short? ICusGspauth { get; set; }
        public string CCusGspauthNo { get; set; }
        public string CCusBusinessNo { get; set; }
        public string CCusLicenceNo { get; set; }
        public bool? BCusDomestic { get; set; }
        public bool? BCusOverseas { get; set; }
        public string CCusCreditCompany { get; set; }
        public string CCusSaprotocol { get; set; }
        public string CCusExProtocol { get; set; }
        public string CCusOtherProtocol { get; set; }
        public double? FCusDiscountRate { get; set; }
        public string CCusSscode { get; set; }
        public string CCusCmprotocol { get; set; }
        public DateTime DCusCreateDatetime { get; set; }
        public string CCusAppDocNo { get; set; }
        public string CCusMnemCode { get; set; }
        public double? FAdvancePaymentRatio { get; set; }
        public bool? BServiceAttribute { get; set; }
        public bool? BRequestSign { get; set; }
        public bool? BOnGpinStore { get; set; }
        public string CCusMngTypeCode { get; set; }
        public decimal? Account_Type { get; set; }
        public string CCusImAgentProtocol { get; set; }
        public short? ISourceType { get; set; }
        public string ISourceId { get; set; }
        public double? FExpense { get; set; }
        public double? FApprovedExpense { get; set; }
        public DateTime? DTouchedTime { get; set; }
        public DateTime? DRecentlyInvoiceTime { get; set; }
        public DateTime? DRecentlyQuoteTime { get; set; }
        public DateTime? DRecentlyActivityTime { get; set; }
        public DateTime? DRecentlyChanceTime { get; set; }
        public DateTime? DRecentlyContractTime { get; set; }
        public string CLtcCustomerCode { get; set; }
        public bool? BTransFlag { get; set; }
        public string CLtcPerson { get; set; }
        public DateTime? DLtcDate { get; set; }
        public string CLocationSite { get; set; }
        public double? ICusTaxRate { get; set; }
        public DateTime? Alloct_Dept_Time { get; set; }
        public DateTime? Allot_User_Time { get; set; }
        public DateTime? Recyle_Dept_Time { get; set; }
        public DateTime? Recyle_Pub_Time { get; set; }
        public string CLicenceNo { get; set; }
        public string CLicenceRange { get; set; }
        public string CCusBusinessRange { get; set; }
        public string CCusGspauthRange { get; set; }
        public DateTime? DCusGspedate { get; set; }
        public DateTime? DCusGspsdate { get; set; }
        public int? ICusGspadays { get; set; }
        public bool? BIsCusAttachFile { get; set; }
        public DateTime? DRecentContractDate { get; set; }
        public DateTime? DRecentDeliveryDate { get; set; }
        public DateTime? DRecentOutboundDate { get; set; }
        public string CProvince { get; set; }
        public string CCity { get; set; }
        public string CCounty { get; set; }
        public Guid? CCusAddressGuid { get; set; }
        public string CAddCode { get; set; }
        public string CCreditAddCode { get; set; }
        public string CRegCash { get; set; }
        public DateTime? DDepBeginDate { get; set; }
        public int? IEmployeeNum { get; set; }
        public string CUrl { get; set; }
        public Guid? PictureGuid { get; set; }
    }
}
