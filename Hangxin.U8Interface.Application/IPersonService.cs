using Hangxin.U8Interface.Application.Models;
using Hangxin.U8Interface.Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hangxin.U8Interface.Application
{
    public interface IPersonService: IBaseApplication
    {
        IEnumerable<PersonDto> GetAll(); 
    }
}
