using DemoTT.Enums;
using System;
using System.Device.Location;
using System.Diagnostics;
using System.Threading;

namespace DemoTT.Model
{
    public class Client
    {
        public bool IsWaiting;
        private int _id;
        private static Random _random = new Random();

        public GeoCoordinate Coordinates;

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

            Coordinates = new GeoCoordinate();

            Coordinates.Latitude = _random.Next(10, 50);
            Coordinates.Longitude = _random.Next(10, 50);

            Debug.WriteLine("Client: {0} | Latitude: {1} | Longitude: {2}", _id, Coordinates.Latitude, Coordinates.Longitude);
        }

        public void StartService()
        {
            Debug.WriteLine("Client Occupied: {0}", _id);
            
            int workingTime = _random.Next(8000, 15000);

            Thread.Sleep(workingTime);
            
            Debug.WriteLine("Client Unoccupied: {0}", _id);
        }
    }
}
