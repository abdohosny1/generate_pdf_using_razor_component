
using generate_pdf_;
using generate_pdf_.invoices;
using generate_pdf_.invoices;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Playwright;

//Microsoft.Playwright.Program.Main(["install"]);
//return;

IServiceCollection services = new ServiceCollection();

services.AddLogging();

var serviceProcider = services.BuildServiceProvider();

var loggerFactory = serviceProcider.GetRequiredService<ILoggerFactory>();

await using var htmlRander = new HtmlRenderer(serviceProcider, loggerFactory);
var Invoice = InvoiceGenerator.Generate();

var html = await htmlRander.Dispatcher.InvokeAsync(async () =>
{
    var dictionary = new Dictionary<string, object?>
    {
        {"Invoice",Invoice }
    };

    var paramaters = ParameterView.FromDictionary(dictionary);

    var output = await htmlRander.RenderComponentAsync<InvoicView>(paramaters);
    return output.ToHtmlString();
});

    using var playwright = await Playwright.CreateAsync();
    var browers = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = true
        });

var page = await browers.NewPageAsync();
await page.SetContentAsync(html);

await page.PdfAsync(new PagePdfOptions
{
    Format = "A4",
    Path = "./invoice.pdf"
});
await page.CloseAsync();

Console.WriteLine(html);