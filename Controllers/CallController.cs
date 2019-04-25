using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;
using Contact_Billing_XamarinService.DataObjects;
using Contact_Billing_XamarinService.Models;

namespace Contact_Billing_XamarinService.Controllers
{
    public class CallController : TableController<Call>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            Contact_Billing_XamarinContext context = new Contact_Billing_XamarinContext();
            DomainManager = new EntityDomainManager<Call>(context, Request);
        }

        // GET tables/Call
        public IQueryable<Call> GetAllCall()
        {
            return Query(); 
        }

        // GET tables/Call/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<Call> GetCall(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/Call/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<Call> PatchCall(string id, Delta<Call> patch)
        {
             return UpdateAsync(id, patch);
        }

        // POST tables/Call
        public async Task<IHttpActionResult> PostCall(Call item)
        {
            Call current = await InsertAsync(item);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/Call/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteCall(string id)
        {
             return DeleteAsync(id);
        }
    }
}
