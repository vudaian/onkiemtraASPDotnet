using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TongHop.Models;

namespace TongHop.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> ListStudent = new List<Student>();
        public IActionResult Index()
        {
            return View();
        }

        //Các kiểu dữ liệu trả về của action
        //ContentResult: Trả về 1 chuỗi, hàm sử dụng là content
        public ContentResult GetContent()
        {
            return Content("Vu Dai An");
        }

        //RedirectToActionResult: chuyển sang 1 action hoặc 1 action của controller khác, hàm sử dụng RedirectToAction
        public RedirectToActionResult RedirectToAnother()
        {
            return RedirectToAction("Privacy");
        }

        //RedirectResult: trả về 1 URL khác, hàm sử dụng Redirect()
        public RedirectResult RedirectURL()
        {
            return Redirect("/Home/Privacy");
        }

        //ViewResult: Trả về view  khác để hiển thị, hàm sử dụng View()
        public ViewResult GetView()
        {
            return View("Privacy");
        }

        //JsonResult: trả về dữ liệu dạng Json, hàm sử dụng là Json()
        List<string> flowers = new List<String>()
        {
            "Dao", "Hong"
        };
        public JsonResult GetJson()
        {
            return Json(flowers);
        }

        //Trả về kiểu nguyên thủy: int, float, ...
        public int CountFlower()
        {
            return flowers.Count;
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult ShowStudent()
        {
            return View(ListStudent);
        }

        //Các cách lấy dữ liệu từ form

        //Cách 1: Tiếp nhận tham số
        //public IActionResult Save()
        //{
        //    Student student = new Student();
        //    student.ID = Request.Form["ID"];
        //    student.Name = Request.Form["Name"];
        //    student.ClassName = Request.Form["ClassName"];
        //    student.Address = Request.Form["Address"];
        //    ListStudent.Add(student);
        //    return RedirectToAction("Info");
        //}

        //Cách 2: Sử dụng IFormCollection
        //public IActionResult Save(IFormCollection form)
        //{
        //    Student student = new Student();
        //    student.ID = form["ID"];
        //    student.Name = form["Name"];
        //    student.ClassName = form["ClassName"];
        //    student.Address = form["Address"];
        //    ListStudent.Add(student);
        //    return RedirectToAction("Info");
        //}

        //Cách 3: Sử dụng đối số Action, chỉ nhận các tham số trùng tên
        //public IActionResult Save(string ID, string Name, string ClassName, string Address)
        //{
        //    Student student = new Student();
        //    student.ID = ID;
        //    student.Name = Name;
        //    student.ClassName = ClassName;
        //    student.Address = Address;
        //    ListStudent.Add(student);
        //    return RedirectToAction("Info");
        //}

        //Cách 4: Sử dụng model
        public IActionResult Save(Student student)
        {
            ListStudent.Add(student);
            return RedirectToAction("ShowStudent");
        }

        //Cách 5: DataSharing 
        //public IActionResult Save(Student student)
        //{
        //    //Lưu thông tin khách hàng vào Session
        //    HttpContext.Session.SetString("ID", student.ID);
        //    HttpContext.Session.SetString("Name", student.Name);
        //    HttpContext.Session.SetString("ClassName", student.ClassName);
        //    HttpContext.Session.SetString("Address", student.Address);
        //    return RedirectToAction("ShowStudent", "Student");
        //}

        //Tổng hợp
        public IActionResult TongHop()
        {
            return View();
        }
    }
}
