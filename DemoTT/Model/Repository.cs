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
        Client waitingClient;

        public Client GetWaitingClient()
        {
            lock (this)
            {
                waitingClient = _clients.Where(c => c.IsWaiting == true).FirstOrDefault();
                if (waitingClient != null)
                {
                    waitingClient.IsWaiting = false;
                    _clients.Remove(waitingClient);
                }
            }
            return waitingClient;
        }

        public void PushClientToWait(Client client)
        {
            lock (this)
            {
                client.IsWaiting = true;
                _clients.Add(client);
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
