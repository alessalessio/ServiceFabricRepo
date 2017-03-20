using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebStateless3.Controllers
{
    public class ValuesController : ApiController
    {
        public IEnumerable<string> Get()
        {
            return new string[] {"value1", "value2"};
        }

        public string Get(int id)
        {
            return "value";
        }

        public void Post([FromBody] string value)
        {
            
        }

        public void Put([FromBody] string value)
        {

        }

        public void Delete(int id)
        {

        }

    }
}
