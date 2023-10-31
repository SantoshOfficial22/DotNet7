using BusinessAccessLayer.Abstract;
using DataAccessLayer.Repository;
using ModelAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Implementation
{
    public class Employee: IEmployee
    {

        // POST: Employee/AddEmployee/Logic   
        public bool AddEmployee(EmpModel Emp)
        {
            EmpRepository EmpRepo = new EmpRepository();
            return EmpRepo.AddEmployee(Emp);
        }

        // GET: Employee/GetAllEmpDetails/Logic       
        public List<EmpModel> GetAllEmpDetails()
        {
            EmpRepository EmpRepo = new EmpRepository();
            return EmpRepo.GetAllEmployees();
        }


        // GET: Employee/EditEmpDetails/Logic      
        public EmpModel EditEmpDetails(int id)
        {
            EmpRepository EmpRepo = new EmpRepository();
            return EmpRepo.GetAllEmployees().Find(Emp => Emp.Empid == id);
        }

        // POST: Employee/EditEmpDetails/Logic    

        public bool EditEmpDetails(EmpModel obj)
        {
            EmpRepository EmpRepo = new EmpRepository();
            return EmpRepo.UpdateEmployee(obj);
           
        }

        // GET: Employee/DeleteEmp/Logic   
        public bool DeleteEmp(int id)
        {
            EmpRepository EmpRepo = new EmpRepository();
            return EmpRepo.DeleteEmployee(id);

        }
    }
}
