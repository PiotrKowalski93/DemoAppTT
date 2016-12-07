using DemoTT.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DemoTT.Model
{
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
            //Console.WriteLine("Client Occupied: {0}", _id);
            Thread.Sleep(10000);
            //Console.WriteLine("Client Unoccupied: {0}", _id);
        }
    }
}
