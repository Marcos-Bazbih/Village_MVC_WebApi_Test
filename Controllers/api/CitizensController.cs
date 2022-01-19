using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Village_MVC_WebApi_Test.Models;

namespace Village_MVC_WebApi_Test.Controllers.api
{
    public class CitizensController : ApiController
    {
        public VillageDbContext db = new VillageDbContext();

        // GET: api/Citizens
        public IHttpActionResult Get()
        {
            return Ok(db.Citizens);
        }

        // GET: api/Citizens/5
        [ResponseType(typeof(Citizen))]
        public async Task<IHttpActionResult> GetCitizen(int id)
        {
            Citizen citizen = await db.Citizens.FindAsync(id);
            if (citizen == null)
            {
                return NotFound();
            }

            return Ok(citizen);
        }

        // PUT: api/Citizens/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCitizen(int id, Citizen citizen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != citizen.Id)
            {
                return BadRequest();
            }

            db.Entry(citizen).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CitizenExists(id))
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

        // POST: api/Citizens
        [ResponseType(typeof(Citizen))]
        public async Task<IHttpActionResult> PostCitizen(Citizen citizen)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Citizens.Add(citizen);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = citizen.Id }, citizen);
        }

        // DELETE: api/Citizens/5
        [ResponseType(typeof(Citizen))]
        public async Task<IHttpActionResult> DeleteCitizen(int id)
        {
            Citizen citizen = await db.Citizens.FindAsync(id);
            if (citizen == null)
            {
                return NotFound();
            }

            db.Citizens.Remove(citizen);
            await db.SaveChangesAsync();

            return Ok(citizen);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CitizenExists(int id)
        {
            return db.Citizens.Count(e => e.Id == id) > 0;
        }
    }
}