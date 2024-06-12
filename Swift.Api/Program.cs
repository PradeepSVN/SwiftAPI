using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Swift.Data.Interfaces;
using Swift.Data.Services;
using System.Text;

var MyAllowSpecificOrigins = "AllowSpecificOrigin";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
	options.AddPolicy("CorsPolicy",
		builder => builder			
			.AllowAnyMethod()
			.AllowAnyHeader()
			.SetIsOriginAllowed(origin=>true)
			.AllowCredentials());
});
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
//builder.Services.AddCors(options =>
//{
//	options.AddPolicy("AllowReact",
//		builder =>
//		{

//			builder.WithOrigins("http://localhost:3001")
//				//builder.WithOrigins("http://vmswifthcdev1.eastus2.cloudapp.azure.com:81")
//				//builder.WithOrigins("http://172.203.66.19:81/")
//				.AllowAnyHeader()
//				.AllowAnyMethod();
//		});
//});

//builder.Services.AddCors(options =>
//{
//	options.AddPolicy(name: MyAllowSpecificOrigins,
//					  policy =>
//					  {
//						  //policy.WithOrigins("http://172.203.66.19:81/");
//						  policy.WithOrigins("http://172.203.66.19:81/");
//					  });
//});


builder.Services.AddScoped<ILoginService, LoginService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IMasterService, MasterService>();
builder.Services.AddScoped<IMemberService, MemberService>();
builder.Services.AddScoped<IProviderService, ProviderService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//	app.UseSwagger();
//	app.UseSwaggerUI();
//}

app.UseSwagger();
app.UseSwaggerUI();

//app.UseHttpsRedirection();
//app.UseCors(MyAllowSpecificOrigins);
app.UseCors("CorsPolicy");
//app.UseCors("AllowReact");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//app.UseCors();
app.Run();
