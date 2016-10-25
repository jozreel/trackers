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
    public class ServiceModelsController : ApiController
    {
        
        private trackerContext db = new trackerContext();

        // GET: api/ServiceModels
        public IQueryable<ServiceModel> GetService()
        {
            return db.Service;
        }

        // GET: api/ServiceModels/5
        [ResponseType(typeof(ServiceModel))]
        public IHttpActionResult GetServiceModel(int id)
        {
            ServiceModel serviceModel = db.Service.Include(p=>p.partsReplaced).Where(s => s.ServiceModelID == id).First();
            if (serviceModel == null)
            {
                return NotFound();
            }

            return Ok(serviceModel);
        }



        // PUT: api/ServiceModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutServiceModel(int id, ServiceModel serviceModel)
        {

            var existingService = db.Service.Include(s => s.partsReplaced).Where(s => s.ServiceModelID == id).SingleOrDefault();

            var originalService = db.Entry(existingService);
             originalService.CurrentValues.SetValues(serviceModel);
            var existingParts = existingService.partsReplaced.ToList<PartsModel>();
            var updatedParts = serviceModel.partsReplaced.ToList<PartsModel>();
            var adderParts = updatedParts.Except(existingParts, p=>p.PartsModelID).ToList<PartsModel>();
            var deletedParts = existingParts.Except(updatedParts, p => p.PartsModelID).ToList<PartsModel>();
            var modParts = updatedParts.Except(adderParts, p => p.PartsModelID).ToList<PartsModel>();
           

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serviceModel.ServiceModelID)
            {
                return BadRequest();
            }
           
            adderParts.ForEach(prt => db.Entry(prt).State = EntityState.Added);
            deletedParts.ForEach(prt => db.Entry(prt).State = EntityState.Deleted);
            foreach(PartsModel pm in modParts)
            {
                var currPart = db.Parts.Find(pm.PartsModelID);
                if(currPart != null)
                {
                    var partEnntry = db.Entry(currPart);
                    partEnntry.CurrentValues.SetValues(pm);
                }
            }
          //  serviceModel.partsReplaced = null;
           // db.Entry(serviceModel).State = EntityState.Modified;
            

            try
            {
                db.SaveChanges();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceModelExists(id))
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

        // POST: api/ServiceModels
        [ResponseType(typeof(ServiceModel))]
        public IHttpActionResult PostServiceModel(ServiceModel serviceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Service.Add(serviceModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = serviceModel.ServiceModelID }, serviceModel);
        }

        // DELETE: api/ServiceModels/5
        [ResponseType(typeof(ServiceModel))]
        public IHttpActionResult DeleteServiceModel(int id)
        {
            ServiceModel serviceModel = db.Service.Find(id);
            if (serviceModel == null)
            {
                return NotFound();
            }

            db.Service.Remove(serviceModel);
            db.SaveChanges();

            return Ok(serviceModel);
        }
        [ResponseType(typeof(TrackerModel))]
        [HttpGet]
        public IHttpActionResult ServiceForTracker(int id)
        {
            var e2qr = db.Service.Where(s => s.TrackerModelID == id);
            var service = e2qr.ToList<ServiceModel>();
            return Ok(service);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ServiceModelExists(int id)
        {
            return db.Service.Count(e => e.ServiceModelID == id) > 0;
        }
    }
}