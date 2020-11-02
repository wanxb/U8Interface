using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Hangxin.U8Interface.Application.Models;
using Hangxin.U8Interface.Application.PersonService;
using Hangxin.U8Interface.Infrastructure;
using Hangxin.U8Interface.Infrastructure.AutoMapper;
using Hangxin.U8Interface.Infrastructure.Repositories;
using Hangxin.U8Interface.Infrastructure.UnitOfWork;
using Hangxin.U8Interface.Web.Swagger;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace Hangxin.U8Interface.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            #region 自动创建映射
            services.AddAutoMapper();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            #endregion

            #region 自动注入
            services.AddAutoInject();
            //services.AddMiniProfiler();
            // 添加MiniProfiler服务
            services.AddMiniProfiler(options =>
            {
                // 设定访问分析结果URL的路由基地址
                options.RouteBasePath = "/profiler";
            }).AddEntityFramework();//显示SQL语句及耗时

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion

            #region Version 
            services.AddApiVersioning(options =>
            {
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.DefaultApiVersion = new ApiVersion(1, 0);
            });
            #endregion

            #region swagger
            // services.AddScoped<SwaggerGenerator>(); //注入SwaggerGenerator,后面可以直接使用这个方法
            services.AddSwaggerGen(options =>
            {
                //分别注册v1和v2
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Hangxin.U8Interface.Web API",
                    Description = "API for Hangxin.U8Interface.Web",
                    Contact = new OpenApiContact() { Name = "bing", Email = "775379909@qq.com" }
                });
                options.SwaggerDoc("v2", new OpenApiInfo
                {
                    Version = "v2",
                    Title = "Hangxin.U8Interface.Web API",
                    Description = "API for Hangxin.U8Interface.Web",
                    Contact = new OpenApiContact() { Name = "bing", Email = "775379909@qq.com" }
                });
                options.DocInclusionPredicate((docName, apiDesc) =>
                {
                    var versions = apiDesc.CustomAttributes()
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions);

                    return versions.Any(v => $"v{v.ToString()}" == docName);
                });
                options.OperationFilter<RemoveVersionParameterOperationFilter>();
                options.DocumentFilter<SetVersionInPathDocumentFilter>();
                var basePath = Path.GetDirectoryName(AppContext.BaseDirectory);//get application located directory
                var apiPath = Path.Combine(basePath, "Hangxin.U8Interface.Web.xml");
                options.IncludeXmlComments(apiPath, true);


                #region swagger加锁
                var openApiSecurity = new OpenApiSecurityScheme
                {
                    Description = "JWT认证授权，使用直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
                    Name = "Authorization",  //jwt 默认参数名称
                    In = ParameterLocation.Header,  //jwt默认存放Authorization信息的位置（请求头）
                    Type = SecuritySchemeType.ApiKey
                };
                options.AddSecurityDefinition("oauth2", openApiSecurity);
                options.OperationFilter<AddResponseHeadersFilter>();
                options.OperationFilter<AppendAuthorizeToSummaryOperationFilter>();
                options.OperationFilter<SecurityRequirementsOperationFilter>();
                #endregion 
            });
            #endregion

            #region JWT
            //验证签名密匙
            //string jwtsecret = Configuration["JWTSecret"].ToString();
            var secrityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTSecret"]));
            services.AddSingleton(secrityKey);
            //使用Jwt Bearer验证授权
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(p =>
                    {
                        p.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidIssuer = "Hangxin",
                            ValidAudience = "User",
                            IssuerSigningKey = secrityKey,
                            ValidateLifetime = true,
                            ClockSkew = TimeSpan.Zero
                        };
                    });
            #endregion

            #region others
            services.AddControllersWithViews()
               .AddNewtonsoftJson(setupAction =>
               {
                   setupAction.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
               });
            #endregion

            #region 使用代理服务器
            services.Configure<ForwardedHeadersOptions>(options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
            });
            #endregion

            #region MetiatR
            services.AddMediatR(typeof(PersonsQuery), typeof(TokenDto), typeof(Startup));
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //使用代理服务器
            app.UseForwardedHeaders();
            //设置请求基路径
            app.UsePathBase(Configuration.GetValue<string>("PathBase"));
            app.UseMiniProfiler();
          

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(option =>
                {
                    option.IndexStream = () => GetType().GetTypeInfo().Assembly.GetManifestResourceStream("Hangxin.U8Interface.Web.index.html");

                    option.SwaggerEndpoint("/swagger/v1/swagger.json", "V1 Docs");
                    option.SwaggerEndpoint("/swagger/v2/swagger.json", "V2 Docs");
                    option.RoutePrefix = string.Empty;
                    option.DocumentTitle = "Hangxin.U8Interface.Web API";

                    //访问swagger UI的路由，如http://localhost:<port>/swagger
                    //默认是swagger
                    //option.RoutePrefix = string.Empty;
                    //option.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    option.DefaultModelsExpandDepth(-1); //设置为 - 1 可不显示models
                    option.DocExpansion(DocExpansion.None); //设置为none可折叠所有方法




                    #region 自定义样式 
                    //css 注入
                    //option.InjectStylesheet("/css/swaggerdoc.css");
                    //option.InjectStylesheet("/css/app.min.css");
                    //js 注入
                    //option.InjectJavascript("/js/jquery.js");
                    //option.InjectJavascript("/js/swaggerdoc.js");
                    //option.InjectJavascript("/js/app.min.js"); 
                    #endregion
                });
            }

            app.UseStateAutoMapper();
          
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors(p => p.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseAuthentication();
            app.UseAuthorization(); 
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
