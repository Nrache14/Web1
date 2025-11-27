using JobPositionsApi.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(c =>
{
    c.DocInclusionPredicate((docName, apiDesc) =>
        apiDesc.ActionDescriptor.RouteValues.ContainsKey("controller"));
});

builder.Services.AddScoped<IJobPositionRepository, JobPositionRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment() || true)
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseAuthorization();
app.MapControllers();

app.Run();
