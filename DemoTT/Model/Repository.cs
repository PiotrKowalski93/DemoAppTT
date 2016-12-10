using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DemoTT.Extensions;

namespace DemoTT.Model
{
    public class Repository
    {
        List<Client> _clients;
        List<Driver> _drivers;      

        public void CreateDrivers(int count)
        {
            _drivers = new List<Driver>();
            int driverId;

            for (int i = 0; i < count; i++)
            {
                driverId = i;
                driverId++;
                _drivers.Add(new Driver(driverId));
            }
        }
                
        public void UpdateDriver(Driver driver)
        {
            lock(_drivers)
            {
                Driver toUpdate = _drivers.Where(d => d.Id == driver.Id).SingleOrDefault();
                toUpdate.ClientId = driver.ClientId;
                toUpdate.Status = driver.Status;
            }
        }

        public ObservableCollection<Driver> GetDrivers()
        {
            lock(_drivers)
            {
                return _drivers.ToObservableCollection();
            }
        }

        public Driver GetDriver(int id)
        {
            return _drivers.Where(d => d.Id == id).SingleOrDefault();
        }

        public Client GetWaitingClient(Driver driver)
        {
            lock (_clients)
            {
                Client waitingClient;
                
                waitingClient = _clients.ChooseShortestDistanceExample(driver.Coordinates);
                if (waitingClient != null)
                {
                    waitingClient.IsWaiting = false;
                }

                return waitingClient;
            }            
        }

        public void PushClientToWait(Client client)
        {
            lock (_clients)
            {
                _clients.Where(c => c.Id == client.Id).First().IsWaiting = true;                
            }
        }

        public void CreateClients(int count)
        {
            _clients = new List<Client>();

            for (int i = 1; i <= count; i++)
            {
                _clients.Add(new Client(i));
            }
        }

        public ObservableCollection<Client> GetClients()
        {
            return _clients.ToObservableCollection();
        }

        public void SetClients(ObservableCollection<Client> clients)
        {
            _clients = clients.ToList();
        }
    }
}
