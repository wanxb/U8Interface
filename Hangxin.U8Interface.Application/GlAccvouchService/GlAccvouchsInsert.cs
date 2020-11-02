using Hangxin.U8Interface.Application.Models;
using Hangxin.U8Interface.Domain.Entitys;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Hangxin.U8Interface.Application.GlAccvouchService
{
    public class GlAccvouchsInsert : IRequest<Respone>
    {
        public List<GLAccvouchDto> GLAccvouchs { get; set; }
    }
}