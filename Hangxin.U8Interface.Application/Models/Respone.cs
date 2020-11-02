using System;
using System.Collections.Generic;
using System.Text;

namespace Hangxin.U8Interface.Application.Models
{
    public class Respone
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public dynamic Data { get; set; }
    }
}
