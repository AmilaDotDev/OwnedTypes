using System;
using System.Collections.Generic;
using System.Text;

namespace OwnedTypes.Models
{
    public class Person
    {
        public int PersonId { get; set; }
        public virtual FullName Name { get; set; }
        public virtual Address Address { get; set; }
        protected Person() { }
        public Person(FullName name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
