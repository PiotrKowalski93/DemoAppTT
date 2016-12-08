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
using DemoTT.Enums;

namespace DemoTT.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        // TODO: Bind to control in UI
        private int _driversCount = 4;

        public ICommand StartCommand { get; set; }

        private Repository CentralRepository;
        private ObservableCollection<Driver> _drivers;
        private IDataGeneratorService _dataGeneratorService;

        private List<BackgroundWorker> _workers;
        private List<Timer> timers;

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
            
            //_workers = new List<BackgroundWorker>();        

            //for (int i = 0; i < _driversCount; i++)
            //{
            //    BackgroundWorker worker = new BackgroundWorker();
            //    worker.DoWork += MainViewModel_DoWork;

            //    _workers.Add(worker);
            //}
            
            StartCommand = new RelayCommand(() => StartWork());
        }

        private void DriverWork(object state)
        {
            Driver driver = (Driver)state;

            if(driver != null)
            {
                //driver.StartWork
                
                while (true)
                {
                    Client client = CentralRepository.GetWaitingClient();
                    base.RaisePropertyChanged("Clients");

                    if (client == null) continue;

                    Random random = new Random();
                    int rand = random.Next(1, 4);

                    if (rand == 2)
                    {
                        CentralRepository.PushClientToWait(client);
                        base.RaisePropertyChanged("Clients");                             
                    }
                    else
                    {
                        Debug.WriteLine("Starting Driver: {0}", driver.Id);

                        driver.ClientId = client.Id;
                        driver.Status = DriverStatuses.DuringWork;

                        base.RaisePropertyChanged("Drivers");

                        client.StartService();

                        CentralRepository.PushClientToWait(client);
                        base.RaisePropertyChanged("Clients");

                        driver.Status = DriverStatuses.Waiting;
                        base.RaisePropertyChanged("Drivers");

                        Debug.WriteLine("Releasing Driver: {0}", driver.Id);
                    }

                    Thread.Sleep(5000);
                }

                Debug.WriteLine("Started");
            }
        }

        private void StartWork()
        {
            //for (int i = 0; i < _driversCount; i++)
            //{
            //    _workers[i].RunWorkerAsync(_drivers[i]);
            //}

            timers = new List<Timer>();

            for (int i = 0; i < _driversCount; i++)
            {
                Timer timer = new Timer(DriverWork, _drivers[i], 5000, Timeout.Infinite);
                timers.Add(timer);
            }
        }
    }
}