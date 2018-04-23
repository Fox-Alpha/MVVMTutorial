namespace ViewModel
{
    public interface IPersonListViewModel
    {
        System.Windows.Input.ICommand AddPersonCommand { get; }
        System.Collections.ObjectModel.ObservableCollection<IPersonViewModel> Persons { get; set; }
    }
}
