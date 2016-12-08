using DemoTT.Enums;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace DemoTT.Model
{
    public class Client
    {
        public bool IsWaiting = true;
        private int _id;
        private ClientStatuses _status;

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
        public ClientStatuses Status
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

        public Client(int id)
        {
            _id = id;
            Status = ClientStatuses.Waiting;
        }

        public void StartService()
        {
            Debug.WriteLine("Client Occupied: {0}", _id);

            Thread.Sleep(10000);
            
            Debug.WriteLine("Client Unoccupied: {0}", _id);
        }
    }
}
