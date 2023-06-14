using System.Web.Project.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.CodeAnalysis;

namespace System.Web.Project.Data
{
    public interface IDAL
    {
      

        public List<Event> GetEvents();
        public List<Event> GetMyEvents(string userid);
        public Event GetEvent(int id);
        public void CreateEvent(IFormCollection form);
        public void UpdateEvent(IFormCollection form);
        public void DeleteEvent(int id);
        public List<Models.Location> GetLocations();
        public Models.Location GetLocation(int id);
        public void CreateLocation(Models.Location location);
        public void DeleteLocation(int id);


        //Employee

        public List<Employee> GetEmployees();
        public List<Employee> GetMyEmployees(string userid);
        public Employee GetEmployee(int id);
        public void CreateEmployee(IFormCollection form);
        public void DeleteEmployee(int id);
        public void UpdateEmployee(IFormCollection form);
       

        //Department
        public List<Department> GetDepartments();
        public Department GetDepartment(int id);
        public void CreateDepartment(Department department);
        public void DeleteDepartment(int id);
        
    }

    public class DAL : IDAL
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public List<Event> GetEvents()
        {
            return db.Events.ToList();
        }

        public List<Event> GetMyEvents(string userid)
        {
            return db.Events.Where(x => x.User.Id == userid).ToList();
        }

        public Event GetEvent(int id)
        {
            return db.Events.FirstOrDefault(x => x.Id == id);
        }

        public void CreateEvent(IFormCollection form)
        {
            
            var locname = form["Location"].ToString();
            var user = db.Users.FirstOrDefault(x => x.Id == form["UserId"].ToString());
            var newevent = new Event(form, db.Locations.FirstOrDefault(x => x.Name == locname), user);
            db.Events.Add(newevent);
            db.SaveChanges();
        }

        public void UpdateEvent(IFormCollection form)
        {
            
            var locname = form["Location"].ToString();
            var eventid = int.Parse(form["Event.Id"]);
            var myevent = db.Events.FirstOrDefault(x => x.Id == eventid);
            var location = db.Locations.FirstOrDefault(x => x.Name == locname);
            var user = db.Users.FirstOrDefault(x => x.Id == form["UserId"].ToString());
            myevent.UpdateEvent(form, location, user);
            db.Entry(myevent).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteEvent(int id)
        {
            var myevent = db.Events.Find(id);
            db.Events.Remove(myevent);
            db.SaveChanges();
        }

        public List<Models.Location> GetLocations()
        {
            return db.Locations.ToList();
        }

        public Models.Location GetLocation(int id)
        {
            return db.Locations.Find(id);
        }

        public void CreateLocation(Models.Location location)
        {
            db.Locations.Add(location);
            db.SaveChanges();
        }



        //Employee
        public List<Employee> GetEmployees()
        {
            return db.Employees.ToList();
        }
        public List<Employee> GetMyEmployees(string userid)
        {
            return db.Employees.Where(x => x.User.Id == userid).ToList();
        }
        public Employee GetEmployee(int id)
        {
            return db.Employees.FirstOrDefault(x => x.Id == id);
        }
        public void CreateEmployee(IFormCollection form)
        {
            var dep = form["Department"].ToString();
            var newemployee = new Employee(form, db.Departments.FirstOrDefault(x => x.Name == dep));
            db.Employees.Add(newemployee);
            db.SaveChanges();
        }
        public void DeleteEmployee(int id)
        {
            var myemployee = db.Employees.Find(id);
            db.Employees.Remove(myemployee);
            db.SaveChanges();
        }
        public void UpdateEmployee(IFormCollection form)
        {
            var depname = form["Department"].ToString();
            var employeeid = int.Parse(form["Employee.id"]);
            var myemployee = db.Employees.FirstOrDefault(x => x.Id == employeeid);
            var department = db.Departments.FirstOrDefault(x => x.Name == depname);
            myemployee.UpdateEmployee(form, department);
            db.Entry<Employee>(myemployee).State = EntityState.Modified;
            db.SaveChanges();


        }

        public List<Department> GetDepartments()
        {
            return db.Departments.ToList();
        }
        public Department GetDepartment(int id)
        {
            return db.Departments.Find(id);
        }
        public void CreateDepartment(Department department)
        {
            db.Departments.Add(department);
            db.SaveChanges();
        }

        public void DeleteDepartment(int id)
        {
            var department = db.Departments.Find(id);
            db.Departments.Remove(department);
            db.SaveChanges(); ;
        }
        public void DeleteLocation(int id)
        {
            var location = db.Locations.Find(id);
            db.Locations.Remove(location);
            db.SaveChanges(); 
        }


    }
}
