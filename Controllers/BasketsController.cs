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
using SepetApi.Models;

namespace SepetApi.Controllers
{
    public class BasketsController : ApiController
    {
        private SepetDb db = new SepetDb();

        // GET: api/Baskets
        public IQueryable<Basket> GetBaskets()
        {
            return db.Baskets;
        }

        // GET: api/Baskets/5
        [ResponseType(typeof(Basket))]
        public IHttpActionResult GetBasket(int id)
        {
            Basket basket = db.Baskets.Find(id);
            if (basket == null)
            {
                return NotFound();
            }

            return Ok(basket);
        }

        // PUT: api/Baskets/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBasket(int id, Basket basket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != basket.Id)
            {
                return BadRequest();
            }

            db.Entry(basket).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BasketExists(id))
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

        // POST: api/Baskets
        [ResponseType(typeof(Basket))]
        public IHttpActionResult PostBasket(Basket basket)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Baskets.Add(basket);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = basket.Id }, basket);
        }

        // DELETE: api/Baskets/5
        [ResponseType(typeof(Basket))]
        public IHttpActionResult DeleteBasket(int id)
        {
            Basket basket = db.Baskets.Find(id);
            if (basket == null)
            {
                return NotFound();
            }

            db.Baskets.Remove(basket);
            db.SaveChanges();

            return Ok(basket);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BasketExists(int id)
        {
            return db.Baskets.Count(e => e.Id == id) > 0;
        }
    }
}