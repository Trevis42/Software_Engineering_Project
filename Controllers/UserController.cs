﻿using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using Contact_Billing_XamarinService.DataObjects;
using Contact_Billing_XamarinService.Models;

namespace Contact_Billing_XamarinService.Controllers
{
    [Authorize]
    public class UserController : TableController<User>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            Contact_Billing_XamarinContext context = new Contact_Billing_XamarinContext();
            DomainManager = new EntityDomainManager<User>(context, Request);
        }

        // GET tables/User
        public IQueryable<User> GetAllUser()
        {
            return Query(); 
        }

        // GET tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<User> GetUser(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<User> PatchUser(string id, Delta<User> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/User
        public async Task<IHttpActionResult> PostUser(User item)
        {
            User current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/User/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteUser(string id)
        {
             return DeleteAsync(id);
        }
    }
}
