using DemoTT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoTT.Services
{
    public interface IDataGeneratorService
    {
        Task<List<Client>> GnerateClients(int amout);
        Task<List<Driver>> GenerateDrivers(int amout);
    }
}
