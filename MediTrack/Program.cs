using Microsoft.EntityFrameworkCore;
using MediTrack.Data;
using MediTrack.Configurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using MediTrack.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
//non-genaric
builder.Services.AddScoped<IJwtTokenService, JwtTokenService>();
builder.Services.AddScoped<IUserAuthRepository, UserAuthRepository>();
builder.Services.AddScoped(typeof(IDataRepository<>) , typeof(DataRepository<>));
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("MyData")));
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection(nameof(JwtSettings)));

var Jwtsettings = builder.Configuration.GetSection(nameof(JwtSettings));
var secretkey = Jwtsettings["SecretKey"];
//Add JWT Bearer Authentication
builder.Services.AddAuthentication(option =>
{
   option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
   option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("AllowAll");
app.UseHttpsRedirection();
app.MapControllers();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();



app.Run();


