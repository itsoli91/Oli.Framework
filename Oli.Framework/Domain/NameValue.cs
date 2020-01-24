using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Oli.Framework.Domain
{
    [DataContract]
    public class NameValue : ValueObject
    {
        public NameValue()
        { }

        public NameValue(string firstName, string lastName)
        {
            FirstName = string.IsNullOrEmpty(firstName) ? "" : firstName.Trim();
            LastName = string.IsNullOrEmpty(lastName) ? "" : lastName.Trim();
        }
        [DataMember]
        public string FirstName { get; set; }
        [DataMember]
        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return FirstName;
            yield return LastName;
        }
    }
}