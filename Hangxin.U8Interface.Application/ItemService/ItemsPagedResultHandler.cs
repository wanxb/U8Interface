using Hangxin.U8Interface.Domain;
using Hangxin.U8Interface.Domain.Models;
using Hangxin.U8Interface.Infrastructure.AspectCore;
using Hangxin.U8Interface.Infrastructure.Dapper;
using MediatR;
using Microsoft.Extensions.Logging;
using StackExchange.Profiling;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hangxin.U8Interface.Application.ItemService
{
    public class ItemsPagedResultHandler : IRequestHandler<ItemsPagedResult, PagedResult<ItemDto>>
    {
        IItemDomain _itemDomain { get; set; }
        IFitemDomain _fitemDomain { get; set; }
        public ItemsPagedResultHandler(IFitemDomain fitemDomain, IItemDomain itemDomain)
        {
            this._itemDomain = itemDomain;
            this._fitemDomain = fitemDomain;
        }
        [SystemLogs]
        public Task<PagedResult<ItemDto>> Handle(ItemsPagedResult request, CancellationToken cancellationToken)
        {
            var fitem = _fitemDomain.Get(request.cItemClass);
            var itemTable = fitem.Ctable;
            var itemClassTable = fitem.CClasstable;

            StringBuilder strSql = new StringBuilder();
            strSql.Append(@$"select row_number()over(order by citemcode)rows,item.citemcode Citemcode,citemname Citemname,class.Citemccode,citemcname
                            from {itemTable} item, {itemClassTable} class
                            where item.citemccode = class.citemccode");
            string sql = strSql.ToString();
            using (MiniProfiler.Current.Step("item"))
            {
                using (MiniProfiler.Current.CustomTiming("SQL", "SELECT * FROM item"))
                {
                    return Task.FromResult(_itemDomain.GetPageList(sql, request.pageIndex, request.pageSize));
                }
            }
        }
    }
}
