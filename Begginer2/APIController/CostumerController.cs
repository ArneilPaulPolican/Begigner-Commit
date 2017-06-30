using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Begginer2.Entites;
using System.Diagnostics;

namespace Begginer2.APIController
{

    public class CostumerController : ApiController
    {
        private Data.BeginnerDBDataContext db = new Data.BeginnerDBDataContext();
        [HttpGet,Route("api/costumer/list")]
        public List<Costmuer> getCostumer()
        {
            var costumerList = from d in db.MstCostumers
                               select new Entites.Costmuer
                               {
                                   ID = d.ID,
                                   Fname = d.Fname,
                                   Mname = d.Mname,
                                   Lname = d.Lname,
                                   Address = d.Addres,
                                   ContactNumber = d.ContactNumber,
                                   CreditLimit = d.CreditLimit
                               };
            return costumerList.ToList();
        }

        //get Costumer by ID
        [HttpGet,Route("api/costumer/list/{id}")]
        public List<Costmuer> listofCostumer(String id)
        {
            var costumerList = from d in db.MstCostumers
                               where d.ID == Convert.ToInt32(id)
                               select new Entites.Costmuer
                               {
                                   ID = d.ID,
                                   Fname = d.Fname,
                                   Mname = d.Mname,
                                   Lname = d.Lname,
                                   Address = d.Addres,
                                   ContactNumber = d.ContactNumber,
                                   CreditLimit = d.CreditLimit
                               };
            return costumerList.ToList();
        }

        //
        // UPDATE
        //
        [HttpPut]
        [ Route("api/costumer/update/{id}")]
        public HttpResponseMessage update(String id, Entites.Costmuer item)
        {
            try
            {
                var ItemId = Convert.ToInt32(id);
                var costID = from d in db.MstCostumers where d.ID == ItemId select d;


                if (costID.Any())
                {
                    var updateCost = costID.FirstOrDefault();

                    updateCost.Fname = item.Fname;
                    updateCost.Mname = item.Mname;
                    updateCost.Lname = item.Lname;
                    updateCost.Addres = item.Address;
                    updateCost.ContactNumber = item.ContactNumber;
                    updateCost.CreditLimit = item.CreditLimit;

                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }


        //Add Costumer
        [Route("api/costumer/add")]
        public HttpResponseMessage postCostumer(Entites.Costmuer addCostumer)
        {
            try
            {
                //var LastId= from d in db.MstCostumers.OrderByDescending
                Data.MstCostumer newCostumer = new Data.MstCostumer();
                newCostumer.Fname = addCostumer.Fname != null ? addCostumer.Fname : "NA";
                newCostumer.Mname = addCostumer.Mname;
                newCostumer.Lname = addCostumer.Lname != null ? addCostumer.Lname : "NA";
                newCostumer.Addres = addCostumer.Address != null ? addCostumer.Address : "NA";
                newCostumer.ContactNumber = addCostumer.ContactNumber != null ? addCostumer.ContactNumber : "NA";
                newCostumer.CreditLimit = addCostumer.CreditLimit;

                

                db.MstCostumers.InsertOnSubmit(newCostumer);
                db.SubmitChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        //Delete Costumer
        [HttpDelete,Route("api/costumer/delete/{id}")]
        public HttpResponseMessage Delete(String id)
        {
            try
            {
                var costumers = from d in db.MstCostumers where d.ID == Convert.ToInt32(id) select d;

                if (costumers.Any())
                {
                    db.MstCostumers.DeleteOnSubmit(costumers.First());
                    db.SubmitChanges();

                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
