using Hangxin.U8Interface.Domain.Models;
using Hangxin.U8Interface.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using StackExchange.Profiling;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Hangxin.U8Interface.Infrastructure.AspectCore;

namespace Hangxin.U8Interface.Application.ItemService
{
    public class ItemsQueryHandler : IRequestHandler<ItemsQuery, IEnumerable<ItemDto>>
    {
        IItemDomain _itemDomain { get; set; }
        IFitemDomain _fitemDomain { get; set; }
        public ItemsQueryHandler(IFitemDomain fitemDomain, IItemDomain itemDomain)
        {
            this._itemDomain = itemDomain;
            this._fitemDomain = fitemDomain;
        }

        [SystemLogs]
        public Task<IEnumerable<ItemDto>> Handle(ItemsQuery request, CancellationToken cancellationToken)
        {
            var fitem = _fitemDomain.Get(request.cItemClass);
            var itemTable = fitem.Ctable;
            var itemClassTable = fitem.CClasstable;
            StringBuilder strSql = new StringBuilder();
            strSql.Append(@$"select Row_Number()Over(order by cityemcode)rows,item.citemcode Citemcode,citemname Citemname,class.Citemccode,citemcname
                            from {itemTable} item, {itemClassTable} class
                            where item.citemccode = class.citemccode");
            string sql = strSql.ToString();
            return Task.FromResult(_itemDomain.Query(sql));
        }
    }
}
