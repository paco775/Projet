using Gestions_Client_Commande.Data;

var builder = WebApplication.CreateBuilder(args);

// R�cup�ration de la cha�ne de connexion dans appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Enregistrement des d�p�ts dans le conteneur d'injection de d�pendances
builder.Services.AddSingleton<DepotClients>(provider => new DepotClients(connectionString));
builder.Services.AddSingleton<DepotCommandes>(provider => new DepotCommandes(connectionString));

// Ajout des services MVC
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configuration du pipeline HTTP
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// Configuration du routage par d�faut
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Client}/{action=Index}/{id?}");

app.Run();

