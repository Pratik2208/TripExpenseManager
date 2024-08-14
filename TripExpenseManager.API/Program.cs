using Microsoft.EntityFrameworkCore;
using TripExpenseManager.API.ExceptionHandling;
using TripExpenseManager.Business.Services;
using TripExpenseManager.Data.Data;
using TripExpenseManager.Data.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CosmosDbContext>(optionsBuilder =>
    optionsBuilder
        .UseCosmos(
            connectionString: builder.Configuration.GetConnectionString("DefaultConnection")!,
            databaseName: "TripEx"));

builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<TripRepository>();
builder.Services.AddScoped<ExpenseRepository>();
builder.Services.AddScoped<LocationCategoryRepository>();
builder.Services.AddScoped<ExpenseCategoryRepository>();

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<IExpenseService, ExpenseService>();
builder.Services.AddScoped<IExpenseCategoryService, ExpenseCategoryService>();
builder.Services.AddScoped<ILocationCategoryService, LocationCategoryService>();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<CosmosDbContext>();
    await context.Database.EnsureCreatedAsync();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();

app.UseRouting();

#if !DEBUG
app.UseHttpsRedirection();
#endif

app.UseCors(policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

app.MapControllers();

app.UseAuthorization();

app.Run();
