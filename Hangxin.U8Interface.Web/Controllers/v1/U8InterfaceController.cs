using System.Collections.Generic;
using System.Threading.Tasks;
using Hangxin.U8Interface.Application.CodeService;
using Hangxin.U8Interface.Application.FitemService;
using Hangxin.U8Interface.Application.ItemService;
using Hangxin.U8Interface.Application.Models;
using Hangxin.U8Interface.Application.PersonService;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Hangxin.U8Interface.Application.CustomerService;
using Hangxin.U8Interface.Application.DepartmentService;
using Hangxin.U8Interface.Application.VendorService;
using Hangxin.U8Interface.Application.GlAccvouchService;
using Hangxin.U8Interface.Domain.Entitys;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hangxin.U8Interface.Web.Controllers.v1
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class U8InterfaceController : ControllerBase
    {
        private IMediator _mediator;
        public U8InterfaceController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        /// <summary>
        /// 人员档案
        /// </summary>
        /// <returns></returns>
        [HttpGet("Persons")]
        public async Task<IEnumerable<PersonDto>> Persons([FromQuery] PersonsQuery personsQuery)
        {
            return await _mediator.Send(personsQuery);
        }
        /// <summary>
        /// 部门档案
        /// </summary>  
        [HttpGet("Departments")]
        //[Authorize(Roles = "user")]
        public async Task<IEnumerable<DepartmentDto>> Departments([FromQuery] DepartmentsQuery departmentQuery)
        {
            return await _mediator.Send(departmentQuery);
        }
        /// <summary>
        /// 客户档案
        /// </summary>  
        [HttpGet("Customers")]
        //[Authorize(Roles = "user")]
        public async Task<IEnumerable<CustomerDto>> Customers([FromQuery] CustomersQuery customersQuery)
        {
            return await _mediator.Send(customersQuery);
        }
        /// <summary>
        /// 供应商档案
        /// </summary>  
        [HttpGet("Vendors")]
        //[Authorize(Roles = "user")]
        public async Task<IEnumerable<VendorDto>> Vendors([FromQuery] VendorsQuery vendorsQuery)
        {
            return await _mediator.Send(vendorsQuery);
        }
        /// <summary>
        /// 科目档案
        /// </summary>  
        [HttpGet("Codes")]
        //[Authorize(Roles = "user")]
        public async Task<IEnumerable<CodeDto>> Codes([FromQuery] CodesQuery codesQuery)
        {
            return await _mediator.Send(codesQuery);
        }
        /// <summary>
        /// 项目分类档案
        /// </summary>  
        [HttpGet("Fitems")]
        //[Authorize(Roles = "user")]
        public async Task<IEnumerable<FitemDto>> Fitems([FromQuery] FitemsQuery fitemsQuery)
        {
            return await _mediator.Send(fitemsQuery);
        }
        /// <summary>
        /// 项目档案
        /// </summary> 
        [HttpGet("Items")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> Items([FromQuery] ItemsQuery itemsQuery)
        {
            FitemQueryOne fitemQueryOne = new FitemQueryOne();
            fitemQueryOne.cItemClass = itemsQuery.cItemClass;
            var fitem = _mediator.Send(fitemQueryOne);
            if (fitem.Result == null)
                return NotFound();
            return Ok(await _mediator.Send(itemsQuery));
        }
        /// <summary>
        /// 项目档案分页
        /// </summary> 
        [HttpGet("ItemsPageList")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> ItemsPageList([FromQuery] ItemsPagedResult itemsPagedResult)
        {
            FitemQueryOne fitemQueryOne = new FitemQueryOne();
            fitemQueryOne.cItemClass = itemsPagedResult.cItemClass;
            var fitem = _mediator.Send(fitemQueryOne);
            if (fitem.Result == null)
                return NotFound();
            return Ok(await _mediator.Send(itemsPagedResult));
        }
        /// <summary>
        /// 查询凭证
        /// </summary> 
        [HttpGet("GlAccvouchs")]
        //[Authorize(Roles = "admin")]
        public async Task<IEnumerable<GlAccvouch>> GlAccvouchs([FromQuery] GlAccvouchsQuery glAccvouchsQuery)
        {
            return await _mediator.Send(glAccvouchsQuery);
        }

        /// <summary>
        /// 生成凭证
        /// </summary> 
        [HttpPost("GlAccvouch")]
        //[Authorize(Roles = "admin")]
        public async Task<IActionResult> GlAccvouch([FromBody] GlAccvouchsInsert glAccvouchsInsert)
        {
            Respone result = await _mediator.Send(glAccvouchsInsert);
            if (result.Success == false)
                return NotFound(result);
            return Ok(result);
        }
    }
}
