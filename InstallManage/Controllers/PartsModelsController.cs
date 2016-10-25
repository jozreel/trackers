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
using InstallManage.DAL;
using InstallManage.Models;

namespace InstallManage.Controllers
{
    public class PartsModelsController : ApiController
    {
        private trackerContext db = new trackerContext();

        // GET: api/PartsModels
        public IQueryable<PartsModel> GetParts()
        {
            return db.Parts;
        }

        // GET: api/PartsModels/5
        [ResponseType(typeof(PartsModel))]
        public IHttpActionResult GetPartsModel(int id)
        {
            PartsModel partsModel = db.Parts.Find(id);
            if (partsModel == null)
            {
                return NotFound();
            }

            return Ok(partsModel);
        }

        // PUT: api/PartsModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPartsModel(int id, PartsModel partsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != partsModel.PartsModelID)
            {
                return BadRequest();
            }

            db.Entry(partsModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PartsModelExists(id))
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

        // POST: api/PartsModels
        [ResponseType(typeof(PartsModel))]
        public IHttpActionResult PostPartsModel(PartsModel partsModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Parts.Add(partsModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = partsModel.PartsModelID }, partsModel);
        }

        // DELETE: api/PartsModels/5
        [ResponseType(typeof(PartsModel))]
        public IHttpActionResult DeletePartsModel(int id)
        {
            PartsModel partsModel = db.Parts.Find(id);
            if (partsModel == null)
            {
                return NotFound();
            }

            db.Parts.Remove(partsModel);
            db.SaveChanges();

            return Ok(partsModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PartsModelExists(int id)
        {
            return db.Parts.Count(e => e.PartsModelID == id) > 0;
        }
    }
}