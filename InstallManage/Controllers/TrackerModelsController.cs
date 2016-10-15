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
    public class TrackerModelsController : ApiController
    {
        private trackerContext db = new trackerContext();

        // GET: api/TrackerModels
        public IQueryable<TrackerModel> GetTracker()
        {
            return db.Tracker;
        }

        // GET: api/TrackerModels/5
        [ResponseType(typeof(TrackerModel))]
        public IHttpActionResult GetTrackerModel(int id)
        {
            TrackerModel trackerModel = db.Tracker.Find(id);
            if (trackerModel == null)
            {
                return NotFound();
            }

            return Ok(trackerModel);
        }

        // PUT: api/TrackerModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTrackerModel(int id, TrackerModel trackerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != trackerModel.TrackerModelID)
            {
                return BadRequest();
            }

            db.Entry(trackerModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackerModelExists(id))
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

        // POST: api/TrackerModels
        [ResponseType(typeof(TrackerModel))]
        public IHttpActionResult PostTrackerModel(TrackerModel trackerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Tracker.Add(trackerModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = trackerModel.TrackerModelID }, trackerModel);
        }

        // DELETE: api/TrackerModels/5
        [ResponseType(typeof(TrackerModel))]
        public IHttpActionResult DeleteTrackerModel(int id)
        {
            TrackerModel trackerModel = db.Tracker.Find(id);
            if (trackerModel == null)
            {
                return NotFound();
            }

            db.Tracker.Remove(trackerModel);
            db.SaveChanges();

            return Ok(trackerModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrackerModelExists(int id)
        {
            return db.Tracker.Count(e => e.TrackerModelID == id) > 0;
        }

         [ResponseType(typeof(TrackerModel))]
         [HttpGet]
        public IHttpActionResult CustomerTrackers(int id)
        { 
       
             var e2qr = db.Tracker.Where(t=>t.CustomerModelID == id);
            var tracker = e2qr.ToList<TrackerModel>(); 
            return Ok(tracker);
        }
    }
}