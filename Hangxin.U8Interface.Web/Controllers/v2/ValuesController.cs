using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Profiling;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Hangxin.U8Interface.Web.Controllers.v2
{
    [ApiVersion("2")]
    [Route("v{version:apiVersion}/[controller]/[action]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {


        private readonly IHttpContextAccessor _accessor;
        public ValuesController(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
        }
        [HttpGet]
        public IActionResult GetCounts()
        {
            var html = MiniProfiler.Current.RenderIncludes(_accessor.HttpContext);
            return Ok(html.Value);
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
