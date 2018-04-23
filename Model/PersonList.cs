// -----------------------------------------------------------------------
// <copyright file="PersonList.cs" company="Philipp Kühn">
// </copyright>
// -----------------------------------------------------------------------

namespace Model
{
    using System.Collections.Generic;
    using System.ComponentModel.Composition;

    /// <summary>
    /// A list of persons to work with.
    /// </summary>
    [Export(typeof(IPersonList))]
    public class PersonList : IPersonList
    {
        public IList<IPerson> Persons { get; private set; }

        private PersonList()
        {
            Persons = new List<IPerson>()
            {
                new Person(){Name = "John Doe", 
                    Street = "Onestreet", 
                    PostalCode = 12345, 
                    City = "Onecity"},
                new Person(){Name = "Jane Doe", 
                    Street = "Onestreet", 
                    PostalCode = 12345, 
                    City = "Onecity"},
                new Person(){Name = "Foo Bar", 
                    Street = "Twostreet", 
                    PostalCode = 54321, 
                    City = "Twocity"}
            };
        }

        public IPerson AddPerson()
        {
            var person = new Person(){ Name = "New Person Entry" };
            Persons.Add(person);
            return person;
        }

    }
}
