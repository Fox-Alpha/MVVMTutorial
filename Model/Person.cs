// -----------------------------------------------------------------------
// <copyright file="Person.cs" company="Philipp Kühn">
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace Model
{

    /// <summary>
    /// Respresents a simple person.
    /// </summary>
    public class Person : IPerson
    {
        public string strGuid { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public int PostalCode { get; set; }
        public string City { get; set; }

        public Person()
        {
            strGuid = Guid.NewGuid().ToString();
        }

        public override int GetHashCode()
        {
            return strGuid;
            //return PostalCode;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            var other = obj as Person;
            if (other == null)
                return false;

            return Equals(other);
        }

        public bool Equals(Person other)
        {
            if (other == null || GetHashCode() != other.GetHashCode())
                return false;

            if (Name != other.Name || Street != other.Street ||
                PostalCode != other.PostalCode || City != other.City)
                return false;

            return true;
        }

        public override string ToString()
        {
            return Name + " " + Street + " " + PostalCode + " " + City;
        }
    }
}
