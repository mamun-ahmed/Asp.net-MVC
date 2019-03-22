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
    public class Office_CostingController : ApiController
    {
        private Lawer_DatabaseEntities db = new Lawer_DatabaseEntities();

        // GET: api/Office_Costing
        public IQueryable<Office_Costing> GetOffice_Costing()
        {
            return db.Office_Costing;
        }

        // GET: api/Office_Costing/5
        [ResponseType(typeof(Office_Costing))]
        public IHttpActionResult GetOffice_Costing(int id)
        {
            Office_Costing office_Costing = db.Office_Costing.Find(id);
            if (office_Costing == null)
            {
                return NotFound();
            }

            return Ok(office_Costing);
        }

        // PUT: api/Office_Costing/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOffice_Costing(int id, Office_Costing office_Costing)
        {

            if (id != office_Costing.Office_CostID)
            {
                return BadRequest();
            }

            db.Entry(office_Costing).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Office_CostingExists(id))
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

        // POST: api/Office_Costing
        [ResponseType(typeof(Office_Costing))]
        public IHttpActionResult PostOffice_Costing(Office_Costing office_Costing)
        {

            db.Office_Costing.Add(office_Costing);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = office_Costing.Office_CostID }, office_Costing);
        }

        // DELETE: api/Office_Costing/5
        [ResponseType(typeof(Office_Costing))]
        public IHttpActionResult DeleteOffice_Costing(int id)
        {
            Office_Costing office_Costing = db.Office_Costing.Find(id);
            if (office_Costing == null)
            {
                return NotFound();
            }

            db.Office_Costing.Remove(office_Costing);
            db.SaveChanges();

            return Ok(office_Costing);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Office_CostingExists(int id)
        {
            return db.Office_Costing.Count(e => e.Office_CostID == id) > 0;
        }
    }
}