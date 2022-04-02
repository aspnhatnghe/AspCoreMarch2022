using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Buoi07_MVCCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace Buoi07_MVCCore.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        const string JSON_FILE = "Student.json";
        const string TEXT_FILE = "Student.txt";
        public string PathTxtFile => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", TEXT_FILE);
        public string PathJsonFile => Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", JSON_FILE);

        [HttpPost]
        public IActionResult Index(StudentInfo model, string Save)
        {
            if (ModelState.IsValid)
            {
                if (Save == "Ghi file Text")
                {
                    var data = new string[] {
                        model.StudentId, model.FullName, 
                        model.Grade.ToString(), model.Rating
                    };
                    System.IO.File.WriteAllLines(PathTxtFile, data);
                }
                else if (Save == "Ghi file Json")
                {
                    // chuyển obect sang chuỗi json
                    var json_data = System.Text.Json.JsonSerializer.Serialize(model);
                    System.IO.File.WriteAllText(PathJsonFile, json_data);
                }
            }
            return View();
        }
    }
}