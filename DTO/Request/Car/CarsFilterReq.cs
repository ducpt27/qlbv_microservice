using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using VeXe.DTO;

namespace VeXe.Dto.Request.Car
{
    public class CarsFilterReq: IRequest<List<CarDto>>
    {
        public class CarsFilterHandler: IRequestHandler<CarsFilterReq, List<CarDto>>
        {
            public CarsFilterHandler()
            {
            }

            public Task<List<CarDto>> Handle(CarsFilterReq request, CancellationToken cancellationToken)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}