using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using ViewModel;

namespace StartApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        [Import]
        private IPersonListViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            MefInitialization();
            SetupBindings();
        }

        private void SetupBindings()
        {
            personListView.DataContext = viewModel;
        }

        private void MefInitialization()
        {
            var catalog = new AggregateCatalog();
            catalog.Catalogs.Add(new DirectoryCatalog("."));

            var container = new CompositionContainer(catalog);
            container.SatisfyImportsOnce(this);
        }
    }
}
