using Microsoft.AspNetCore.Mvc;
using EmployeeManagementMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagementMvc.Controllers
{
    public class EmployeesController : Controller
    {
        // Demo in-memory data store
        private static readonly List<Employee> _employees = new()
        {
            new Employee{ Id = "EMP00001", Name = "Edwardo Samosir", PlaceOfBirth = "Duri", DateOfBirth = new DateTime(1997,11,20), BasicSalary = 15000000, Gender = Gender.L, MaritalStatus = MaritalStatus.Single },
            new Employee{ Id = "EMP00002", Name = "Dakota Johnson",  PlaceOfBirth = "New York", DateOfBirth = new DateTime(1991,11,11), BasicSalary = 12000000, Gender = Gender.P, MaritalStatus = MaritalStatus.Married },
            new Employee{ Id = "EMP00003", Name = "Anna Hathaway",  PlaceOfBirth = "Brooklyn", DateOfBirth = new DateTime(1982,4,25), BasicSalary = 14000000, Gender = Gender.P, MaritalStatus = MaritalStatus.Single },
            new Employee{ Id = "EMP00004", Name = "Scarlett Johansson",  PlaceOfBirth = "Miami", DateOfBirth = new DateTime(1984,2,23), BasicSalary = 11000000, Gender = Gender.P, MaritalStatus = MaritalStatus.Married },
            new Employee{ Id = "EMP00005", Name = "Chris Evans",  PlaceOfBirth = "New Mexico", DateOfBirth = new DateTime(1980,3,8), BasicSalary = 25000000, Gender = Gender.L, MaritalStatus = MaritalStatus.Divorced },
        };

        public IActionResult Index() => View();

        // Read API (for table)
        [HttpGet]
        public IActionResult List() => Json(_employees);

        // Create API
        [HttpPost]
        public IActionResult Create([FromForm] Employee model)
        {
            if (!ModelState.IsValid)
                return Json(new { ok = false, message = "Invalid data" });

            if (_employees.Any(e => e.Id.Equals(model.Id, StringComparison.OrdinalIgnoreCase)))
                return Json(new { ok = false, message = "ID already exists." });

            _employees.Add(model);
            return Json(new { ok = true });
        }

        // Update API
        [HttpPost]
        public IActionResult Update([FromForm] Employee model)
        {
            if (!ModelState.IsValid)
                return Json(new { ok = false, message = "Invalid data" });

            var existing = _employees.FirstOrDefault(e => e.Id.Equals(model.Id, StringComparison.OrdinalIgnoreCase));
            if (existing is null)
                return Json(new { ok = false, message = "Employee not found" });

            existing.Name = model.Name;
            existing.PlaceOfBirth = model.PlaceOfBirth;
            existing.DateOfBirth = model.DateOfBirth;
            existing.BasicSalary = model.BasicSalary;
            existing.Gender = model.Gender;
            existing.MaritalStatus = model.MaritalStatus;

            return Json(new { ok = true });
        }

        // Delete API
        [HttpPost]
        public IActionResult Delete([FromForm] string id)
        {
            var idx = _employees.FindIndex(e => e.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
            if (idx < 0) return Json(new { ok = false, message = "Employee not found" });

            _employees.RemoveAt(idx);
            return Json(new { ok = true });
        }
    }
}