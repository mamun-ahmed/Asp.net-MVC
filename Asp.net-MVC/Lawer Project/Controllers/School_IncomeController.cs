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
    public class School_IncomeController : ApiController
    {
        private Lawer_DatabaseEntities db = new Lawer_DatabaseEntities();

        // GET: api/School_Income
        public IQueryable<School_Income> GetSchool_Income()
        {
            return db.School_Income;
        }

        // GET: api/School_Income/5
        [ResponseType(typeof(School_Income))]
        public IHttpActionResult GetSchool_Income(int id)
        {
            School_Income school_Income = db.School_Income.Find(id);
            if (school_Income == null)
            {
                return NotFound();
            }

            return Ok(school_Income);
        }

        // PUT: api/School_Income/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSchool_Income(int id, School_Income school_Income)
        {

            if (id != school_Income.School_IncomeID)
            {
                return BadRequest();
            }

            db.Entry(school_Income).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!School_IncomeExists(id))
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

        // POST: api/School_Income
        [ResponseType(typeof(School_Income))]
        public IHttpActionResult PostSchool_Income(School_Income school_Income)
        {

            db.School_Income.Add(school_Income);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = school_Income.School_IncomeID }, school_Income);
        }

        // DELETE: api/School_Income/5
        [ResponseType(typeof(School_Income))]
        public IHttpActionResult DeleteSchool_Income(int id)
        {
            School_Income school_Income = db.School_Income.Find(id);
            if (school_Income == null)
            {
                return NotFound();
            }

            db.School_Income.Remove(school_Income);
            db.SaveChanges();

            return Ok(school_Income);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool School_IncomeExists(int id)
        {
            return db.School_Income.Count(e => e.School_IncomeID == id) > 0;
        }
    }
}