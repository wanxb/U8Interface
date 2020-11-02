using AspectCore.DynamicProxy;
using AspectCore.DynamicProxy.Parameters;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hangxin.U8Interface.Infrastructure.AspectCore
{
    public class SystemLogsAttribute : AbstractInterceptorAttribute
    {
        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            var logger = context.ServiceProvider.GetService(typeof(ILogger<SystemLogsAttribute>)) as ILogger<SystemLogsAttribute>;
            dynamic paramObj = context.Parameters.FirstOrDefault();
            string param = JsonConvert.SerializeObject(paramObj);
            string key = "Param:" + param;
            logger.LogInformation(key);
            try
            {
                await next(context); 
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message);
                throw;
            }
        }
    }
}
