using System;
using System.Collections.Generic;
using System.Text;

namespace OwnedTypes.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public FullName Name { get; set; }
        public Address Address { get; set; }
        protected Person() { }
        public Person(FullName name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
