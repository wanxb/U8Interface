using Hangxin.U8Interface.Domain.Entitys;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangxin.U8Interface.Application.GlAccvouchService
{
    public class GlAccvouchsQuery : IRequest<IEnumerable<GlAccvouch>>
    {
        //public string UserName { get; private set; }

    }
}