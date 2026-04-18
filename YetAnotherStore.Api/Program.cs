using YetAnotherStore.Api.Middlewares;
using YetAnotherStore.Core;
using YetAnotherStore.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCoreServices();
builder.Services.AddInfrastructureServices();

builder.Services.AddControllers();
var app = builder.Build();

app.UseExceptionHandlingMiddleware();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
