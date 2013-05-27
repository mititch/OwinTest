using OwinTest.Models;
using OwinTest.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OwinTest.Controllers
{
    //ApiContriller implementation with CRUD
    public class PersonController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Person> Get()
        {
            return PersonStorage.Instance.Persons;
        }

        // GET api/<controller>/5
        public Person Get(int id)
        {
            return PersonStorage.Instance.Persons.FirstOrDefault( x=> x.Id == id);
        }

        // POST api/<controller>
        public void Post([FromBody]Person value)
        {
            PersonStorage.Instance.Persons.Add(value);
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]Person value)
        {
            //not implemented yet
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            //not implemented yet
        }
    }
}
