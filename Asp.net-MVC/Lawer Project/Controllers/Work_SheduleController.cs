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
    public class Work_SheduleController : ApiController
    {
        private Lawer_DatabaseEntities db = new Lawer_DatabaseEntities();

        // GET: api/Work_Shedule
        public IQueryable<Work_Shedule> GetWork_Shedule()
        {
            return db.Work_Shedule;
        }

        // GET: api/Work_Shedule/5
        [ResponseType(typeof(Work_Shedule))]
        public IHttpActionResult GetWork_Shedule(int id)
        {
            Work_Shedule work_Shedule = db.Work_Shedule.Find(id);
            if (work_Shedule == null)
            {
                return NotFound();
            }

            return Ok(work_Shedule);
        }

        // PUT: api/Work_Shedule/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWork_Shedule(int id, Work_Shedule work_Shedule)
        {

            if (id != work_Shedule.Shedule_ID)
            {
                return BadRequest();
            }

            db.Entry(work_Shedule).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Work_SheduleExists(id))
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

        // POST: api/Work_Shedule
        [ResponseType(typeof(Work_Shedule))]
        public IHttpActionResult PostWork_Shedule(Work_Shedule work_Shedule)
        {

            db.Work_Shedule.Add(work_Shedule);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = work_Shedule.Shedule_ID }, work_Shedule);
        }

        // DELETE: api/Work_Shedule/5
        [ResponseType(typeof(Work_Shedule))]
        public IHttpActionResult DeleteWork_Shedule(int id)
        {
            Work_Shedule work_Shedule = db.Work_Shedule.Find(id);
            if (work_Shedule == null)
            {
                return NotFound();
            }

            db.Work_Shedule.Remove(work_Shedule);
            db.SaveChanges();

            return Ok(work_Shedule);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Work_SheduleExists(int id)
        {
            return db.Work_Shedule.Count(e => e.Shedule_ID == id) > 0;
        }
    }
}