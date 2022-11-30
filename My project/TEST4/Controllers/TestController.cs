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
    public class TestController : ControllerBase
    {
        private DatabaseContext db;
        public TestController(DatabaseContext database)
        {
            this.db = database;
        }
        //获取数据
        [HttpGet("get_data")]
        public IActionResult get_data()
        {
            /* var data = db.Test.OrderByDescending(stu => Convert.ToInt32(stu.ID)).ToList(); */
            var data = db.Test.OrderBy(stu => Convert.ToInt32(stu.ID)).ToList();
            return Ok(data);
        }
        [HttpGet("get_special")]
        public IActionResult get_special()
        {
            string x = "sd";
            var special_data = db.Test.Where(stu => Convert.ToInt32(stu.ID) == 1 );
            /*var student2 = db.Students.Where(stu => stu.StuName == "a" && Convert.ToInt32(stu.StudentId) == 3);
            var student3 = db.Students.OrderByDescending(stu => stu.StudentId).ToList();
            var student4 = db.Students.Sum(stu => Convert.ToInt32(stu.StudentId)); */
            return Ok(special_data);
        }

        //添加一条学生信息
        [HttpPost("add_data")]
        public IActionResult add_data(Test tests)
        {
            var fl = db.Test.FirstOrDefault(stu => stu.ID == tests.ID);
            if (fl != null)
            {
                return Ok("该学生学号已存在!");
            }
            db.Test.Add(tests);
            db.SaveChanges();
            return Ok(tests.ID + "学生添加完成");
        }

        //根据学生学号修改学生信息
         [HttpPut("update_data")]
        public IActionResult update_data(Test tests)
        {
            //判断该学号存不存在
            var data = db.Test.FirstOrDefault(stu => stu.ID == tests.ID);
            if (data == null)
            {
                return BadRequest("修改学习失败");
            }
            data.Temp = tests.Temp;
            data.CurrentSpeed = tests.CurrentSpeed;
            data.Sicon = tests.Sicon;
            data.Ratio = tests.Ratio;
            db.Test.Update(data);
            db.SaveChanges();
            return Ok(data);
        }
/*         //根据学号删除学生信息
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
        }   */       

/*          [HttpDelete("login")]
        public IActionResult get_No_password(string userNo, string password)
        {
             var student = db.Students.Where(stu => stu.UserNo == userNo && stu.password == password); 
            var student = db.Students.FirstOrDefault(stu => stu.UserNo == userNo && stu.password == password);
            if (student == null)
            {
                return BadRequest("账号密码错误");
            }
            return Ok(student);
        }   */
    }
}

