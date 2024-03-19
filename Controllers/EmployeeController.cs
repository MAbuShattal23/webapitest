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

    [HttpPut]
    public IActionResult UpdateEmployee(int id, [FromBody] Employee e){
        if(id != e.Id){
            return BadRequest();
        }
        if(_db.Find<Employee>(id) == null){
            return NotFound();            
        }
        _db.Entry(e).State = EntityState.Modified;
        _db.SaveChanges();
        return NoContent();
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
