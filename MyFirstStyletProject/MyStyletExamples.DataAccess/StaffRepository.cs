using Bogus;
using MyFirstStyletProject.Shared.Interfaces;
using MyFirstStyletProject.Shared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyStyletExamples.DataAccess
{
    public class StaffRepository : IStaffRepository
    {

        public List<Employee> GetEmployees()
        {
            var faker = new Faker<Employee>()
                .RuleFor(e => e.FirstName, (f, e) => f.Name.FirstName())
                .RuleFor(e => e.LastName, (f, e) => f.Name.LastName())
                .RuleFor(e => e.Avatar, f => f.Internet.Avatar())
                .RuleFor(e => e.Email, (f, e) => f.Internet.Email(e.FirstName, e.LastName))
                .RuleFor(e => e.JobTitle, f => f.Name.JobTitle())
                .RuleFor(e => e.About, f => f.Lorem.Paragraph(10));

            return faker.Generate(10);
        }
    }
}
