using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EMS_APP.Data;
using EMS_APP.Models;
using EMS_APP.Repository.Interfaces;

namespace EMS_APP.Controllers
{
    public class EmployeesController : Controller
    {
        //private readonly EMS_DBContext _repo;
        IEmployeeRepo _repo;
        IDepartmentRepo _repo2;
        

        public EmployeesController(IEmployeeRepo repo, IDepartmentRepo repo2)
        {
            _repo = repo;
            _repo2 = repo2;
            
        }

        // GET: Employees
        public async Task<IActionResult> Index()
        {
            return _repo.GetAllEmployees() != null ?
                          View(_repo.GetAllEmployees()) :
                          Problem("Entity set 'EMS_DBContext.EMPLOYEES'  is null.");
        }

        // GET: Employees/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || _repo.GetEmployeeById(id) == null)
            {
                return NotFound();
            }

            var employee = _repo.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            //ViewBag.DepartmentName = employee.department.deptName;
            return View(employee);
        }

        // GET: Employees/Create
        public IActionResult Create()
        {
            ViewData["deptID"] = new SelectList(_repo2.GetAllDepartments(), "deptID", "deptName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("empId,empName,empDOB,empEmail,empPhone,isAdmin,deptID")] employeeModel employee)
        {
            if (ModelState.IsValid)
            {
                _repo.AddEmployee(employee);
                return RedirectToAction(nameof(Index));
            }
            ViewData["deptID"] = new SelectList(_repo2.GetAllDepartments(), "deptID", "deptName", employee.deptID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null || _repo.GetEmployeeById(id) == null)
            {
                return NotFound();
            }

            var employee = _repo.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            ViewData["deptID"] = new SelectList(_repo2.GetAllDepartments(), "deptID", "deptName", employee.deptID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("empId,empName,empDOB,empEmail,empPhone,isAdmin,deptID")] employeeModel employee)
        {
            //if (id != employee.id)
            //{
            //    return NotFound();
            //}

            if (ModelState.IsValid)
            {
                try
                {
                    _repo.UpdateEmployee(id, employee);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!employeeModelExists(employee.id))
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
            ViewData["deptID"] = new SelectList(_repo2.GetAllDepartments(), "deptID", "deptName", employee.department);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null || _repo.GetEmployeeById(id) == null)
            {
                return NotFound();
            }

            var employee = _repo.GetEmployeeById(id);
               
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_repo.GetEmployeeById(id) == null)
            {
                return Problem("Entity set 'EMS_DBContext.EMPLOYEES'  is null.");
            }
            var employee =  _repo.GetEmployeeById(id);
            if (employee != null)
            {
                _repo.DeleteEmployee(id);
            }
            return RedirectToAction(nameof(Index));
        }

        private bool employeeModelExists(int id)
        {
          return (_repo.GetAllEmployees()?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
