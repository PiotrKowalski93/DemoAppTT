using DemoTT.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTT.Model
{
    public class Driver
    {
        private Reposritory _repo;
        private int _id;

        public Driver(Reposritory repo, int id)
        {
            _repo = repo;
            _id = id;
        }
        public void StartWork()
        {
            while (true)
            {
                var client = _repo.GetWaitingClient();

                if (client == null) continue;
                //Console.WriteLine("Starting Driver: {0}", _id);
                client.StartService();
                _repo.PushClientToWait(client);
                //Console.WriteLine("Releasing Driver: {0}", _id);
            }
        }

    }
}
