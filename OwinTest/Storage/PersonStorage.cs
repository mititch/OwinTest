using OwinTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OwinTest.Storage
{
    public class PersonStorage
    {

        private static readonly object _mutex = new object();

        private static readonly Lazy<PersonStorage> _instance = new Lazy<PersonStorage>(() => new PersonStorage());

        public static PersonStorage Instance
        {
            get
            {
                return _instance.Value;
            }
        }

        public IList<Person> Persons {get; set;}

        private PersonStorage()
        {
            this.Persons = new List<Person>{
                new Person {Name="First", Id = 1},
                new Person {Name="Second", Id = 2}
            };
        }

    }

}