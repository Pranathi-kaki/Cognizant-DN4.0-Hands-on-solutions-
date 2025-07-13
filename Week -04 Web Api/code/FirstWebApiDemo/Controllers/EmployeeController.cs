using FirstWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FirstWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin,POC")] // ✅ Requires JWT token with Admin role
    public class EmployeeController : ControllerBase
    {
        private readonly List<Employee> employees;

        public EmployeeController()
        {
            employees = new List<Employee>
            {
                new Employee
                {
                    Id = 1,
                    Name = "Pranathi",
                    salary = 50000,
                    permanent = true,
                    Department = new Department { Id = 1, Name = "IT" },
                    Skills = new List<Skill>
                    {
                        new Skill { Id = 1, Name = "C#" },
                        new Skill { Id = 2, Name = "ASP.NET" }
                    },
                    DateOfBirth = new DateTime(2000, 5, 21)
                }
            };
        }

        /// <summary>
        /// ✅ Get list of standard employees (Admin access only)
        /// </summary>
        [HttpGet("standard")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public ActionResult<List<Employee>> GetStandard()
        {
            return Ok(employees);
        }
    }
}
