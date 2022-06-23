using System.Diagnostics;
using AzureDay2022.WebAppMvc.Models;

namespace AzureDay2022.WebAppMvc.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> logger;
    private readonly IFeatureManager featureManager;

    public HomeController(ILogger<HomeController> logger, IFeatureManager featureManager)
    {
        this.featureManager = featureManager;
        this.logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["Welcome"] = await featureManager.IsEnabledAsync(nameof(FeatureFlags.NewWelcome))
            ? "Super Welcome!!!!"
            : "Welcome";
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [FeatureGate(FeatureFlags.AboutPage)]
    // [FeatureGate(RequirementType.All, FeatureFlags.AboutPage, FeatureFlags.AboutPage_Details)]
    public IActionResult About()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
