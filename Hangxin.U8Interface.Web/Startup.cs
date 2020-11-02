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
            #region �Զ�����ӳ��
            services.AddAutoMapper();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            #endregion

            #region �Զ�ע��
            services.AddAutoInject();
            //services.AddMiniProfiler();
            // ���MiniProfiler����
            services.AddMiniProfiler(options =>
            {
                // �趨���ʷ������URL��·�ɻ���ַ
                options.RouteBasePath = "/profiler";
            }).AddEntityFramework();//��ʾSQL��估��ʱ

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
            // services.AddScoped<SwaggerGenerator>(); //ע��SwaggerGenerator,�������ֱ��ʹ���������
            services.AddSwaggerGen(options =>
            {
                //�ֱ�ע��v1��v2
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


                #region swagger����
                var openApiSecurity = new OpenApiSecurityScheme
                {
                    Description = "JWT��֤��Ȩ��ʹ��ֱ�����¿�������Bearer {token}��ע������֮����һ���ո�\"",
                    Name = "Authorization",  //jwt Ĭ�ϲ�������
                    In = ParameterLocation.Header,  //jwtĬ�ϴ��Authorization��Ϣ��λ�ã�����ͷ��
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
            //��֤ǩ���ܳ�
            //string jwtsecret = Configuration["JWTSecret"].ToString();
            var secrityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWTSecret"]));
            services.AddSingleton(secrityKey);
            //ʹ��Jwt Bearer��֤��Ȩ
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

            #region ʹ�ô��������
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
            //ʹ�ô��������
            app.UseForwardedHeaders();
            //���������·��
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

                    //����swagger UI��·�ɣ���http://localhost:<port>/swagger
                    //Ĭ����swagger
                    //option.RoutePrefix = string.Empty;
                    //option.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
                    option.DefaultModelsExpandDepth(-1); //����Ϊ - 1 �ɲ���ʾmodels
                    option.DocExpansion(DocExpansion.None); //����Ϊnone���۵����з���




                    #region �Զ�����ʽ 
                    //css ע��
                    //option.InjectStylesheet("/css/swaggerdoc.css");
                    //option.InjectStylesheet("/css/app.min.css");
                    //js ע��
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
