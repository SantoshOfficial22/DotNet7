using BusinessAccessLayer.Implementation;
using ModelAccessLayer.Model;
using System.Web.Mvc;

namespace CRUDUsingMVCwithAdoDotNet.Controllers
{
    public class EmployeeController : Controller
    {

        // GET: Employee/AddEmployee    
        public ActionResult AddEmployee()
        {
            return View();
        }

        // POST: Employee/AddEmployee    
        [HttpPost]
        public ActionResult AddEmployee(EmpModel Emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Employee employee = new Employee();

                    if (employee.AddEmployee(Emp))
                    {
                        ViewBag.Message = "Employee details added successfully";
                    }
                    else
                    {
                        ViewBag.Message = "Something went wrong and employee details has not added";
                    }
                }

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/GetAllEmpDetails    
        public ActionResult GetAllEmpDetails()
        {

            Employee employee = new Employee();
            ModelState.Clear();
            return View(employee.GetAllEmpDetails());
        }
        
        // GET: Employee/EditEmpDetails/5    
        public ActionResult EditEmpDetails(int id)
        {
            Employee employee = new Employee();

            return View(employee.EditEmpDetails(id));

        }

        // POST: Employee/EditEmpDetails/5    
        [HttpPost]

        public ActionResult EditEmpDetails( EmpModel obj)
        {
            try
            {
                Employee employee = new Employee();
                employee.EditEmpDetails(obj);
                return RedirectToAction("GetAllEmpDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/DeleteEmp/5    
        public ActionResult DeleteEmp(int id)
        {
            try
            {
                Employee employee = new Employee();
                if (employee.DeleteEmp(id))
                {
                    TempData["DeleteEmp"] = "Employee details deleted successfully";

                }
                return RedirectToAction("GetAllEmpDetails");

            }
            catch
            {
                return View();
            }
        }
    }
}