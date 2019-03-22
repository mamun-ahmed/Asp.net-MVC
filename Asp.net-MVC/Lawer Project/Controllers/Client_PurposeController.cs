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
    public class Client_PurposeController : ApiController
    {
        private Lawer_DatabaseEntities db = new Lawer_DatabaseEntities();

        // GET: api/Client_Purpose
        public IQueryable<Client_Purpose> GetClient_Purpose()
        {
            return db.Client_Purpose;
        }

        // GET: api/Client_Purpose/5
        [ResponseType(typeof(Client_Purpose))]
        public IHttpActionResult GetClient_Purpose(int id)
        {
            Client_Purpose client_Purpose = db.Client_Purpose.Find(id);
            if (client_Purpose == null)
            {
                return NotFound();
            }

            return Ok(client_Purpose);
        }

        // PUT: api/Client_Purpose/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutClient_Purpose(int id, Client_Purpose client_Purpose)
        {
            
            if (id != client_Purpose.Purpose_ID)
            {
                return BadRequest();
            }

            db.Entry(client_Purpose).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Client_PurposeExists(id))
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

        // POST: api/Client_Purpose
        [ResponseType(typeof(Client_Purpose))]
        public IHttpActionResult PostClient_Purpose(Client_Purpose client_Purpose)
        {

            db.Client_Purpose.Add(client_Purpose);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = client_Purpose.Purpose_ID }, client_Purpose);
        }

        // DELETE: api/Client_Purpose/5
        [ResponseType(typeof(Client_Purpose))]
        public IHttpActionResult DeleteClient_Purpose(int id)
        {
            Client_Purpose client_Purpose = db.Client_Purpose.Find(id);
            if (client_Purpose == null)
            {
                return NotFound();
            }

            db.Client_Purpose.Remove(client_Purpose);
            db.SaveChanges();

            return Ok(client_Purpose);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Client_PurposeExists(int id)
        {
            return db.Client_Purpose.Count(e => e.Purpose_ID == id) > 0;
        }
    }
}