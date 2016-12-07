using GalaSoft.MvvmLight;
using DemoTT.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DemoTT.Services;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using DemoTT.Commands;
using System.Windows.Input;

namespace DemoTT.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand StartCommand;

        private Repository CentralRepository;
        private ObservableCollection<Driver> _drivers;

        private IDataGeneratorService _dataGeneratorService;

        #region Properties
        //public ObservableCollection<Client> Clients
        //{
        //    get
        //    {
        //        return CentralRepository.GetClients();
        //    }
        //    set
        //    {
        //        _clients = value;
        //        base.RaisePropertyChanged("Clients");
        //    }
        //}

        public ObservableCollection<Driver> Drivers
        {
            get
            {
                return _drivers;
            }
            set
            {
                _drivers = value;
                base.RaisePropertyChanged("Drivers");
            }
        }
        #endregion

        public MainViewModel(IDataGeneratorService dataGeneratorService)
        {
            CentralRepository = new Repository();

            _drivers = new ObservableCollection<Driver>();

            _dataGeneratorService = dataGeneratorService;

            StartCommand = new AsyncDelegateCommand(
              async _ =>
              {
                  await InitializeCollections();
              });
        }

        public async Task InitializeCollections()
        {
            //Clients = await _dataGeneratorService.GnerateClients(7);
        }

    }
}