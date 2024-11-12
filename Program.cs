var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços de controle MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configura o middleware do MVC
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Collaborator}/{action=Index}/{id?}");

app.Run();
