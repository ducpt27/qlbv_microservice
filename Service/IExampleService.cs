using System;
using System.Threading.Tasks;

namespace VeXe.Service
{
    public interface IExampleService
    {
        string GetAbc(string xyz);

        Task<string> GetInDbTest(int id);
    }
}