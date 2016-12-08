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
        public bool IsWaiting;
        private int _id;
        //private ClientStatuses _status;

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
                if (IsWaiting) return ClientStatuses.Waiting;
                return ClientStatuses.Accepted;
            }
        }

        public Client(int id)
        {
            _id = id;
            IsWaiting = true;
        }

        public void StartService()
        {
            Debug.WriteLine("Client Occupied: {0}", _id);

            Thread.Sleep(5000);
            
            Debug.WriteLine("Client Unoccupied: {0}", _id);
        }
    }
}
