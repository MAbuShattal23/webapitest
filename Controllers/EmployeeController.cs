using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace webapicontrollers.Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{

    private readonly AppDbContext _db;

    public EmployeeController(AppDbContext db)
    {
        _db = db;        
    }

    [HttpGet(Name = "employee")]
    public IActionResult GetEmployees()
    {
        var allEmployees = _db.Employees.ToList<Employee>();
        if(allEmployees == null){
            return NotFound();
        }
        return Ok(allEmployees);
        //return Ok(_db.Find<Employee>(1));       
    }

    [HttpGet("{id:int}")]
    public IActionResult GetEmployee(int id)
    {
        var e = _db.Find<Employee>(id);
        if(e == null){
            return NotFound();
        }
        return Ok(e);       
    }

    [HttpPost]
    public IActionResult AddEmployee(Employee e){
        _db.Add(e);
        _db.SaveChanges();
        return Created($"/employee/{e.Id}", e);
    }


    [HttpDelete("{id:int}")]
    public IActionResult DeleteEmployee(int id){
        var e = _db.Find<Employee>(id);
        if(e == null){
            return NotFound();
        }
        _db.Remove(e);
        _db.SaveChanges();
        return Ok();     
    }

    














    







    
     
}
