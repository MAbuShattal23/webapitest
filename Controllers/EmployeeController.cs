using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace webapicontrollers.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    public int idcounter = 0;

    private readonly AppDbContext _db;

    public EmployeeController(AppDbContext db)
    {
        _db = db;        
    }

    [HttpGet(Name = "employee")]
    public IActionResult GetEmployees()
    {
        return Ok(_db.Find<Employee>());       
    }

    [HttpGet("{id:int}")]
    public IActionResult GetEmployee(int id)
    {
        return Ok(_db.Find<Employee>(id));       
    }

    [HttpPost]
    public IActionResult AddEmployee(Employee e){
        _db.Add(e);
        _db.SaveChanges();
        return Created($"/employee/{e.Id}", e);
    }









    







    
     
}
