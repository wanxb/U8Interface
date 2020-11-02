using Hangxin.U8Interface.Application.Models;
using Hangxin.U8Interface.Domain;
using Hangxin.U8Interface.Domain.Entitys;
using Hangxin.U8Interface.Infrastructure.AspectCore;
using Hangxin.U8Interface.Infrastructure.AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hangxin.U8Interface.Application.GlAccvouchService
{
    public class GlAccvouchsInsertHandler : IRequestHandler<GlAccvouchsInsert, Respone>
    {
        IGlAccvouchDomain _glAccvouchDomain { get; set; }
        IPersonDomain _personDomain { get; set; }
        IDepartmentDomain _departmentDomain { get; set; }
        ICustomerDomain _customerDomain { get; set; }
        IVendorDomain _vendorDomain { get; set; }
        IItemDomain _itemDomain { get; set; }
        ICodeDomain _codeDomain { get; set; }
        IFitemDomain _fitemDomain { get; set; }
        ILogger<GlAccvouchsInsertHandler> _logger { get; set; }
        public GlAccvouchsInsertHandler(IGlAccvouchDomain glAccvouchDomain, IPersonDomain personDomain, IDepartmentDomain departmentDomain, ICustomerDomain customerDomain, IVendorDomain vendorDomain, IItemDomain itemDomain, ICodeDomain codeDomain, IFitemDomain fitemDomain, ILogger<GlAccvouchsInsertHandler> logger)
        {
            this._glAccvouchDomain = glAccvouchDomain;
            this._personDomain = personDomain;
            this._departmentDomain = departmentDomain;
            this._customerDomain = customerDomain;
            this._vendorDomain = vendorDomain;
            this._itemDomain = itemDomain;
            this._codeDomain = codeDomain;
            this._fitemDomain = fitemDomain;
            this._logger = logger;
        }

        [Transactional]
        public Task<Respone> Handle(GlAccvouchsInsert request, CancellationToken cancellationToken)
        {
            var respone = ParamCheck(request.GLAccvouchs); //验证参数
            if (respone.Success == false)
                return Task.FromResult(respone);
            int accouchCode = AccvouchCode();//获取本次凭证号
            respone.Data = request.GLAccvouchs;
            try
            {
                var glAccvouchList = request.GLAccvouchs.MapTo<List<GlAccvouch>>();
                GlAccvouchs(glAccvouchList, accouchCode);
                _glAccvouchDomain.Insert(glAccvouchList);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                respone.Success = false;
                respone.Message = "生成失败";
                return Task.FromResult(respone);
            }
            respone.Message = accouchCode.ToString();
            _logger.LogInformation("成功：" + accouchCode.ToString());
            return Task.FromResult(respone);
        }

        //维护字段值
        public List<GlAccvouch> GlAccvouchs(List<GlAccvouch> glAccvouchList, int ino_id)
        {
            int count = 1;
            foreach (var item in glAccvouchList)
            {
                item.Inid = (short)count++;
                item.Ino_Id = (short)ino_id;
                item.Dt_Date = item.Dbill_Date;
                item.Iyear = short.Parse(item.Dbill_Date.ToString("yyyy"));
                item.Iperiod = byte.Parse(item.Dbill_Date.ToString("MM"));
                item.IYperiod = int.Parse(item.Dbill_Date.ToString("yyyyMM"));
            }
            return glAccvouchList;
        }
        //验证参数
        public Respone ParamCheck(List<GLAccvouchDto> list)
        {
            var respone = new Respone { Success = true };
            try
            {
                if (list.Sum(c => c.mcMoney) != list.Sum(c => c.mdMoney))
                    throw new Exception("借贷不平");
                if (list.Sum(c => c.mcMoney) == 0 && list.Sum(c => c.mdMoney) == 0)
                    throw new Exception("借贷总金额不能都为0");
                foreach (var item in list)
                {
                    if (item.mcMoney == 0 && item.mdMoney == 0)
                        throw new Exception("借贷不能都为0");
                    if (item.mcMoney != 0 && item.mdMoney != 0)
                        throw new Exception("借贷不能都有金额");
                    if (string.IsNullOrEmpty(item.cDigest))
                        throw new Exception("请传入摘要[cDigest]");
                    if (string.IsNullOrEmpty(item.cBillUser))
                        throw new Exception("请传入制单人[cBillUser]");
                    if (item.cBillDate == null)
                        throw new Exception("请传入制单日期[cBillDate]");
                    if (string.IsNullOrEmpty(item.cCode))
                        throw new Exception("请传入科目编码[cCode]");

                    var code = _codeDomain.Get(item.cCode);
                    if (code == null)
                        throw new Exception($"科目编码{item.cCode}不存在");
                    if (code.bEnd == false)
                        throw new Exception($"{item.cCode}不是末级科目");

                    if (code.Bperson == true)
                    {
                        if (string.IsNullOrEmpty(item.cPersonCode))
                            throw new Exception($"科目{item.cCode}为人员核算，请传入人员编号[cPersonCode]");
                        var pserson = _personDomain.Get(item.cPersonCode);
                        if (pserson == null)
                            throw new Exception($"人员编号{item.cPersonCode}不存在");

                        item.cDepCode = null;
                        item.cCusCode = null;
                        item.cSupCode = null;
                        item.cItemCode = null;
                        item.cItemClass = null;
                    }
                    else if (code.Bdept == true)
                    {
                        if (string.IsNullOrEmpty(item.cDepCode))
                            throw new Exception($"科目{item.cCode}为部门核算，请传入部门编号[cDepCode]");
                        var department = _departmentDomain.Get(item.cDepCode);
                        if (department == null)
                            throw new Exception($"部门编号{item.cDepCode}不存在");

                        item.cPersonCode = null;
                        item.cCusCode = null;
                        item.cSupCode = null;
                        item.cItemCode = null;
                        item.cItemClass = null;
                    }
                    else if (code.Bcus == true)
                    {
                        if (string.IsNullOrEmpty(item.cCusCode))
                            throw new Exception($"科目{item.cCode}为客户核算，请传入客户编号[cCusCode]");
                        var customer = _customerDomain.Get(item.cCusCode);
                        if (customer == null)
                            throw new Exception($"客户编号{item.cCusCode}不存在");

                        item.cPersonCode = null;
                        item.cDepCode = null;
                        item.cSupCode = null;
                        item.cItemCode = null;
                        item.cItemClass = null;
                    }
                    else if (code.Bsup == true)
                    {
                        if (string.IsNullOrEmpty(item.cSupCode))
                            throw new Exception($"科目{item.cCode}为供应商核算，请传入供应商编号[cSupCode]");
                        var vendor = _vendorDomain.Get(item.cSupCode);
                        if (vendor == null)
                            throw new Exception($"供应商编号{item.cSupCode}不存在");

                        item.cPersonCode = null;
                        item.cDepCode = null;
                        item.cCusCode = null;
                        item.cItemCode = null;
                        item.cItemClass = null;
                    }
                    else if (code.Bitem == true)
                    {
                        if (string.IsNullOrEmpty(item.cItemCode))
                            throw new Exception($"科目{item.cCode}为项目核算，请传入项目编号[cItemCode]和项目大类编号[cItemClass]");
                        if (string.IsNullOrEmpty(item.cItemClass))
                            throw new Exception($"科目{item.cCode}为项目核算，请传入项目大类编号[cItemClass]");
                        var fitem = _fitemDomain.Get(item.cItemClass);
                        if (fitem == null)
                            throw new Exception($"项目大类编号{item.cItemClass}不存在");
                        var itemTable = fitem.Ctable;
                        var itemClassTable = fitem.CClasstable;

                        StringBuilder strSql = new StringBuilder();
                        strSql.Append(@$"select Row_Number()Over(order by cityemcode)rows, item.citemcode Citemcode,citemname Citemname,class.Citemccode,citemcname
                            from {itemTable} item, {itemClassTable} class
                            where item.citemccode = class.citemccode 
                            and item.citemcode ='{item.cItemCode}'");
                        string sql = strSql.ToString();
                        var itemQuery = _itemDomain.Query(sql);
                        if (itemQuery == null || itemQuery.Count() == 0)
                            throw new Exception($"项目编号{item.cItemCode}不存在");

                        item.cPersonCode = null;
                        item.cDepCode = null;
                        item.cCusCode = null;
                        item.cSupCode = null;
                    }
                    else
                    {
                        item.cPersonCode = null;
                        item.cDepCode = null;
                        item.cCusCode = null;
                        item.cSupCode = null;
                        item.cItemCode = null;
                        item.cItemClass = null;
                    }
                }
            }
            catch (Exception ex)
            {
                respone.Success = false;
                respone.Message = ex.Message;
                respone.Data = list;
                return respone;
            }
            return respone;
        }


        //获取本次凭证号
        public int AccvouchCode()
        {
            var glAccvouch = _glAccvouchDomain.GetAll().ToList();
            if (glAccvouch.Count() == 0)
                return 1;
            return glAccvouch.First().Ino_Id + 1;
        }
    }
}

