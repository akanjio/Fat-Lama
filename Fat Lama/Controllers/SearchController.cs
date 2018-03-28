using Fat_Lama.Managers;
using Fat_Lama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Fat_Lama.Controllers
{
    public class SearchController : ApiController
    {
        // GET: api/Search
        public IEnumerable<SearchResult> Get(string searchTerm, string lat, string lng)
        {
            //check input values for illegal chars and to prevent SQL injection

            
            //call database layer to perform search
            return new SearchManager().DoSearch(searchTerm, Convert.ToDouble(lat), Convert.ToDouble(lng));

        }

        // GET: api/Search/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Search
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Search/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Search/5
        public void Delete(int id)
        {
        }
    }
}
