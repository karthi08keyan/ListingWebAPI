using ListingScreenAPI.Controllers;
using ListingScreenAPI.Repository;
using ListingScreenAPI.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ListingScreenAPI.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("https://localhost:7259")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<Connection>();
builder.Services.AddTransient<IItemService, ItemService>();
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IBillService,BillSevice>();
builder.Services.AddTransient<IBillServiceRepository, BillServiceRepository>();
builder.Services.AddTransient<IItemRepository,ItemRepository>();
builder.Services.AddTransient<ICustomerRepository, CustomerRepository>();
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(); // Enable CORS
app.UseHttpsRedirection();

app.UseAuthorization();
    
app.MapControllers();

app.Run();
