using DemoTT.Enums;
using DemoTT.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTT.Model
{
    public class Driver
    {
        private Repository _repo;
        private int _id;
        private int _clientId;
        private DriverStatuses _status;
        
        public int Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }
        public DriverStatuses Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
            }
        }
        public int ClientId
        {
            get
            {
                return _clientId;
            }
            set
            {
                _clientId = value;
            }
        }

        public Driver(Repository repo, int id)
        {
            _repo = repo;
            _id = id;

            Status = DriverStatuses.Waiting;
        }

        //public void StartWork()
        //{
        //    while (true)
        //    {
        //        Client client = _repo.GetWaitingClient();                

        //        if (client == null) continue;

        //        Debug.WriteLine("Starting Driver: {0}", _id);
                
        //        ClientId = client.Id;
        //        client.StartService();
        //        Status = DriverStatuses.DuringWork;

        //        _repo.PushClientToWait(client);
        //        Status = DriverStatuses.Waiting;

        //        Debug.WriteLine("Releasing Driver: {0}", _id);
        //    }
        //}

    }
}
