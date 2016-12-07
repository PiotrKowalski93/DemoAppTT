using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MonitorSample
{
    class Program
    {
        public static void Main(String[] args)
        {
            List<Driver> drivers = new List<Driver>();

            Repository repo = new Repository();
            repo.CreateClients(5);

            for (int i = 1; i <= 3; i++)
            {
                drivers.Add(new Driver(repo, i));
            }

            foreach (Driver driver in drivers)
            {
                new Thread(new ThreadStart(driver.StartWork)).Start();
            }

            Console.ReadKey();
        }
    }

    public class Driver
    {
        private Repository _repo;
        private int _id;

        public Driver(Repository repo, int id)
        {
            _repo = repo;
            _id = id;
        }
        public void StartWork()
        {
            while(true)
            {
                var client = _repo.GetWaitingClient();

                if (client == null) continue;
                Console.WriteLine("Starting Driver: {0}", _id);
                client.StartService();
                _repo.PushClientToWait(client);
                Console.WriteLine("Releasing Driver: {0}", _id);
            }       
        }
    }

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
            lock(this)
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
    }

    public class Client
    {
        public bool IsWaiting = true;
        private int _id;

        public Client(int id)
        {
            _id = id;
        }

        public void StartService()
        {
            Console.WriteLine("Client Occupied: {0}", _id);
            Thread.Sleep(10000);
            Console.WriteLine("Client Unoccupied: {0}", _id);
        }
    }
}
