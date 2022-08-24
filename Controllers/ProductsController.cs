using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace Controllers;

public class ProductsController : ODataController
{
    public ProductsController(AppDbContext db)
    {
        Db = db;
    }

    public AppDbContext Db { get; }

    [EnableQuery()]
    public IActionResult Get()
    {
        return Ok(this.Db.Products);
    }
}