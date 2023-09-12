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
using GrabIt.Service.src.ServiceInterfaces;
using GrabIt.Service.src.Implementations;
using GrabIt.Infrastructure.MiddleWare;
using GrabIt.Infrastructure.src.AuthorizationRequirements;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);

// Add Automapper DI
// builder.Services.AddAutoMapper(typeof(Program).Assembly);

// Add db context
builder.Services.AddDbContext<DatabaseContext>();

// add autoMapper
builder.Services.AddAutoMapper(typeof(Program).Assembly);

// add Repository injections
builder.Services.AddScoped<IUserRepo, UserRepository>()
.AddScoped<IAddressRepo, AddressRepository>()
.AddScoped<IProductRepo, ProductRepository>()
.AddScoped<IOrderRepo, OrderRepository>()
.AddScoped<ICategoryRepo, CategoryRepository>()
.AddScoped<ICartRepo, CartRepository>()
.AddScoped<ICartProductRepo, CartProductRepository>()
.AddScoped<IOrderProductRepo, OrderProductRepository>()
.AddScoped<IImageRepo, ImageRepository>()
.AddScoped<IPaymentRepo, PaymentRepository>();

// add Services Injections

builder.Services.AddScoped<IUserService, UserService>()
.AddScoped<IAddressService, AddressService>()
.AddScoped<IProductService, ProductService>()
.AddScoped<IOrderService, OrderService>()
.AddScoped<ICategoryService, CategoryService>()
.AddScoped<ICartService, CartService>()
.AddScoped<ICartProductService, CartProductService>()
.AddScoped<IOrderProductService, OrderProductService>()
.AddScoped<IImageService, ImageService>()
.AddScoped<IPaymentService, PaymentService>()
.AddScoped<IAuthService, AuthService>();

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

builder.Services.AddSingleton<ErrorHandlerMiddleware>();

// Config route
builder.Services.Configure<RouteOptions>(options =>
{
    options.LowercaseUrls = true;
    options.LowercaseQueryStrings = true;
});

// add policy requirements handler
builder.Services.AddSingleton<IAuthorizationHandler, OrderOwnerOnlyRequirementHandler>();

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

// Authorization Policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("OrderOwnerOnly", policy => policy.Requirements.Add(new OrderOwnerRequirements()));
});


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
                          {
                              policy.WithOrigins("http://localhost:3000")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                          });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();
app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
