using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Hangxin.U8Interface.Domain.Models;
using MediatR;

namespace Hangxin.U8Interface.Application.ItemService
{
    public class ItemsQuery : IRequest<IEnumerable<ItemDto>>
    { 
        [Required]
        public string cItemClass { get; set; }

    }
}
