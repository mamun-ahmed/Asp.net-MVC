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
    public class Individual_ClientController : ApiController
    {
        private Lawer_DatabaseEntities db = new Lawer_DatabaseEntities();

        // GET: api/Individual_Client
        public IQueryable<Individual_Client> GetIndividual_Client()
        {
            return db.Individual_Client;
        }

        // GET: api/Individual_Client/5
        [ResponseType(typeof(Individual_Client))]
        public IHttpActionResult GetIndividual_Client(int id)
        {
            Individual_Client individual_Client = db.Individual_Client.Find(id);
            if (individual_Client == null)
            {
                return NotFound();
            }

            return Ok(individual_Client);
        }

        // PUT: api/Individual_Client/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutIndividual_Client(int id, Individual_Client individual_Client)
        {

            if (id != individual_Client.Client_ID)
            {
                return BadRequest();
            }

            db.Entry(individual_Client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Individual_ClientExists(id))
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

        // POST: api/Individual_Client
        [ResponseType(typeof(Individual_Client))]
        public IHttpActionResult PostIndividual_Client(Individual_Client individual_Client)
        {

            db.Individual_Client.Add(individual_Client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = individual_Client.Client_ID }, individual_Client);
        }

        // DELETE: api/Individual_Client/5
        [ResponseType(typeof(Individual_Client))]
        public IHttpActionResult DeleteIndividual_Client(int id)
        {
            Individual_Client individual_Client = db.Individual_Client.Find(id);
            if (individual_Client == null)
            {
                return NotFound();
            }

            db.Individual_Client.Remove(individual_Client);
            db.SaveChanges();

            return Ok(individual_Client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Individual_ClientExists(int id)
        {
            return db.Individual_Client.Count(e => e.Client_ID == id) > 0;
        }
    }
}