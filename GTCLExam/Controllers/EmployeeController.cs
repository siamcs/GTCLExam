using GTCLExam.Models;
using GTCLExam.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace GTCLExam.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext _db;

        public EmployeeController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            VmEmployeeInfo Emp = new VmEmployeeInfo();
            var oEm = _db.EmployeeInfos.Where(x => x.EmployeeId == id).FirstOrDefault();
            if (oEm != null)
            {
                Emp.ID= oEm.ID;
                Emp.EmployeeId = oEm.EmployeeId;
                Emp.ID += "GCTL-00" + oEm.ID;
                Emp.Name = oEm.Name;
                Emp.GrossSalary = oEm.GrossSalary;
                Emp.JoinDate = oEm.JoinDate;
            }
            Emp = Emp == null ? new VmEmployeeInfo() : Emp;
            ViewData["Designation"] = new SelectList(_db.Designations, "DesignationId", "DesignationName");
            ViewData["EmployeeList"] = _db.EmployeeInfos.ToList();
            return View(Emp);
        }

        [HttpPost]
        public async Task<IActionResult> Index(VmEmployeeInfo vmEmp)
        {
            
            var oEmployee = _db.EmployeeInfos.FirstOrDefault(x => x.EmployeeId == vmEmp.EmployeeId);
            if (oEmployee == null)
            {
                oEmployee = new EmployeeInfo();
                oEmployee.ID="GCTL-00"+ vmEmp.ID;
                oEmployee.Name = vmEmp.Name;
               // oEmployee.Designation = vmEmp.Designation;
                oEmployee.GrossSalary = vmEmp.GrossSalary;
                oEmployee.JoinDate = vmEmp.JoinDate;
                oEmployee.DesignationId = vmEmp.DesignationId;
                _db.EmployeeInfos.Add(oEmployee);
            }
            else
            {
                oEmployee.Name = vmEmp.Name;
                oEmployee.ID = "GCTL-00" + vmEmp.ID;
                // oEmployee.Designation = vmEmp.Designation;
                oEmployee.GrossSalary = vmEmp.GrossSalary;
                oEmployee.JoinDate = vmEmp.JoinDate;
                oEmployee.DesignationId= vmEmp.DesignationId;
            }
            ViewData["Designation"] = new SelectList(_db.Designations, "DesignationId", "DesignationName");
            await _db.SaveChangesAsync();
            return RedirectToAction("Index", new { resetEmployeeId = true });
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var emp = _db.EmployeeInfos.Find(id);
            _db.EmployeeInfos.Remove(emp);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}


