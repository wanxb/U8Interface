using Hangxin.U8Interface.Application.Models;
using Hangxin.U8Interface.Domain;
using Hangxin.U8Interface.Infrastructure.AspectCore;
using Hangxin.U8Interface.Infrastructure.AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using StackExchange.Profiling;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Hangxin.U8Interface.Application.DepartmentService
{
    public class DerpartmentQueryHandler : IRequestHandler<DepartmentsQuery, IEnumerable<DepartmentDto>>
    {
        IDepartmentDomain _departmentDomain { get; set; } 
        public DerpartmentQueryHandler(IDepartmentDomain departmentDomain)
        {
            this._departmentDomain = departmentDomain; 
        }

        [SystemLogs]
        public Task<IEnumerable<DepartmentDto>> Handle(DepartmentsQuery request, CancellationToken cancellationToken)
        {
            var departments = _departmentDomain.GetAll();
            return Task.FromResult(departments.MapTo<IEnumerable<DepartmentDto>>());
        }
    }
}
