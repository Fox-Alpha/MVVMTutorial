// -----------------------------------------------------------------------
// <copyright file="PersonListViewModel.cs" company="Philipp Kühn">
// </copyright>
// -----------------------------------------------------------------------

namespace ViewModel
{
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.ComponentModel.Composition;
    using System.Linq;
    using System.Windows.Input;
    using Model;
    using ViewModelBase;

    /// <summary>
    /// A ViewModel for a list of Persons.
    /// </summary>
    [Export(typeof(IPersonListViewModel))]
    public class PersonListViewModel : ViewModel<IPersonList>, IPersonListViewModel
    {

        private ObservableCollection<IPersonViewModel> persons;

        public ObservableCollection<IPersonViewModel> Persons
        {
            get
            {
                return persons;
            }
            set
            {
                if (Persons != value)
                {
                    persons = value;
                    OnPropertyChanged("Persons");
                }
            }
        }

        private ICommand addPersonCommand;

        public ICommand AddPersonCommand
        {
            get
            {
                if (addPersonCommand == null)
                {
                    addPersonCommand = new RelayCommand(p => ExecuteAddPersonCommand());
                }
                return addPersonCommand;
            }
        }

        private void ExecuteAddPersonCommand()
        {
            Persons.Add(new PersonViewModel(Model.AddPerson()));
        }

        [ImportingConstructor]
        public PersonListViewModel(IPersonList model)
            : base(model)
        {
            persons = new ObservableCollection<IPersonViewModel>(model.Persons.Select(p => new PersonViewModel(p)));
            persons.CollectionChanged += Persons_CollectionChanged;
        }

        void Persons_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (PersonViewModel vm in e.NewItems)
                {
                    if (!Model.Persons.Contains(vm.Model))
                    {
                        Model.Persons.Add(vm.Model);
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (PersonViewModel vm in e.OldItems)
                {
                    if (!Model.Persons.Contains(vm.Model))
                    {
                        Model.Persons.Remove(vm.Model);
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Reset)
            {
                Model.Persons.Clear();
            }
        }

    }
}
