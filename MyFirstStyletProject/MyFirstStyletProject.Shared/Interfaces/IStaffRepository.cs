using MyFirstStyletProject.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstStyletProject.Shared.Interfaces
{
    public interface IStaffRepository
    {
        List<Employee> GetEmployees();
    }
}
