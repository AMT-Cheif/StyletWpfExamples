using MyFirstStyletProject.Shared.Interfaces;
using MyFirstStyletProject.Shared.Models;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstStyletProject.ViewModels
{
    public class StaffViewModel : Screen
    {
        private readonly IStaffRepository _staffData;

        public StaffViewModel(IStaffRepository staffData)
        {
            _staffData = staffData;
        }

        private List<Employee> _employees;
        public List<Employee> Employees
        {
            get => _employees;
            set => SetAndNotify(ref _employees, value);
        }

        protected override void OnInitialActivate()
        {
            Employees = _staffData.GetEmployees();
        }

        public void StaffDetails(Employee employee)
        {
            var staffDetailsVM = new StaffDetailsViewModel { Employee = employee };
            ((ShellViewModel)this.Parent).ActivateItem(staffDetailsVM);
        }
    }
}
