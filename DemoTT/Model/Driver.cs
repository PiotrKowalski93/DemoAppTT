using DemoTT.Enums;
using System;
using System.Device.Location;
using System.Diagnostics;
namespace DemoTT.Model
{
    public class Driver
    {
        private int _id;
        private int _clientId;
        private DriverStatuses _status;

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

        public Driver(int id)
        {
            _id = id;
            _clientId = 0;
            Status = DriverStatuses.Waiting;
                        
            Coordinates = new GeoCoordinate();

            Coordinates.Latitude = _random.Next(10, 50);
            Coordinates.Longitude = _random.Next(10, 50);

            Debug.WriteLine("Driver: {0} | Latitude: {1} | Longitude: {2}", _id, Coordinates.Latitude, Coordinates.Longitude);

        }
    }
}
