using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using ToDoListCodeFirst.Auth;
using ToDoListCodeFirst.Auth.Helpers;
using ToDoListCodeFirst.CQRS.To_Do.Commands;
using ToDoListCodeFirst.CQRS.To_Do.Handlers;
using ToDoListCodeFirst.CQRS.To_Do.Queries;
using ToDoListCodeFirst.CQRS.To_DoList.Commands;
using ToDoListCodeFirst.CQRS.To_DoList.Handlers;
using ToDoListCodeFirst.CQRS.To_DoList.Queries;
using ToDoListCodeFirst.CQRS;
using ToDoListCodeFirst.Data;
using ToDoListCodeFirst.Model;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>(options => 
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection")));

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddScheme<JwtBearerOptions, KeycloakJwtBearerHandler>(JwtBearerDefaults.AuthenticationScheme, null);

builder.Services.AddHttpClient();
builder.Services.AddSingleton<ICacheTokenHelper, CacheTokenHelper>();
builder.Services.AddTransient<KeycloakJwtBearerHandler>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Лабораторная работа 3 - keycloak", Version = "v2" });

    // Добавляем возможность передавать JWT токен в Swagger
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Введите JWT токен в формате: Bearer {your_token}"
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
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
            new List<string>()
        }
    });
});
builder.Services.AddMemoryCache();

builder.Services.AddScoped<ICommandHandler<CreateToDoCommand, ToDo>, CreateToDoHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateToDoCommand, ToDo>, UpdateToDoHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteToDoCommand, bool>, DeleteToDoHandler>();
builder.Services.AddScoped<IQueryHandler<GetToDoQuery, ToDo>, GetToDoHandler>();
builder.Services.AddScoped<IQueryHandler<GetAllToDosQuery, IEnumerable<ToDo>>, GetAllToDosHandler>();

builder.Services.AddScoped<ICommandHandler<CreateToDoListCommand, ToDoList>, CreateToDoListHandler>();
builder.Services.AddScoped<ICommandHandler<UpdateToDoListCommand, ToDoList>, UpdateToDoListHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteToDoListCommand, bool>, DeleteToDoListHandler>();
builder.Services.AddScoped<IQueryHandler<GetToDoListQuery, ToDoList>, GetToDoListHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ToDo API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
