using System;
using System.Collections.Generic;
using System.Text;

namespace Test.Domain.Entities
{
    public class Candidate : BaseEntity
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Identification { get; set; }
        public string HouseAspire { get; set; }
    }
}
