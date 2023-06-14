using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Web.Project.Data;
using System.Web.Project.Models;
using System.Web.Project.Models.ViewModels;
using System.Runtime.InteropServices;

namespace System.Web.Project.Controllers
{
    public class EmployeeController : Controller
    {

        private readonly IDAL _dal;

        public EmployeeController(IDAL dal)
        {

            _dal = dal;
        }

        // GET: Employee
        public IActionResult Index(string sortOrder)
        {
            
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_dal.GetEmployees());

        }

        // GET: Employee/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _dal.GetEmployee((int)id);

            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {

            return View(new EmployeeViewModel(_dal.GetDepartments()));
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EmployeeViewModel vm, IFormCollection form)
        {
            try
            {
                _dal.CreateEmployee(form);
                TempData["Alert"] = "Success! You created a new employee for: " + form["Employee.Name"];
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                TempData["Alert"] = "An error occurred: " + ex.Message;
                return View(vm);
            }

        }

        // GET: Employee/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _dal.GetEmployee((int)id);
            if (employee == null)
            {
                return NotFound();
            }
            var vm = new EmployeeViewModel(employee, _dal.GetDepartments());
            return View(vm);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, IFormCollection form)
        {

            try
            {
                _dal.UpdateEmployee(form);
                TempData["Alert"] = "Success You modified an employee for: " + form["Employee.EmployeeName"];
                return RedirectToAction("Index");


            }
            catch (Exception ex)
            {
                ViewData["Alert"] = "An error occurred: " + ex.Message;
                var vm = new EmployeeViewModel(_dal.GetDepartments());
                return View(vm);

            }

        }

        // GET: Employee/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var employee = _dal.GetEmployee((int)id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            _dal.DeleteEmployee(id);
            TempData["Alert"] = "You deleted an employee.";
            return RedirectToAction(nameof(Index));
        }
    }
}
