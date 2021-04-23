using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using MediatR;

namespace VeXe.DTO.Request.Car
{
    public class AddRouteReq : IRequest<RouteDto>
    {
    }
}