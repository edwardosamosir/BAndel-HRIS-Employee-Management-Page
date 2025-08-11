var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var app = builder.Build();

app.UseStatusCodePages();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Optional, but removes the static files warning
app.UseStaticFiles();

app.UseRouting();

// ✅ This activates attribute-routed controllers like [HttpPut("{id}")]
app.MapControllers();

// For your MVC page navigation (Views)
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Employees}/{action=Index}/{id?}"
);

// Optional redirect root -> /Employees
app.MapGet("/", () => Results.Redirect("/Employees"));

app.Run();