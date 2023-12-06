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
#endregion

#region BuilderSetup
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region Configuration
var Conf = builder.Configuration;
var DataBase = Conf.GetSection("Database");

string ConnectionString = DataBase.GetValue<string>("ConnectionString");
string DataBaseName = DataBase.GetValue<string>("DatabaseName");

var DataBaseConf = new DataBaseCo(ConnectionString, DataBaseName);
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

#region Repositories
builder.Services.AddScoped<IContentReadRepository, ContentRepository>();
builder.Services.AddScoped<IContentWriteRepository, ContentRepository>();
#endregion

#region Mediator
builder.Services.AddMediatR((c) =>
{
    c.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
#endregion