using GalaSoft.MvvmLight;
using DemoTT.Model;
using System.Collections.ObjectModel;
using System.Collections.Generic;
using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using System.Threading;
using System;
using System.Diagnostics;
using DemoTT.Enums;

namespace DemoTT.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        // TODO: Bind to controls in UI
        private int _driversCount = 3;
        private int _clientsCount = 5;
        
        private Repository CentralRepository;      
        private List<Timer> timers;
        private Random random;

        public ICommand StartCommand { get; set; }

        public ObservableCollection<Client> Clients
        {
            get
            {
                return CentralRepository.GetClients();
            }
        }

        public ObservableCollection<Driver> Drivers
        {
            get
            {
                return CentralRepository.GetDrivers();
            }
        }

        public MainViewModel()
        {
            CentralRepository = new Repository();
            CentralRepository.CreateClients(_clientsCount);
            CentralRepository.CreateDrivers(_driversCount);

            random = new Random();
            
            StartCommand = new RelayCommand(() => StartWork());
        }

        private void DriverWork(object state)
        {
            Driver driver = (Driver)state;

            if(driver != null)
            {                
                int rand;

                while (true)
                {
                    Client client = CentralRepository.GetWaitingClient(driver);
                    base.RaisePropertyChanged("Clients");

                    if (client == null) continue;
                                      
                    rand = random.Next(0, 100);

                    if (rand <= 30)
                    {
                        Debug.WriteLine("Driver: {0} refused. {1}", driver.Id, rand);

                        CentralRepository.PushClientToWait(client);
                        base.RaisePropertyChanged("Clients");                             
                    }
                    else
                    {
                        Debug.WriteLine("Starting Driver: {0}", driver.Id);

                        driver.ClientId = client.Id;
                        driver.Status = DriverStatuses.DuringWork;
                        CentralRepository.UpdateDriver(driver);
                        base.RaisePropertyChanged("Drivers");

                        client.StartService();

                        CentralRepository.PushClientToWait(client);
                        base.RaisePropertyChanged("Clients");

                        driver.Status = DriverStatuses.DrivingBack;
                        CentralRepository.UpdateDriver(driver);
                        base.RaisePropertyChanged("Drivers");

                        Debug.WriteLine("Driver: {0} drive back", driver.Id);
                        Thread.Sleep(10000);

                        driver.ClientId = 0;
                        driver.Status = DriverStatuses.Waiting;
                        CentralRepository.UpdateDriver(driver);
                        base.RaisePropertyChanged("Drivers");

                        Debug.WriteLine("Releasing Driver: {0}", driver.Id);    
                    }
                }                
            }
        }

        private void StartWork()
        {
            timers = new List<Timer>();

            for (int i = 1; i <= _driversCount; i++)
            {
                Timer timer = new Timer(DriverWork, CentralRepository.GetDriver(i), 0, Timeout.Infinite);
                timers.Add(timer);
            }
        }
    }
}