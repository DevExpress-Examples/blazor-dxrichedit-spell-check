using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DevExpress.Blazor.RichEdit.SpellCheck;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddDevExpressBlazor().AddSpellCheck(opts => {
    opts.FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Data", "Dictionaries"));
    opts.Dictionaries.Add(new Dictionary {
        DictionaryPath = "de\\de.dic",
        AlphabetPath = "de\\alphabet.txt",
        Culture = "de-DE"
    });
    opts.Dictionaries.Add(new Dictionary {
        DictionaryPath = "fr\\fr.dic",
        AlphabetPath = "fr\\alphabet.txt",
        Culture = "fr-FR"
    });
    opts.AddToDictionaryAction = (word, culture) => {
        string path;
        switch (culture.Name) {
            case "de-DE":
                path = opts.FileProvider.GetFileInfo("de//de.dic").PhysicalPath;
                File.AppendAllText(path, "\n" + word);
                break;
            case "fr-FR":
                path = opts.FileProvider.GetFileInfo("fr//fr.dic").PhysicalPath;
                File.AppendAllText(path, "\n" + word);
                break;
            default:
                break;
        };
    };
    opts.MaxSuggestionCount = 7;
});
builder.Services.Configure<DevExpress.Blazor.Configuration.GlobalOptions>(options => {
    options.BootstrapVersion = DevExpress.Blazor.BootstrapVersion.v5;
});
builder.WebHost.UseWebRoot("wwwroot");
builder.WebHost.UseStaticWebAssets();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();