using Hangxin.U8Interface.Application.Models;
using MediatR; 
using System.Collections.Generic; 

namespace Hangxin.U8Interface.Application.DepartmentService
{
    public class DepartmentsQuery : IRequest<IEnumerable<DepartmentDto>>
    {
        //public string UserName { get; private set; }

    }
}
