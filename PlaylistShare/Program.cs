using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Bson.Serialization;
using MongoDB.Bson;
using PlaylistShare.BL.Interfaces;
using PlaylistShare.BL.Services;
using PlaylistShare.DL.Interfaces;
using PlaylistShare.DL.Repositories.MongoDb;
using PlaylistShare.Models.Configs;
using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using Microsoft.OpenApi.Models;
using PlaylistShare.Extensions;
using PlaylistShare.HealthChecks;
using FluentValidation.AspNetCore;
using FluentValidation;

namespace PlaylistShare
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var logger = new LoggerConfiguration().Enrich.FromLogContext().WriteTo.Console(theme: AnsiConsoleTheme.Code).CreateLogger();

            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.AddSerilog(logger);

            builder.Services.Configure<MongoDbConfig>(builder.Configuration.GetSection(nameof(MongoDbConfig)));

            // Add services to the container.
            builder.Services.AddSingleton<ISongService, SongService>();
            builder.Services.AddSingleton<ISongRepository, SongMongoRepository>();
            builder.Services.AddSingleton<IPlaylistService, PlaylistService>();
            builder.Services.AddSingleton<IPlaylistRepository, PlaylistMongoRepository>();
            builder.Services.AddSingleton<IUserInfoService, UserInfoService>();
            builder.Services.AddSingleton<IUserInfoRepository, UserInfoMongoRepository>();
            builder.Services.AddSingleton<IMusicLibraryService, MusicLibraryService>();

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = builder.Configuration["Jwt:Audience"],
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
            });

            builder.Services.AddAutoMapper(typeof(Program));

            BsonSerializer.RegisterSerializer(new GuidSerializer(GuidRepresentation.Standard));

            builder.Services.AddControllers();
            
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(x =>
            {
                var jwtSecurityScheme = new OpenApiSecurityScheme()
                {
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Name = "JWT Authentication",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Description = "Put **_Only_** JWT Bearer token",
                    Reference = new OpenApiReference()
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };

                x.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
                x.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {jwtSecurityScheme, Array.Empty<string>()}
                });
            });

          
            builder.Services.AddHealthChecks().AddCheck<SongCheck>("SongCheck");

            builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
            builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();

            app.RegisterHealthChecks();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}