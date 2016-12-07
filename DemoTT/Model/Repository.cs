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
        List<Client> clients;
        Client waitingClient;

        public Client GetWaitingClient()
        {
            lock (this)
            {
                waitingClient = clients.Where(c => c.IsWaiting == true).FirstOrDefault();
                if (waitingClient != null)
                {
                    waitingClient.IsWaiting = false;
                    clients.Remove(waitingClient);
                }
            }
            return waitingClient;
        }

        public void PushClientToWait(Client client)
        {
            lock (this)
            {
                client.IsWaiting = true;
                clients.Add(client);
            }
        }

        public void CreateClients(int count)
        {
            clients = new List<Client>();

            for (int i = 1; i <= count; i++)
            {
                clients.Add(new Client(i));
            }
        }

        public ObservableCollection<Client> GetClients()
        {
            return clients.ToObservableCollection();
        }
    }
}
