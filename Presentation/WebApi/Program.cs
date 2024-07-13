using Application.Features.CQRS.Handlers.AboutHandlers;
using Application.Features.CQRS.Handlers.BannerHandlers;
using Application.Features.CQRS.Handlers.BrandHandlers;
using Application.Features.CQRS.Handlers.CarHandlers;
using Application.Features.CQRS.Handlers.CategoryHandlers;
using Application.Features.CQRS.Handlers.ContactHandlers;
using Application.Interfaces;
using Application.Interfaces.CarRepositories;
using Persistance.Context;
using Persistance.Repositories;
using Persistance.Repositories.CarRepositories;

var builder = WebApplication.CreateBuilder(args);

    // DBCONTEXT CONFIGURATION ----- START -----------------------------------------------------------------------------
    builder.Services.AddScoped<CarBookContext>();
    // DBCONTEXT CONFIGURATION ----- FINISH -----------------------------------------------------------------------------

    // REPOSITORY CONFIGURATION ----- START -----------------------------------------------------------------------------
    builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    builder.Services.AddScoped(typeof(ICarRepository), typeof(CarRepository));
    // REPOSITORY CONFIGURATION ----- FINISH -----------------------------------------------------------------------------

    // CQRS CONFIGURATION ----- START ------------------------------------------------------------------------------------
    builder.Services.AddScoped<CreateAboutCommandHandler>();
    builder.Services.AddScoped<UpdateAboutCommandHandler>();
    builder.Services.AddScoped<RemoveAboutCommandHandler>();
    builder.Services.AddScoped<GetAboutByIdQueryHandler>();
    builder.Services.AddScoped<GetAboutQueryHandler>();

    builder.Services.AddScoped<CreateBannerCommandHandler>();
    builder.Services.AddScoped<UpdateBannerCommandHandler>();
    builder.Services.AddScoped<RemoveBannerCommandHandler>();
    builder.Services.AddScoped<GetBannerByIdQueryHandler>();
    builder.Services.AddScoped<GetBannerQueryHandler>();

    builder.Services.AddScoped<CreateBrandCommandHandler>();
    builder.Services.AddScoped<UpdateBrandCommandHandler>();
    builder.Services.AddScoped<RemoveBrandCommandHandler>();
    builder.Services.AddScoped<GetBrandByIdQueryHandler>();
    builder.Services.AddScoped<GetBrandQueryHandler>();

    builder.Services.AddScoped<CreateCarCommandHandler>();
    builder.Services.AddScoped<UpdateCarCommandHandler>();
    builder.Services.AddScoped<RemoveCarCommandHandler>();
    builder.Services.AddScoped<GetCarByIdQueryHandler>();
    builder.Services.AddScoped<GetCarQueryHandler>();
    builder.Services.AddScoped<GetCarWithBrandQueryHandler>();

    builder.Services.AddScoped<CreateCategoryCommandHandler>();
    builder.Services.AddScoped<UpdateCategoryCommandHandler>();
    builder.Services.AddScoped<RemoveCategoryCommandHandler>();
    builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
    builder.Services.AddScoped<GetCategoryQueryHandler>();

    builder.Services.AddScoped<CreateContactCommandHandler>();
    builder.Services.AddScoped<UpdateContactCommandHandler>();
    builder.Services.AddScoped<RemoveContactCommandHandler>();
    builder.Services.AddScoped<GetContactByIdQueryHandler>();
    builder.Services.AddScoped<GetContactQueryHandler>();
    // CQRS CONFIGURATION ----- FINISH -----------------------------------------------------------------------------------

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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