using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Xml.Linq;
using TestWebapi.Models;

namespace TestWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("any")]
    public class StudentController : ControllerBase
    {
        private DatabaseContext db;
        public StudentController(DatabaseContext database)
        {
            this.db = database;
        }
        //获取学生数据
        [HttpGet("getall")]
        public IActionResult getStudent()
        {
            List<Students> students = db.Students.ToList();
            return Ok(db.Students);
        }
        [HttpGet("getStudent1")]
        public IActionResult getStudent1()
        {
            string x = "sd";
            var student1 = db.Students.Where(stu => Convert.ToInt32(stu.ID) == 1 );
            /*var student2 = db.Students.Where(stu => stu.StuName == "a" && Convert.ToInt32(stu.StudentId) == 3);
            var student3 = db.Students.OrderByDescending(stu => stu.StudentId).ToList();
            var student4 = db.Students.Sum(stu => Convert.ToInt32(stu.StudentId)); */
            return Ok(student1);
        }

        //添加一条学生信息
        [HttpPost("addStudent")]
        public IActionResult addStudent(Students students)
        {
            var student = db.Students.FirstOrDefault(stu => stu.ID == students.ID);
            if (student != null)
            {
                return Ok("该学生学号已存在!");
            }
            db.Students.Add(students);
            db.SaveChanges();
            return Ok(students.ID + "学生添加完成");
        }

        //根据学生学号修改学生信息
         [HttpPut("updateStudent")]
        public IActionResult updateStudent(Students students)
        {
            //判断该学号存不存在
            var student = db.Students.FirstOrDefault(stu => stu.ID == students.ID);
            if (student == null)
            {
                return BadRequest("修改学习失败");
            }
            student.UserName = students.UserName;
            student.Userlevel = students.Userlevel;
            student.UserNo = students.UserNo;
            student.password = students.password;
            db.Students.Update(student);
            db.SaveChanges();
            return Ok(student);
        }
        //根据学号删除学生信息
        [HttpDelete("delStudent")]
        public IActionResult delStudent(string id)
        {
            var student = db.Students.FirstOrDefault(stu => stu.ID == id);
            if (student == null)
            {
                return NotFound();
            }
            db.Students.Remove(student);
            db.SaveChanges();
            return Ok(student);
        }         

        [HttpDelete("login")]
        public IActionResult get_No_password(string userNo, string password)
        {
            /* var student = db.Students.Where(stu => stu.UserNo == userNo && stu.password == password); */
            var student = db.Students.FirstOrDefault(stu => stu.UserNo == userNo && stu.password == password);
            if (student == null)
            {
                return BadRequest("账号密码错误");
            }
            return Ok(student);
        } 
    }
}

