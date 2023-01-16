using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using productmanage.Models;
using BOL;
using DAL;
namespace productmanage.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
         List<Product1> prodlist=Dbmanager.getallproducts();
        return View(prodlist);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult AddProduct(){
        return View();
    }

     public IActionResult InsertProduct(Product1 p){

        Dbmanager.insertproduct(p);

        
         return Redirect("/Home/Index");
    }


    public IActionResult Delete(int id){
        Dbmanager.deleteproduct(id);

         return Redirect("/Home/Index");
    }

    public IActionResult Edit(int id){
       Product1 pr= Dbmanager.getproductbyid(id);
       
       return View(pr);
    }

    public IActionResult EditAfter(Product1 p){
        Dbmanager.updateproduct(p);
         return Redirect("/Home/Index");
    }
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
