using System.Collections.Generic;
using System.Threading.Tasks;
using VeXe.DTO;

namespace VeXe.Service
{
    public interface IPointService
    {
        Task<List<PointDto>> GetList();
    }
}