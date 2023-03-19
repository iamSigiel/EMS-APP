using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMS_APP.Data;
using EMS_APP.Models;
using System.Data;
using EMS_APP.Repository.Interfaces;

namespace EMS_APP.Controllers
{
    public class DepartmentsController : Controller
    {
        //private readonly EMS_DBContext _repo;

        IDepartmentRepo _repo;

        public DepartmentsController(IDepartmentRepo repo)
        {
            _repo = repo;   
        }

        // GET: Departments
        public async Task<IActionResult> Index()
        {
              return _repo.GetAllDepartments() != null ? 
                          View(_repo.GetAllDepartments()) :
                          Problem("Entity set 'EMS_DBContext.DEPARTMENTS'  is null.");
        }

        // GET: Departments/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _repo.GetDepartmentById(id) == null)
            {
                return NotFound();
            }

            var department = _repo.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // GET: Departments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind(include:"deptID,deptName")] departmentModel department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.AddDepartment(department);
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(department);
        }

        // GET: Departments/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _repo.GetDepartmentById(id) == null)
            {
                return NotFound();
            }

            var department = _repo.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("deptID,deptName")] departmentModel department)
        {
            if (id != department.deptID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.UpdateDepartment(id, department);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!departmentModelExists(department.deptID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _repo.GetDepartmentById(id) == null)
            {
                return NotFound();
            }

            var department = _repo.GetDepartmentById(id);
                
            if (department == null)
            {
                return NotFound();
            }

            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_repo.GetDepartmentById(id) == null)
            {
                return Problem("Entity set 'EMS_DBContext.DEPARTMENTS'  is null.");
            }
            var departmentModel =  _repo.GetDepartmentById(id);
            if (departmentModel != null)
            {
                _repo.DeleteDepartment(id);
            }
            
            
            return RedirectToAction(nameof(Index));
        }

        private bool departmentModelExists(int id)
        {
          return (_repo.GetAllDepartments()?.Any(e => e.deptID == id)).GetValueOrDefault();
        }
    }
}
