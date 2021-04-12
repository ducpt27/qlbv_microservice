using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VeXe.Domain;
using VeXe.DTO;

namespace VeXe.Service
{
    public interface IExampleService
    {
        Task<List<AbcDto>> GetList();

        Task<AbcDto> GetOne(int id);
    }
}