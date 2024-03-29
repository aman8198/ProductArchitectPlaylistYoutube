using EmployeeApi.Data;
using EmployeeApi.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public EmployeeController(EmployeeDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employee = await _context.Employees.ToListAsync();
            return Ok(employee);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployees(int id) 
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee == null)
                return NotFound();
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployees(Employee employee)
        {
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = await _context.Employees.FindAsync(id);
            if(existingEmployee == null)
            {
                return BadRequest();
            }
            existingEmployee.EmployeeName = employee.EmployeeName;
            existingEmployee.Department = employee.Department;
            existingEmployee.address = employee.address;
            await _context.SaveChangesAsync();

            return Ok(employee);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee =await _context.Employees.FindAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return Ok();

        }
    }
}
