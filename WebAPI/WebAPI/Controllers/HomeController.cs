using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : Controller
    {
        private static List<Employee> employees = new List<Employee>();
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employees;
        }
        [HttpPost]  
        public IActionResult Post([FromBody]Employee employee)
        {
            employees.Add(employee);

            return Ok("Added");
        }
        [HttpPut]
        public IActionResult Put([FromBody] Employee employee)
        {
            try
            {

                if (employees.Contains(employees.Find(emp => emp.EmpNo == employee.EmpNo)))
                {
                    employees.Find(emp => emp.EmpNo == employee.EmpNo).EmpName = employee.EmpName;
                    return Ok("Modified");
                }
                else
                {
                    return Ok("Record not exits");
                }
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }           
        }
        [HttpDelete]
        public IActionResult Delete(int empNo)
        {
            try
            {
                if (employees.Contains(employees.Find(emp => emp.EmpNo == empNo )))
                {
                    employees.Remove(employees.Find(emp => emp.EmpNo == empNo));

                    return Ok("Deleted");
                }
                else
                {
                    return Ok("Record not exits");
                }
            }
            catch (Exception)
            {
                return BadRequest("Something went wrong");
            }
        }

    }
}
