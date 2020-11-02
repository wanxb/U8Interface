using Hangxin.U8Interface.Domain.Models;
using Hangxin.U8Interface.Infrastructure;
using Hangxin.U8Interface.Infrastructure.Dapper;
using System.Collections.Generic;

namespace Hangxin.U8Interface.Domain.Domain
{
    public class ItemDomain : IItemDomain
    {
        IRepository<ItemDto> _Repository;
        public ItemDomain(IRepository<ItemDto> Repository)
        {
            this._Repository = Repository;
        }
        public IEnumerable<ItemDto> Query(string sql)
        {
            return _Repository.Query(sql);
        }
        public PagedResult<ItemDto> GetPageList(string sql, int pageIndex, int pageSize)
        {
            return _Repository.GetPageList(sql, pageIndex, pageSize);
        }
    }
}
