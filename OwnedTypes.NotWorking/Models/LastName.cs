using System;
using System.Collections.Generic;
using System.Text;

namespace OwnedTypes.Models
{
    public class LastName
    {
        private string _value;

        protected LastName() { }
        private LastName(string value)
        {
            _value = value;
        }

        public static LastName Create(string lastName)
        {
            return new LastName(lastName);
        }
    }
}
