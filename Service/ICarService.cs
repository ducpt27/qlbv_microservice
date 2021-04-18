using System.Collections.Generic;
using System.Threading.Tasks;
using VeXe.DTO;

namespace VeXe.Service
{
    public interface ICarService
    {
        Task<List<CarDto>> GetList();
    }
}