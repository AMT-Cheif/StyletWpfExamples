using MyFirstStyletProject.Shared.Models;
using Stylet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFirstStyletProject.ViewModels
{
    public class StaffDetailsViewModel : Screen
    {
        public StaffDetailsViewModel() { }

        private Employee _employee;
        public Employee Employee
        {
            get => _employee;
            set => SetAndNotify(ref _employee, value);
        }

        public void GoBack()
        {
            this.RequestClose();
        }
    }
}
