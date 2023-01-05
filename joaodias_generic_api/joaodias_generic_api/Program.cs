using joaodias_generic.Infra.Data.Context;
using joaodias_generic.Infra.IoC;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddInfrastructureAPI(builder.Configuration);
builder.Services.AddInfrastructureJWT(builder.Configuration);
builder.Services.AddInfrastructureSwagger();
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//builder.Services.AddCors(builder =>
//{
//    builder.AddPolicy("Policy", policy =>
//    {
//        policy.WithOrigins("http://localhost:61960",
//            "https://localhost:61960",
//            "https://joaodiasdev.github.io",
//            "https://joaodiasdev.github.io",
//            "http://localhost",
//            "https://localhost",
//            "https://localhost:5556",
//            "http://localhost:5555",
//            "http://localhost:7251",
//            "https://localhost:7251")
//            .SetIsOriginAllowedToAllowWildcardSubdomains()
//            .AllowAnyHeader()
//            .AllowCredentials()
//            .WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS")
//            .SetPreflightMaxAge(TimeSpan.FromSeconds(3600));
//    });
//});

builder.WebHost.UseUrls("http://localhost:5555", "https://localhost:5556");

var connectionString = builder.Configuration.GetConnectionString("GenericApiDbConnection");

builder.Services.AddDbContext<GenericApiDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Generic API JoaoDias");
    });
}

//app.UseHttpsRedirection(); // Never Uses that line when using proxy redirect webservers!!!!

app.UseStaticFiles();

//app.UseCors(builder =>
//{
//    builder.WithOrigins("http://localhost:61960",
//       "https://localhost:61960",
//       "https://joaodiasdev.github.io",
//       "https://joaodiasdev.github.io",
//       "https://localhost:5556",
//       "http://localhost:5555",
//       "http://localhost:7251",
//       "https://localhost:7251")
//       .SetIsOriginAllowedToAllowWildcardSubdomains()
//       .AllowAnyHeader()
//       .AllowCredentials()
//       .WithMethods("GET", "PUT", "POST", "DELETE", "OPTIONS")
//       .SetPreflightMaxAge(TimeSpan.FromSeconds(3600));
//}
//);

//app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<GenericApiDbContext>();
    db.Database.Migrate();
}


app.Run();
