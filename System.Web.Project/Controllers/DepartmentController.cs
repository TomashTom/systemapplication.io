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

namespace System.Web.Project.Controllers
{
    public class DepartmentController : Controller
    {
        
        private readonly IDAL _dal;

        public DepartmentController( IDAL dal)
        {
            
            _dal = dal;
        }

        // GET: Department
        public IActionResult Index()
        {
            if (TempData["Alert"] != null)
            {
                ViewData["Alert"] = TempData["Alert"];
            }
            return View(_dal.GetDepartments());
        }

        // GET: Department/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null )
            {
                return NotFound();
            }

            var department = _dal.GetDepartment((int)id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Department/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dal.CreateDepartment(department);
                    TempData["Alert"] = "Successfully! You create a department for:" + department.Name;
                    return RedirectToAction(nameof(Index));

                }
                catch(Exception ex)
                {
                    ViewData["Alert"] = "An error occurred" + ex.Message;
                }

            }
            return View(department);
        }

        
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var department = _dal.GetDepartment((int)id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _dal.DeleteDepartment(id);
            TempData["Alert"] = "You deleted an event.";
            return RedirectToAction(nameof(Index));
        }
    }


}

