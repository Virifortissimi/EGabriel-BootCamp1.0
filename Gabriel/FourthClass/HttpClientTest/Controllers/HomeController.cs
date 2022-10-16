using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HttpClientTest.Models;
using HttpClientTest.Services;
using HttpClientTest.Repository;

namespace HttpClientTest.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IDataService _service;
    private readonly IDataRepo _repo;

    public HomeController(ILogger<HomeController> logger, IDataService service, IDataRepo repo)
    {
        _logger = logger;
        _service = service;
        _repo = repo;
    }

    public async Task<IActionResult> IndexAsync()
    {
        return View(await _repo.GetDrinks());
    }

    public async Task<IActionResult> GetCockTail()
    {
        var result = await _service.GetCockTailByName();
        return View(result);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
