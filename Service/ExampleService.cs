using System;
using System.Threading.Tasks;

namespace VeXe.Service
{
    public interface ExampleService
    {
        string getAbc(string xyz);

        Task<string> getInDbTest(int id);
    }
}