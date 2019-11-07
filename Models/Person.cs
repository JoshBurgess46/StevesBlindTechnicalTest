using System;
using System.Collections.Generic;

namespace TechnicalTestStevesBlind.Models
{
    public partial class Person
    {
        public short Id { get; set; }
        public string Name { get; set; }
        public DateTime Dob { get; set; }
        public string Gender { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
    }
}
