// -----------------------------------------------------------------------
// <copyright file="PersonViewModel.cs" company="Philipp Kühn">
// </copyright>
// -----------------------------------------------------------------------

namespace ViewModel
{
    using Model;
    using ViewModelBase;

    /// <summary>
    /// A ViewModel for a Person.
    /// </summary>
    public class PersonViewModel : ViewModel<IPerson>, IPersonViewModel
    {
        public string Name
        {
            get
            {
                return Model.Name;
            }
            set
            {
                if (Name != value)
                {
                    Model.Name = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        public string Street
        {
            get
            {
                return Model.Street;
            }
            set
            {
                if (Street != value)
                {
                    Model.Street = value;
                    this.OnPropertyChanged("Street");
                }
            }
        }

        public int PostalCode
        {
            get
            {
                return Model.PostalCode;
            }
            set
            {
                if (PostalCode != value)
                {
                    Model.PostalCode = value;
                    this.OnPropertyChanged("PostalCode");
                }
            }
        }

        public string City
        {
            get
            {
                return Model.City;
            }
            set
            {
                if (City != value)
                {
                    Model.City = value;
                    this.OnPropertyChanged("City");
                }
            }
        }

        public PersonViewModel(IPerson model)
            : base(model)
        {
        }
    }
}
