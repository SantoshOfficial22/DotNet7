using ModelAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayer.Abstract
{
    public interface IEmployee
    {
        bool AddEmployee(EmpModel Emp);
        List<EmpModel> GetAllEmpDetails();
        EmpModel EditEmpDetails(int id);
        bool EditEmpDetails(EmpModel obj);
        bool DeleteEmp(int id);
    }
}
