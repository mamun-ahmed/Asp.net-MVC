using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Lawer_Project.Models;

namespace Lawer_Project.Controllers
{
    public class Employee_RegisterController : ApiController
    {
        private Lawer_DatabaseEntities db = new Lawer_DatabaseEntities();

        // GET: api/Employee_Register
        public IQueryable<Employee_Register> GetEmployee_Register()
        {
            return db.Employee_Register;
        }

        // GET: api/Employee_Register/5
        [ResponseType(typeof(Employee_Register))]
        public IHttpActionResult GetEmployee_Register(int id)
        {
            Employee_Register employee_Register = db.Employee_Register.Find(id);
            if (employee_Register == null)
            {
                return NotFound();
            }

            return Ok(employee_Register);
        }

        // PUT: api/Employee_Register/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmployee_Register(int id, Employee_Register employee_Register)
        {

            if (id != employee_Register.Employee_ID)
            {
                return BadRequest();
            }

            db.Entry(employee_Register).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Employee_RegisterExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Employee_Register
        [ResponseType(typeof(Employee_Register))]
        public IHttpActionResult PostEmployee_Register(Employee_Register employee_Register)
        {

            db.Employee_Register.Add(employee_Register);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = employee_Register.Employee_ID }, employee_Register);
        }

        // DELETE: api/Employee_Register/5
        [ResponseType(typeof(Employee_Register))]
        public IHttpActionResult DeleteEmployee_Register(int id)
        {
            Employee_Register employee_Register = db.Employee_Register.Find(id);
            if (employee_Register == null)
            {
                return NotFound();
            }

            db.Employee_Register.Remove(employee_Register);
            db.SaveChanges();

            return Ok(employee_Register);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Employee_RegisterExists(int id)
        {
            return db.Employee_Register.Count(e => e.Employee_ID == id) > 0;
        }
    }
}