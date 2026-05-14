using Microsoft.AspNetCore.Mvc;
using EmployeeManagementAPI.Data;
using EmployeeManagementAPI.Models;

namespace EmployeeManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmployeeController(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL
        [HttpGet]
        public IActionResult GetEmployees()
        {
            var employees = _context.Employees.ToList();
            return Ok(employees);
        }

        // ADD EMPLOYEE
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();

            return Ok(employee);
        }

        // UPDATE EMPLOYEE
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, Employee updatedEmployee)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            employee.name = updatedEmployee.name;
            employee.Department = updatedEmployee.Department;
            employee.Salary = updatedEmployee.Salary;

            _context.SaveChanges();

            return Ok(employee);
        }

        // DELETE EMPLOYEE
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = _context.Employees.Find(id);

            if (employee == null)
            {
                return NotFound("Employee not found");
            }

            _context.Employees.Remove(employee);

            _context.SaveChanges();

            return Ok("Employee deleted successfully");
        }



    }
}