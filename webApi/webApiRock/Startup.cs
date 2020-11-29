using AutoMapper;
using Core.DB.Context;
using Core.DB.Entity;
using Core.Model;
using Core.Rules;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using webApiRock.Domain.Commands.Queries;
using webApiRock.Domain.Commands.Request.Create;
using webApiRock.Domain.Commands.Response;

namespace webApiRock
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
            services.AddControllers();
            services.AddDbContext<PostsContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(System.Reflection.Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IUserRule), typeof(UserRule));
            services.AddTransient(typeof(IPostRule), typeof(PostRule));
            services.AddTransient(typeof(IHistoryRule), typeof(HistoryRule));
            
            var config = new AutoMapper.MapperConfiguration(cfg =>
            {
                cfg.CreateMap<UserDTO, Users>();
                cfg.CreateMap<Users, UserDTO>();
                cfg.CreateMap<UserDTO, QueryUserResponse>();
                cfg.CreateMap<UserDTO, CreateUserResponse>();
                cfg.CreateMap<CreateUserRequest, UserDTO>();
                cfg.CreateMap<Posts, PostDTO>().ForMember(dest => dest.Handle , 
                    opt => opt.MapFrom(src => src.Id));
                cfg.CreateMap<PostDTO, Posts>();
                cfg.CreateMap<PostDTO,QueryPostResponse>();
                cfg.CreateMap<CreatePostRequest, PostDTO>();
                cfg.CreateMap<History, HistoryDTO>();
                cfg.CreateMap<List<PostDTO>, List<QueryPostResponse>>();
                cfg.CreateMap<int, CreatePostResponse>();
                cfg.CreateMap<bool, CreatePostResponse>();
                cfg.CreateMap<bool, UpdatePostResponse>();
            });
            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);

            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder => builder
                 .AllowAnyOrigin()
                 .AllowAnyMethod()
                 .AllowAnyHeader());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();
            
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
