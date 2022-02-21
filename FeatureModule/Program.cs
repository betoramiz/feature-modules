using FeatureModule.Extensions;
using FeatureModule.Features.Employee;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// add swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidatorsFromAssemblyContaining(typeof(Program));

var app = builder.Build();

// use swagger UI
app.UseSwaggerUI();
app.UseSwagger(x => x.SerializeAsV2 = true);

// register features and endpoints
app.RegisterFeatureModules();
app.Run();
