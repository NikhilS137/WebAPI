using Microsoft.AspNetCore.Mvc;
using WebAPI.Model;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>();
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            return students;
        }
        [HttpPost]
        public IActionResult Post([FromBody] Student student)
        {
            //unchecked
            //{
            //    int id = int.MaxValue + 1;

            //}
            List<Department> departments = DepartmentController.departments;
            bool isExits = departments.Contains(departments.Find(d => d.DepartmentId == student.DepartmentID));
            if (!isExits)
            {
                return BadRequest("Department Not Found");
            }

            try
            {
                students.Add(student);
                return Ok("Added");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }


        }
        [HttpPut]
        public IActionResult Put([FromBody] Student student)
        {
            List<Department> departments = DepartmentController.departments;
            bool isStudentExits = students.Contains(students.Find(s => s.StudentId == student.StudentId));
            bool isExits = departments.Contains(departments.Find(d => d.DepartmentId == student.DepartmentID));
            if (isStudentExits)
            {
                if (!isExits)
                {
                    return BadRequest("Department Not Found");
                }
                return BadRequest("Student Not Found");
            }
            try
            {
                students.Find(s => s.StudentId == student.StudentId).Name = student.Name;
                students.Find(s => s.StudentId == student.StudentId).DepartmentID = student.DepartmentID;
                return Ok("Modified");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }
        [HttpDelete]

        public IActionResult Delete(int studNo)
        {
            bool isExits = students.Contains(students.Find(s => s.StudentId == studNo));
            if (!isExits)
                return BadRequest("Record not exits");
            try
            {
                students.Remove(students.Find(s => s.StudentId == studNo));

                return Ok("Deleted");
            }
            catch (Exception ex)
            {
                return BadRequest("Something went wrong");
            }
        }
    }
}
