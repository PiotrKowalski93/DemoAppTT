using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoTT.Extensions;

namespace DemoTT.Model
{
    public class Repository
    {
        List<Client> _clients;
        //Queue<Client> _clients;

        public Client GetWaitingClient()
        {
            lock (_clients)
            {
                Client waitingClient;

                waitingClient = _clients.Where(c => c.IsWaiting == true).FirstOrDefault();
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
