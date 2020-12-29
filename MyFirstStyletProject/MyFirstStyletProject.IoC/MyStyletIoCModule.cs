using MyFirstStyletProject.Shared.Interfaces;
using MyStyletExamples.DataAccess;
using StyletIoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFirstStyletProject.IoC
{
    public class MyStyletIoCModule : StyletIoCModule
    {
        protected override void Load()
        {
            Bind<IStaffRepository>().To<StaffRepository>().InSingletonScope();
        }
    }
}
