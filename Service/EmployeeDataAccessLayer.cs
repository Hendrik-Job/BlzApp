using BlzApp.Interfaces;
using BlzApp.Models;
using BlzApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlzApp.Service
{
    public class EmployeeDataAccessLayer : IEmployee
    {
        private readonly ApplicationDbContext context;
        public EmployeeDataAccessLayer(ApplicationDbContext context)
        {
            this.context = context;
        }

        //To Get all employees details   
        public IEnumerable<Employee> GetAllEmployees()
        {
            try
            {
                return context.tblEmployee.ToList();
                //return db.tblEmployee.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new employee record     
        public void AddEmployee(Employee employee)
        {
            try
            {
                context.tblEmployee.Add(employee);
                context.SaveChanges();               
            }
            catch
            {
                throw;
            }
        }

        //To Update the records of a particluar employee    
        public void UpdateEmployee(Employee employee)
        {
            try
            {
                context.Entry(employee).State = EntityState.Modified;
                context.SaveChanges();               
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular employee    
        public Employee GetEmployeeData(int id)
        {
            try
            {
                Employee employee = context.tblEmployee.Find(id);
                return employee;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular employee    
        public void DeleteEmployee(int id)
        {
            try
            {
                Employee emp = context.tblEmployee.Find(id);
                context.tblEmployee.Remove(emp);
                context.SaveChanges();               
            }
            catch
            {
                throw;
            }
        }
    }
}
