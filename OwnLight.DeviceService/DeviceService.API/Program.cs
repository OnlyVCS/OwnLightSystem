<<<<<<< HEAD
using DeviceService.API;
using DeviceService.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAPIServices(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("CorsPolicy");
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Device Service API v1"));

app.MapControllers();

app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
=======
using DeviceService.API;
using DeviceService.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAPIServices(builder.Configuration);

var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

app.UseCors("CorsPolicy");
app.UseDeveloperExceptionPage();
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Device Service API v1"));

app.MapControllers();

app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
>>>>>>> c959a4bbde49f13b819f89154bbd886c71195396
