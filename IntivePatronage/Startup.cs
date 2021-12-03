using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System.Reflection;
using FluentValidation.AspNetCore;
using API.Validators;
using Database;
using Application.Repositories;
using Application.Models;

namespace IntivePatronage
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
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddControllers()
                .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<Startup>())
                .AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
                .AddXmlDataContractSerializerFormatters()
                .ConfigureApiBehaviorOptions(setupAction => 
                {
                    setupAction.InvalidModelStateResponseFactory = context =>
                     {
                         var problemDetailsFactory = context.HttpContext.RequestServices
                             .GetRequiredService<ProblemDetailsFactory>();

                         var problemDetails = problemDetailsFactory.CreateValidationProblemDetails(context.HttpContext, context.ModelState);

                         problemDetails.Instance = context.HttpContext.Request.Path;
                         problemDetails.Detail = "See error field for details.";

                         var actionExecutingContext = context as ActionExecutingContext;

                         if (context.ModelState.ErrorCount > 0 &&
                         (actionExecutingContext?.ActionArguments.Count == context.ActionDescriptor.Parameters.Count))
                         {
                             problemDetails.Status = StatusCodes.Status400BadRequest;
                             problemDetails.Title = "One or more validation errors has occured.";
                             return new BadRequestObjectResult(problemDetails)
                             {
                                 ContentTypes = { "application/problem+json" }
                             };
                         }

                         problemDetails.Status = StatusCodes.Status400BadRequest;
                         problemDetails.Title = "One or more errors on input has occured.";

                         return new BadRequestObjectResult(problemDetails) 
                         { 
                             ContentTypes = { "application/problem+json" } 
                         };

                     };
                 });

            services.AddTransient<IValidator<BaseUserDto>, BaseUserValidator>();
            services.AddTransient<IValidator<CreateUserDto>, CreateUserValidator>();
            services.AddTransient<IValidator<AddressDto>, AddressValidator>();
            services.AddTransient<IValidator<UpdateUserDto>, UpdateUserValidator>();


            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "IntivePatronage", Version = "v1" });
            });

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(Configuration["DefaultConnection"]));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "IntivePatronage v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
