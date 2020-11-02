using Hangxin.U8Interface.Domain.Models;
using Hangxin.U8Interface.Infrastructure.Dapper;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Hangxin.U8Interface.Application.ItemService
{
    public class ItemsPagedResult : IRequest<PagedResult<ItemDto>>
    {
        [Required]
        public string cItemClass { get; set; }
        [Required]
        public int pageIndex { get; set; }
        [Required]
        public int pageSize { get; set; }

    }
}
