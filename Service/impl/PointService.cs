using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using VeXe.Common.Exceptions;
using VeXe.Domain;
using VeXe.DTO;
using VeXe.Persistence;

namespace VeXe.Service.impl
{
    public class PointService : IPointService
    {
        public Task<List<PointDto>> GetList()
        {
            throw new NotImplementedException();
        }
    }
}