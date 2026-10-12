using Tokyo_Yumi.Components;
using Tokyo_Yumi.Data;
using Tokyo_Yumi.Services;

var builder = WebApplication.CreateBuilder(args);

// רישום שירותים
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();


// מחק כל התייחסות אחרת לשירותים האלו ושים רק את אלו
builder.Services.AddScoped<DatabaseService>();
builder.Services.AddScoped<AttractionBase>();
builder.Services.AddScoped<UserService>();


var app = builder.Build();


// אתחול נתונים בבסיס הנתונים
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DatabaseService>();
    var baseData = scope.ServiceProvider.GetRequiredService<AttractionBase>();

    var initialAttractions = baseData.GetAttractions();
    if (initialAttractions != null)
    {
        db.InitializeAttractions(initialAttractions);
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
}

app.UseStaticFiles();
app.UseAntiforgery();


app.MapRazorComponents<App>()
.AddInteractiveServerRenderMode();


app.Run();