using System;
using System.Collections.Generic;
using System.Text;

namespace OwnedTypes.Models
{
    public class Applicant
    {
        public int ApplicantId { get; set; }
        public FullName Name { get; set; }

        protected Applicant() { }
        public Applicant(FullName name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }
    }
}
