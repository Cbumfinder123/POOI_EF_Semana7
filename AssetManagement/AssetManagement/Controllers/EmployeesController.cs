using AssetManagement.Data;
using AssetManagement.Models;
using System.Linq;
using System.Web.Mvc;

namespace AssetManagement.Controllers
{
    public class EmployeesController : Controller
    {
        private EmployeeDataAccess employeeDataAccess = new EmployeeDataAccess();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = employeeDataAccess.GetAllEmployees();
            return View(employees);
        }

        // GET: Details
        public ActionResult Details(int id)
        {
            var employee = employeeDataAccess.GetAllEmployees().FirstOrDefault(e => e.employee_id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "first_name,last_name,departament,extension,email_address,other_details")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeDataAccess.AddEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }


        // GET: Edit
        public ActionResult Edit(int id)
        {
            var employee = employeeDataAccess.GetAllEmployees().FirstOrDefault(e => e.employee_id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "employee_id,first_name,last_name,departament,extension,email_address,other_details")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employeeDataAccess.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }



        // GET: Delete
        public ActionResult Delete(int id)
        {
            var employee = employeeDataAccess.GetAllEmployees().FirstOrDefault(e => e.employee_id == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            employeeDataAccess.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
