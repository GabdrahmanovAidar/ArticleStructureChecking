using ArticlesStructureChecking;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
builder.Services.AddServices(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureOidc(builder.Configuration);
builder.Services.ConfigureInitializers(builder.Configuration);
builder.Services.ConfigureAuthentication();
builder.Services.AddMediatR();

builder.Services.AddControllers(options => options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true)
	  .AddNewtonsoftJson();

builder.Services.AddCors();

var app = builder.Build();

app.InitAsync();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSerilogRequestLogging();
app.UseSwagger();
app.UseSwaggerUI();

app.UseCors(corsPolicyBuilder =>
{
	corsPolicyBuilder.WithOrigins(app.Configuration.GetSection("AllowedOrigins").Get<string[]>())
		.AllowAnyMethod()
		.AllowAnyHeader()
		.AllowCredentials();
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
