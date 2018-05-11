using System;
using System.Collections.Generic;
using System.Text;

namespace OwnedTypes.Models
{
    public class FirstName
    {
        private string _value;

        protected FirstName() { }
        private FirstName(string value)
        {
            _value = value;
        }

        public static FirstName Create(string firstName)
        {
            return new FirstName(firstName);
        }
    }
}
