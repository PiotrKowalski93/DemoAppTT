using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DemoTT.Model;

namespace DemoTT.Services
{
    public class DataGeneratorService : IDataGeneratorService
    {
        public Task<List<Driver>> GenerateDrivers(int amout)
        {
            throw new NotImplementedException();
        }

        public Task<List<Client>> GnerateClients(int amout)
        {
           return Task.Run(() => new List<Client>()
           {
               new Client(1),
               new Client(2)
           });
        }
    }
}
