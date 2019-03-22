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
    public class Family_CostingController : ApiController
    {
        private Lawer_DatabaseEntities db = new Lawer_DatabaseEntities();

        // GET: api/Family_Costing
        public IQueryable<Family_Costing> GetFamily_Costing()
        {
            return db.Family_Costing;
        }

        // GET: api/Family_Costing/5
        [ResponseType(typeof(Family_Costing))]
        public IHttpActionResult GetFamily_Costing(int id)
        {
            Family_Costing family_Costing = db.Family_Costing.Find(id);
            if (family_Costing == null)
            {
                return NotFound();
            }

            return Ok(family_Costing);
        }

        // PUT: api/Family_Costing/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutFamily_Costing(int id, Family_Costing family_Costing)
        {

            if (id != family_Costing.Family_CostID)
            {
                return BadRequest();
            }

            db.Entry(family_Costing).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Family_CostingExists(id))
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

        // POST: api/Family_Costing
        [ResponseType(typeof(Family_Costing))]
        public IHttpActionResult PostFamily_Costing(Family_Costing family_Costing)
        {

            db.Family_Costing.Add(family_Costing);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = family_Costing.Family_CostID }, family_Costing);
        }

        // DELETE: api/Family_Costing/5
        [ResponseType(typeof(Family_Costing))]
        public IHttpActionResult DeleteFamily_Costing(int id)
        {
            Family_Costing family_Costing = db.Family_Costing.Find(id);
            if (family_Costing == null)
            {
                return NotFound();
            }

            db.Family_Costing.Remove(family_Costing);
            db.SaveChanges();

            return Ok(family_Costing);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Family_CostingExists(int id)
        {
            return db.Family_Costing.Count(e => e.Family_CostID == id) > 0;
        }
    }
}