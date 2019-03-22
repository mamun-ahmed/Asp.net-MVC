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
    public class School_CostingController : ApiController
    {
        private Lawer_DatabaseEntities db = new Lawer_DatabaseEntities();

        // GET: api/School_Costing
        public IQueryable<School_Costing> GetSchool_Costing()
        {
            return db.School_Costing;
        }

        // GET: api/School_Costing/5
        [ResponseType(typeof(School_Costing))]
        public IHttpActionResult GetSchool_Costing(int id)
        {
            School_Costing school_Costing = db.School_Costing.Find(id);
            if (school_Costing == null)
            {
                return NotFound();
            }

            return Ok(school_Costing);
        }

        // PUT: api/School_Costing/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutSchool_Costing(int id, School_Costing school_Costing)
        {

            if (id != school_Costing.School_CostingID)
            {
                return BadRequest();
            }

            db.Entry(school_Costing).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!School_CostingExists(id))
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

        // POST: api/School_Costing
        [ResponseType(typeof(School_Costing))]
        public IHttpActionResult PostSchool_Costing(School_Costing school_Costing)
        {

            db.School_Costing.Add(school_Costing);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = school_Costing.School_CostingID }, school_Costing);
        }

        // DELETE: api/School_Costing/5
        [ResponseType(typeof(School_Costing))]
        public IHttpActionResult DeleteSchool_Costing(int id)
        {
            School_Costing school_Costing = db.School_Costing.Find(id);
            if (school_Costing == null)
            {
                return NotFound();
            }

            db.School_Costing.Remove(school_Costing);
            db.SaveChanges();

            return Ok(school_Costing);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool School_CostingExists(int id)
        {
            return db.School_Costing.Count(e => e.School_CostingID == id) > 0;
        }
    }
}