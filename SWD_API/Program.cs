using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SWD_API.Services;
using Microsoft.AspNetCore.Cors.Infrastructure;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddSingleton<IAccountServices, AccountServices>();
            builder.Services.AddSingleton<IUniversityServices, UniversityServices>();
            builder.Services.AddScoped<IAccountServices, AccountServices>();
            builder.Services.AddScoped<IUniversityServices, UniversityServices>();
            builder.Services.AddScoped<IProjectRepo, ProjectRepo>();
            builder.Services.AddScoped<IAttendanceRepo, AttendanceRepo>();
            builder.Services.AddScoped<IWorkShiftRepo, WorkShiftRepo>();
            builder.Services.AddScoped<IInternRepo, InternRepo>();
            builder.Services.AddScoped<IMajorRepo, MajorRepo>();
            builder.Services.AddScoped<ISemesterRepo, SemesterRepo>();
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo() { Title = "SWDProject", Version = "v1" });

                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,

                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
              new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                },
                new string[] {}
        }
    });
            });
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });
            builder.Services.AddCors(options

                     => options.AddDefaultPolicy(policy

                     => policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            /*    if (app.Environment.IsDevelopment())
                {  */
            app.UseSwagger();
            app.UseSwaggerUI();
            //   }

           
            
            app.UseCors();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}