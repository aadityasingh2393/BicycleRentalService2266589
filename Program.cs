using Microsoft.EntityFrameworkCore.SqlServer;
using BicycleRentalSystem.BicycleService.DataAccessLayer.Data;
using Microsoft.EntityFrameworkCore;
using DataAccessLayer.Data;
using BicycleRentalSystem.RentService.DataAccessLayer.Data;
using BicycleRentalSystem.BicycleService.BusinessLayer.Services;
using BicycleRentalSystem.BicycleService.DataAccessLayer.Repositories;
using BusinessLayer.Services;
using BicycleRentalSystem.RentService.BusinessLayer.Services;
using DataAccessLayer.Repositories;
using BicycleRentalSystem.RentService.DataAccessLayer.Repositories;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using MobileOnlineShopSystem.UserMicroservice.Data_Access_Layer.Data;
using BicycleRentalService.AthUser.BusinessLayer.Services;
using BicycleRentalService.AthUser.DataAccessLayer.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<BicycleDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Bicycle")));
builder.Services.AddDbContext<RentalDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Rent")));
builder.Services.AddDbContext<PaymentDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Payment")));
builder.Services.AddDbContext<UserData>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("User")));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IBicycleService, BicycleService>();
builder.Services.AddScoped<IBicycleRepository, BicycleRepository>();
builder.Services.AddScoped<IRentalService, RentalService>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();
builder.Services.AddScoped<IRentalItemService, RentalItemService>();
builder.Services.AddScoped<IRentalItemRepository, RentalItemRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IAuthUserService, AuthUserService>();
builder.Services.AddScoped<IAuthUserRepository, AuthUserRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Human Resources API", Version = "v1" });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = @"JWT <strong>Authorization</strong> header using the Bearer scheme. <br/> 
                      Enter your token in the text input below.
<br/>Example: <i>'12345abcdef'</i>",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer"
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
 Array.Empty<string>()
 }
 });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
 .AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = false,
         ValidateAudience = false,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
     };
 });

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
