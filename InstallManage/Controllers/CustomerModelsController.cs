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
using System.Web.Http.Cors;

namespace InstallManage.Controllers
{
   
    public class CustomerModelsController : ApiController
    {
        private trackerContext db = new trackerContext();

        // GET: api/CustomerModels
        
        public IQueryable<CustomerModel> GetCustomerModels()
        {



            return db.CustomerModels.Include(t => t.Trackers);
        }

        // GET: api/CustomerModels/5
        [ResponseType(typeof(CustomerModel))]
        public IHttpActionResult GetCustomerModel(int id)
        {
            CustomerModel customerModel = db.CustomerModels.Find(id);
            if (customerModel == null)
            {
                return NotFound();
            } 
              
            return Ok(customerModel);   
        }
          
        public IQueryable<CustomerModel> GetByName(string name)
        {
            IQueryable<CustomerModel> customerModel = from m in db.CustomerModels where m.CustomerName.StartsWith(name) select m;
            

            return customerModel;
        }

        // PUT: api/CustomerModels/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerModel(int id, CustomerModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerModel.CustomerModelID)
            {
                return BadRequest();
            }

            db.Entry(customerModel).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerModelExists(id))
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

        // POST: api/CustomerModels
        [ResponseType(typeof(CustomerModel))]
        public IHttpActionResult PostCustomerModel(CustomerModel customerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerModels.Add(customerModel);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerModel.CustomerModelID }, customerModel);
        }

        // DELETE: api/CustomerModels/5
        [ResponseType(typeof(CustomerModel))]
        public IHttpActionResult DeleteCustomerModel(int id)
        {
            CustomerModel customerModel = db.CustomerModels.Find(id);
            if (customerModel == null)
            {
                return NotFound();
            }

            db.CustomerModels.Remove(customerModel);
            db.SaveChanges();

            return Ok(customerModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerModelExists(int id)
        {
            return db.CustomerModels.Count(e => e.CustomerModelID == id) > 0;
        }

    }
}