using System.Collections.Generic;
using System.Threading.Tasks;
using VeXe.DTO;

namespace VeXe.Service
{
    public interface IRouteService
    {
        Task<List<RouteDto>> GetList();
    }
}