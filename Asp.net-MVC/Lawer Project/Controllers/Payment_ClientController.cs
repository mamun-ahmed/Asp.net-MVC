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
    public class Payment_ClientController : ApiController
    {
        private Lawer_DatabaseEntities db = new Lawer_DatabaseEntities();

        // GET: api/Payment_Client
        public IQueryable<Payment_Client> GetPayment_Client()
        {
            return db.Payment_Client;
        }

        // GET: api/Payment_Client/5
        [ResponseType(typeof(Payment_Client))]
        public IHttpActionResult GetPayment_Client(int id)
        {
            Payment_Client payment_Client = db.Payment_Client.Find(id);
            if (payment_Client == null)
            {
                return NotFound();
            }

            return Ok(payment_Client);
        }

        // PUT: api/Payment_Client/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPayment_Client(int id, Payment_Client payment_Client)
        {

            if (id != payment_Client.Payment_ID)
            {
                return BadRequest();
            }

            db.Entry(payment_Client).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Payment_ClientExists(id))
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

        // POST: api/Payment_Client
        [ResponseType(typeof(Payment_Client))]
        public IHttpActionResult PostPayment_Client(Payment_Client payment_Client)
        {

            db.Payment_Client.Add(payment_Client);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = payment_Client.Payment_ID }, payment_Client);
        }

        // DELETE: api/Payment_Client/5
        [ResponseType(typeof(Payment_Client))]
        public IHttpActionResult DeletePayment_Client(int id)
        {
            Payment_Client payment_Client = db.Payment_Client.Find(id);
            if (payment_Client == null)
            {
                return NotFound();
            }

            db.Payment_Client.Remove(payment_Client);
            db.SaveChanges();

            return Ok(payment_Client);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Payment_ClientExists(int id)
        {
            return db.Payment_Client.Count(e => e.Payment_ID == id) > 0;
        }
    }
}