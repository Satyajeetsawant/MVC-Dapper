using DapperMvcProject.Models;
using DapperMvcProject.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DapperMvcProject.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult GetAllEmpDetails()
        {
            EmpRepository EmpRepo = new EmpRepository();
            return View(EmpRepo.GetAllEmployees());
        }

        // GET: Employee/Details/5
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        // GET: Employee/Create
        public ActionResult AddEmployee(EmpModel Emp)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    EmpRepository EmpRepo = new EmpRepository();
                    EmpRepo.AddEmployee(Emp);
                    ViewBag.Message = "Records Added Succefully";
                }
                return View();
            }catch
            {
                return View();
            }
            
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult EditEmpDetails(int id)
        {
            EmpRepository EmpRepo = new EmpRepository();
            return View(EmpRepo.GetAllEmployees().Find(Emp => Emp.Empid == id));
        }
        [HttpPost]
        // GET: Employee/Edit/5
        public ActionResult EditEmpDetails(int id, EmpModel obj)
        {
            try
            {
                EmpRepository EmpRepo = new EmpRepository();

                EmpRepo.UpdateEmployee(obj);

                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult DeleteEmp(int id)
        {
            try
            {
                EmpRepository EmpRepo = new EmpRepository();
                if (EmpRepo.DeleteEmployee(id))
                {
                    ViewBag.AlertMsg = "Employee details deleted successfully";

                }
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return RedirectToAction("GetAllEmpDetails");
            }
        }

        
    }
}
