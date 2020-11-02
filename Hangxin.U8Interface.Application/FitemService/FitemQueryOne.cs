using Hangxin.U8Interface.Application.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangxin.U8Interface.Application.FitemService
{
    public class FitemQueryOne : IRequest<FitemDto>
    {
        public string cItemClass { get; set; }

    }
}
