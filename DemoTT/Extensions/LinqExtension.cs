using DemoTT.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Device.Location;
using System.Linq;

namespace DemoTT.Extensions
{
    public static class LinqExtensions
    {
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> _LinqResult)
        {
            return new ObservableCollection<T>(_LinqResult);
        }

        public static Client ChooseShortestDistanceExample(this IEnumerable<Client> clients, GeoCoordinate driverCoordinates)
        {
            double minDistance = double.MaxValue;
            double clientId = 0;

            foreach (Client client in clients)
            {
                if(client.IsWaiting == true)
                {
                    double distance = client.Coordinates.GetDistanceTo(driverCoordinates);

                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        clientId = client.Id;
                    }
                }
            }

            return clients.Where(c => c.Id == clientId).SingleOrDefault();    
        }
    }
}
