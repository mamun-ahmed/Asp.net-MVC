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
    public class Other_InformationController : ApiController
    {
        private Lawer_DatabaseEntities db = new Lawer_DatabaseEntities();

        // GET: api/Other_Information
        public IQueryable<Other_Information> GetOther_Information()
        {
            return db.Other_Information;
        }

        // GET: api/Other_Information/5
        [ResponseType(typeof(Other_Information))]
        public IHttpActionResult GetOther_Information(int id)
        {
            Other_Information other_Information = db.Other_Information.Find(id);
            if (other_Information == null)
            {
                return NotFound();
            }

            return Ok(other_Information);
        }

        // PUT: api/Other_Information/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutOther_Information(int id, Other_Information other_Information)
        {

            if (id != other_Information.Information_ID)
            {
                return BadRequest();
            }

            db.Entry(other_Information).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Other_InformationExists(id))
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

        // POST: api/Other_Information
        [ResponseType(typeof(Other_Information))]
        public IHttpActionResult PostOther_Information(Other_Information other_Information)
        {

            db.Other_Information.Add(other_Information);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = other_Information.Information_ID }, other_Information);
        }

        // DELETE: api/Other_Information/5
        [ResponseType(typeof(Other_Information))]
        public IHttpActionResult DeleteOther_Information(int id)
        {
            Other_Information other_Information = db.Other_Information.Find(id);
            if (other_Information == null)
            {
                return NotFound();
            }

            db.Other_Information.Remove(other_Information);
            db.SaveChanges();

            return Ok(other_Information);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Other_InformationExists(int id)
        {
            return db.Other_Information.Count(e => e.Information_ID == id) > 0;
        }
    }
}