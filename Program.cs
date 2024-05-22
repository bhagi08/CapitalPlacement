using Jobs.Service;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSingleton<ApplicationService>();
builder.Services.AddSingleton<ApplicationFormService>();
builder.Services.AddSingleton<ProgramsService>();
builder.Services.AddControllers();
builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();
app.Run();


