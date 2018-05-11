using System;
using System.Collections.Generic;
using System.Text;

namespace OwnedTypes.Models
{
    public class FullName
    {
        public virtual FirstName FirstName { get; private set; }
        public virtual LastName LastName { get; private set; }

        protected FullName() { }
        public FullName(FirstName firstName, LastName lastName)
        {
            FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            LastName = lastName ?? throw new ArgumentNullException(nameof(lastName));
        }
    }
}
