using Hangxin.U8Interface.Domain.Models;
using Hangxin.U8Interface.Infrastructure;
using Hangxin.U8Interface.Infrastructure.Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangxin.U8Interface.Domain
{
    public interface IItemDomain : IBaseDomain
    {
        IEnumerable<ItemDto> Query(string sql);

        PagedResult<ItemDto> GetPageList(string sql, int pageIndex, int pageSize);
    }
}
