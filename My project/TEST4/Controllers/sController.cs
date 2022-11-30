using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TestWebapi.Models;

namespace TEST4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class sController : ControllerBase
    {
        private DatabaseContext sdb;
        public sController(DatabaseContext database)
        {
            this.sdb = database;
        }
        //获取学生数据
        [HttpGet("gets")]
        public IActionResult gets()
        {
            List<s> S = sdb.s.ToList();
            return Ok(S);
        }

        /*添加一条学生信息
        [HttpPost("addStudent")]
        public IActionResult addStudent(Students students)
        {
            var student = db.Students.FirstOrDefault(stu => stu.StudentId == students.StudentId);
            if (student != null)
            {
                return Ok("该学生学号已存在!");
            }
            db.Students.Add(students);
            db.SaveChanges();
            return Ok(students.StudentId + "学生添加完成");
        }

        //根据学生学号修改学生信息
        [HttpPut("updateStudent")]
        public IActionResult updateStudent(Students students)
        {
            //判断该学号存不存在
            var student = db.Students.FirstOrDefault(stu => stu.StudentId == students.StudentId);
            if (student == null)
            {
                return BadRequest("修改学习失败");
            }
            student.StuName = students.StuName;
            student.StuSex = students.StuSex;
            db.Students.Update(student);
            db.SaveChanges();
            return Ok(student);
        }
        //根据学号删除学生信息
        [HttpDelete("delStudent")]
        public IActionResult delStudent(string id)
        {
            var student = db.Students.FirstOrDefault(stu => stu.StudentId == id);
            if (student == null)
            {
                return NotFound();
            }
            db.Students.Remove(student);
            db.SaveChanges();
            return Ok(student);
        }*/
    }
}
