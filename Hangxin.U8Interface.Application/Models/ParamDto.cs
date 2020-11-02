using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Hangxin.U8Interface.Application.Models
{
    public class ParamDto
    {
        public string account { get; set; }
        public List<GLAccvouchDto> data { get; set; }
    }
}
