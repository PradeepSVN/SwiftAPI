using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swift.Data.Interfaces;
using Swift.Data.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
//builder.Services.AddCors(options =>
//{
//	options.AddPolicy(name: "AllowOrigin",
//		builder =>
//		{
//			builder.WithOrigins("http://vmswifthcdev1.eastus2.cloudapp.azure.com", "https://vmswifthcdev1.eastus2.cloudapp.azure.com", "http://localhost:8081")
//								.AllowAnyHeader()
//								.AllowAnyMethod();
//		});
//});
//JWT Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => {
	options.TokenValidationParameters = new TokenValidationParameters
	{
		ValidateIssuer = true,
		ValidateAudience = true,
		ValidateLifetime = true,
		ValidateIssuerSigningKey = true,
		ValidIssuer = builder.Configuration["Jwt:Issuer"],
		ValidAudience = builder.Configuration["Jwt:Audience"],
		IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
	};
});
builder.Services.AddCors(options =>
{
	options.AddPolicy("AllowReact",
		builder =>
		{

			builder.WithOrigins("http://localhost:3001")
				.AllowAnyHeader()
				.AllowAnyMethod();
		});
});


builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IMasterService, MasterService>();
builder.Services.AddScoped<IMemberService, MemberService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

//app.UseSwagger();
//app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.UseCors("AllowReact");
//app.UseCors();
app.Run();
