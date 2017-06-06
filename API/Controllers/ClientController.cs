using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace API.Controllers
{
    public class ClientController : ApiController
    {

        public ModelContainer context = new ModelContainer();

        public IHttpActionResult GetClient(int id)
        {
            var client = context.Clients.Find(id);

            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }


        public IHttpActionResult GetAllClient()
        {
            var clients = from Client in context.Clients
                          select Client;

            if (clients == null)
            {
                return NotFound();
            }
            return Ok(clients);
        }

        [HttpPost]
        public void PostClient([FromBody]Client client)
        {
            context.Clients.Add(client);
        }
    }
}