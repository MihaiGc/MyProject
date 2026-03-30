var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowNextJS",
        policy => policy
            .WithOrigins("http://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod()
    );
});

builder.Services.AddControllers();

var app = builder.Build();

// ✅ ADD THIS AFTER builder.Build()
app.UseCors("AllowNextJS");

app.UseAuthorization();
app.MapControllers();
app.Run();