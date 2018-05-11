using System;
using System.Collections.Generic;
using System.Text;

namespace OwnedTypes.Models
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Line1 { get; set; }
        public string Line2 { get; set; }
        public int PersonId { get; set; }
    }
}
