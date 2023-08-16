using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using GrabIt.Infrastructure.Database;
using GrabIt.Core.src.RepositoryInterfaces;
using GrabIt.Infrastructure.RepoImplementations;
using GrabIt.Service.ServiceInterfaces;
using GrabIt.Service.Implementations;

var builder = WebApplication.CreateBuilder(args);

// Add Automapper DI
// builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add db context
builder.Services.AddDbContext<DatabaseContext>();

// add autoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// add Repository injections
builder.Services.AddScoped<IUserRepo, UserRepository>();
builder.Services.AddScoped<IAddressRepo, AddressRepository>();
builder.Services.AddScoped<IProductRepo, ProductRepository>();
builder.Services.AddScoped<IOrderRepo, OrderRepository>();
builder.Services.AddScoped<ICategoryRepo, CategoryRepository>();
builder.Services.AddScoped<ICartRepo, CartRepository>();
builder.Services.AddScoped<ICartProductRepo, CartProductRepository>();
builder.Services.AddScoped<IOrderProductRepo, OrderProductRepository>();
builder.Services.AddScoped<IImageRepo, ImageRepository>();
builder.Services.AddScoped<IPaymentRepo, PaymentRepository>();

// add Services Injections

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<ICartProductService, CartProductService>();
builder.Services.AddScoped<IOrderProductService, OrderProductService>();
builder.Services.AddScoped<IImageService, ImageService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();



// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header using the Bearer scheme. Example: \"bearer {token}\"",
        In = ParameterLocation.Header,
        Name = "Authorization",
    });
    options.OperationFilter<SecurityRequirementsOperationFilter>();

});

// Config route
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

// JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateLifetime = true,
            ValidateAudience = false,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"] ?? "backupSecretIssuer",
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? "backupSecretKey")),
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
