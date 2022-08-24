using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : Controller
    {
        public static List<Department> departments = new List<Department>();
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            return departments;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Department department)
        {
            departments.Add(department);

            return Ok("Added");
        }
        [HttpPut]
        public IActionResult Put([FromBody] Department department)
        {
            bool isExits = departments.Contains(departments.Find(dep => dep.DepartmentId == department.DepartmentId));
            if (!isExits)
                return BadRequest("Record not exits");
            try
            {
                departments.Find(d => d.DepartmentId == department.DepartmentId).DepartmentName = department.DepartmentName;
                return Ok("Modified");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpDelete]

        public IActionResult Delete(int depNo)
        {
            bool isExits = departments.Contains(departments.Find(d => d.DepartmentId == depNo));
            if (!isExits)
                return BadRequest("Record not exits");
            try
            {
                departments.Remove(departments.Find(d => d.DepartmentId == depNo));

                return Ok("Deleted");

            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
