using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagementSystem.EntityModel;
using LibraryManagementSystem.RepositoryPattern.Interfaces.IUnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IUnitOfWork context;
        public StudentController(IUnitOfWork unitOfWork)
        {
            context = unitOfWork;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudent()
        {
            var result = await context.Student.GetAll();
            return result.ToList();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> GetStudent(int id)
        {
            var result = await context.Student.GetFirstOrDefault(item => item.Id == id);
            if (result == null)
                return NotFound();
            return result;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Student>> UpdateStudent(int id, Student student)
        {
            var result = await context.Student.GetFirstOrDefault(item => item.Id == id);
            if (result == null)
                return NotFound();

            result.Name = student.Name;
            result.StudentId = student.StudentId;
            result.PhotoUrl = student.PhotoUrl;
            result.DateOfBirth = student.DateOfBirth;
            result.Email = student.Email;
            result.Department = student.Department;
            result.UpdatedDate = System.DateTime.Now;
            await context.Save();
            return result;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            var result = await context.Student.GetFirstOrDefault(item => item.Id == id);
            if (result == null)
                return BadRequest();
            context.Student.Remove(result);
            await context.Save();
            return result;
        }
        [HttpPost]
        public async Task<ActionResult<Student>> PostStudent(Student student)
        {
            if (student == null)
                return BadRequest();
            student.CreatedDate = System.DateTime.Now;
            context.Student.Save(student);
            await context.Save();
            return student;
        }
    }
}
