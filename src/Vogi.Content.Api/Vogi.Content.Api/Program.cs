using FluentValidation;
using Vogi.ContentAutoat.Application.Validators;
using Vogi.ContentAutoat.Domain.Dtos.Mediator;
using Vogi.ContentAutoat.Domain.Dtos.Mediator.Base;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


#region Validators
builder.Services.AddScoped<IValidator<ContentAddDto>, ContentDtoValidator>();
builder.Services.AddScoped<IValidator<ContentUpdateDto>, ContentDtoValidator>();

builder.Services.AddScoped<IValidator<ContentGetAllDto>, ContentGetAllDtoValidator>();

builder.Services.AddScoped<IValidator<ContentGetDto>, GuidDtoValidator>();
builder.Services.AddScoped<IValidator<ContentDeleteDto>, GuidDtoValidator>();
#endregion

#region Mediator
builder.Services.AddMediatR((c) =>
{
    c.RegisterServicesFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
});
#endregion





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
