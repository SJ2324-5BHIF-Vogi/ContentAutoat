#region usings
using FluentValidation;
using Vogi.ContentAutoat.DbExtension;
using Vogi.ContentAutoat.Application.Validators;
using Vogi.ContentAutoat.Domain.Configuration;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;
using Vogi.ContentAutoat.Domain.Dtos.Mediator.Base;
using Vogi.ContentAutoat.Domain.Interfaces.Repository;
using Vogi.ContentAutoat.Repository;
using Vogi.ContentAutoat.Domain.Interfaces.ExtensionMethodeWrapper;
using Vogi.ContentAutoat.Domain.ExtensionMethodeWrapper;
using Vogi.ContentAutoat.Application.ContentHandler;
using MassTransit;
using Vogi.ContentAutoat.Api.Consumer;
#endregion

#region BuilderSetup
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Configuration
var Conf = builder.Configuration;
var DataBase = Conf.GetSection("Database");

string ConnectionString = Environment.GetEnvironmentVariable("ConnectionString") ?? DataBase.GetValue<string>("ConnectionString");
string DataBaseName = Environment.GetEnvironmentVariable("DatabaseName") ?? DataBase.GetValue<string>("DatabaseName");

var DataBaseConf = new DataBaseCo(ConnectionString, DataBaseName);

var urlsi = Environment.GetEnvironmentVariable("Urls")?.Split(";");
builder.WebHost.UseUrls(urlsi ?? new string[] { "http://localhost:5141", "https://localhost:7141" });


var rabbitMQ = Conf.GetSection("RabbitMq");
var rabbitUrl = rabbitMQ.GetValue<string>("Url");
var rabbitUsername = rabbitMQ.GetValue<string>("Username");
var rabbitPassword = rabbitMQ.GetValue<string>("Password");

#endregion

#region Database
builder.Services.ConfigureMongo(DataBaseConf);
#endregion

#region Validators
builder.Services.AddScoped<IValidator<ContentAddDto>, ContentDtoValidator>();
builder.Services.AddScoped<IValidator<ContentUpdateDto>, ContentDtoValidator>();

builder.Services.AddScoped<IValidator<ContentGetAllDto>, ContentGetAllDtoValidator>();

builder.Services.AddScoped<IValidator<ContentGetDto>, GuidDtoValidator>();
builder.Services.AddScoped<IValidator<ContentDeleteDto>, GuidDtoValidator>();
#endregion

#region Wrapper
builder.Services.AddScoped<IToEnumerable, CursorExtensionWrapper>();
builder.Services.AddScoped<ISingleOrDefault, CursorExtensionWrapper>();
builder.Services.AddScoped<IFindFluentFind, FindFluentExtensionWrapper>();
#endregion

        #region rabbitMq
        builder.Services.AddMassTransit(x =>
        {
            x.AddConsumer<ContentAddConsumer>();
            x.AddConsumer<ContentUpdateConsumer>();
            x.AddConsumer<ContentDeleteConsumer>();
            x.AddConsumer<ContentGetAllConsumer>();
            x.AddConsumer<ContentDetailedConsumer>();

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(Environment.GetEnvironmentVariable("RabbitMqUrl") ??rabbitUrl, "/", h =>
                {
                    h.Username(Environment.GetEnvironmentVariable("RabbitMqUsername") ??rabbitUsername);
                    h.Password(Environment.GetEnvironmentVariable("RabbitMqPassword") ??rabbitPassword);
                });

                cfg.ConfigureEndpoints(context);
            });
        });
#endregion

#region Repositories
builder.Services.AddScoped<IContentReadRepository, ContentRepository>();
builder.Services.AddScoped<IContentWriteRepository, ContentRepository>();
#endregion

#region Mediator
builder.Services.AddMediatR((c) =>
{
    c.RegisterServicesFromAssemblies(typeof(AddContentHandler).Assembly);
});
#endregion

#region App
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion