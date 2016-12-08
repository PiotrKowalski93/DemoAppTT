using GalaSoft.MvvmLight;
using DemoTT.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using DemoTT.Services;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using DemoTT.Commands;
using System.Windows.Input;
using System.Threading;
using System.Windows.Threading;
using System;
using System.ComponentModel;
using System.Diagnostics;

namespace DemoTT.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        // TODO: Bind to control in UI
        private int _driversCount = 3;

        public ICommand StartCommand { get; set; }

        private Repository CentralRepository;
        private ObservableCollection<Driver> _drivers;
        private IDataGeneratorService _dataGeneratorService;

        private List<BackgroundWorker> _workers;

        #region Properties
        public ObservableCollection<Client> Clients
        {
            get
            {
                return CentralRepository.GetClients();
            }
            set
            {
                CentralRepository.SetClients(value);
                base.RaisePropertyChanged("Clients");
            }
        }

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
            _dataGeneratorService = dataGeneratorService;

            CentralRepository = new Repository();
            CentralRepository.CreateClients(5);

            Drivers = new ObservableCollection<Driver>();

            for (int i = 0; i < _driversCount; i++)
            {
                int id = i;
                id++;

                Drivers.Add(new Driver(CentralRepository, id));
            }
            
            _workers = new List<BackgroundWorker>();

            for (int i = 0; i < _driversCount; i++)
            {
                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += MainViewModel_DoWork;

                _workers.Add(worker);
            }

            StartCommand = new RelayCommand(() => StartWork());
        }

        private void MainViewModel_DoWork(object sender, DoWorkEventArgs e)
        {
            Driver driver = (Driver)e.Argument;

            if(driver != null)
            {
                driver.StartWork();
                Debug.WriteLine("Started");
            }
        }

        private void StartWork()
        {
            for (int i = 0; i < _driversCount; i++)
            {
                _workers[i].RunWorkerAsync(_drivers[i]);
            }
        }

    }
}