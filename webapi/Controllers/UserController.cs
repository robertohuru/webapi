using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using webapi.Models;
using Npgsql;
using webapi.Utils;
using System;

namespace webapi.Controllers
{
    public class UserController : ApiController
    {        
        private User[] users = DatabaseConnectionUtil.getUsers();

        // GET: api/User
        [ResponseType(typeof(IEnumerable<User>))]
        public IEnumerable<User> Get()
        {
            return users;
        }

        // GET: api/User/1
        public IHttpActionResult Get(int id)
        {
            var product = users.FirstOrDefault((p) => p.id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }        

        // POST: api/User
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/User/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/User/5
        public void Delete(int id)
        {
        }
    }
}
