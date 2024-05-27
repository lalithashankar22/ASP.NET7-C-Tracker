using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Text;
using tracker.api.data;
using tracker.api.Mapper;
using tracker.api.Middleware;
using tracker.api.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


//log errors , info etc
var logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("Logs/TrackerLog.txt",rollingInterval:RollingInterval.Minute)
    .MinimumLevel.Information()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddControllers();
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var securityScheme = new OpenApiSecurityScheme
    {
        Name = "JWT Authentication",
        Description = "Enter a valid JWT bearer token",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    options.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {securityScheme, new string[] {} }
    });
});
//dependency Injection
//dbcontext injection
builder.Services.AddDbContext<trackerDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("trackerCS")));
builder.Services.AddDbContext<AuthDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AuthCS")));
//repository injection
//addscoper - life time of the injection 

//builder.Services.AddScoped<IEmployeeRepository, InmemoryEmployeeRepository>(); 
builder.Services.AddScoped<IEmployeeRepository, SQLEmployeeRepository>(); //if two implementations where declared for the same iterface recent will be taken into account .
//singleton ,scopped ,  transient
builder.Services.AddScoped<WorkRepository, SQLWorkRepository>();
builder.Services.AddScoped<InterfaceTokenRepository, ImplimentationTokenrepository>();
builder.Services.AddScoped<ImageInterface, LocalImageImplementation>();
//automapping 
builder.Services.AddAutoMapper(typeof(EmployeeAutoMapper));
builder.Services.AddAutoMapper(typeof(DepartmentAutoMap));
builder.Services.AddAutoMapper(typeof(WorkAutoMap));

builder.Services.AddIdentityCore<IdentityUser>()
    .AddRoles<IdentityRole>()
    .AddTokenProvider<DataProtectorTokenProvider<IdentityUser>>("lali_Tracker")
    .AddEntityFrameworkStores<AuthDBContext>()
    .AddDefaultTokenProviders();

builder.Services.Configure<IdentityOptions>(options =>
    {//configure pasword structure
        options.Password.RequireDigit = false;
        options.Password.RequiredLength = 6;
       options.Password.RequireNonAlphanumeric = false;
       options.Password.RequiredUniqueChars = 1;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
}) ;
    

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters {
        //set true for the things which needs to be validated
   ValidateIssuer = true,
   ValidateAudience = true,
   ValidateLifetime = true,
   ValidateIssuerSigningKey = true,
        //jwt:issuer - obj from appsettings.json file
        ValidIssuer = builder.Configuration["jwt:issuer"],
   ValidAudience = builder.Configuration["jwt:audience"],
   IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["jwt:key"]))
    });
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(),"Images")),
    RequestPath ="/Images"
});
app.MapControllers();

app.Run();
